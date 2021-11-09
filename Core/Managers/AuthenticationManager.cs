using Core.Configurations;
using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.Encrypt;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.ViewModels.Authentication;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
    public sealed class AuthenticationManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptService _encryptService;
        private readonly IRoleRepository _roleRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IScreenRepository _screenRepository;

        public AuthenticationManager(IUserRepository userRepository, IEncryptService encryptService, IRoleRepository roleRepository, IModuleRepository moduleRepository, IScreenRepository screenRepository)
        {
            _userRepository = userRepository;
            _encryptService = encryptService;
            _roleRepository = roleRepository;
            _moduleRepository = moduleRepository;
            _screenRepository = screenRepository;
        }

        public async Task<IOperationResult<LoginResponseViewModel>> Login(LoginViewModel loginViewModel)
        {
            string passwordResult = _encryptService.EncryptText(loginViewModel.Password);

            UserModel user = await _userRepository.FindAsync(user => (user.UserName == loginViewModel.UserName || user.Email == loginViewModel.UserName) && user.Password == passwordResult);

            if (user == default(UserModel))
            {
                return OperationResult<LoginResponseViewModel>.Fail("Usuario o contraseña incorrecto");
            }

            RoleModel role = await _roleRepository.FindAsync(role => role.Id == user.RoleId, role => role.ModuleRoles, role => role.RoleScreens);

            IEnumerable<ModuleModel> modules = await GetModules(role.ModuleRoles);
            IEnumerable<ScreenModel> screens = await GetScreens(role.RoleScreens);

            LoginResponseViewModel loginResponse = new LoginResponseViewModel
            {
                Token = BuildToken(user),
                Modules = modules.Select(module => module.ToViewModel()),
                Screens = screens.Select(screen => screen.ToViewModel())
            };

            return OperationResult<LoginResponseViewModel>.Ok(loginResponse);
        }

        private async Task<IEnumerable<ModuleModel>> GetModules(IEnumerable<ModuleRoleModel> moduleRoles)
        {
            List<ModuleModel> modules = new List<ModuleModel>();

            foreach (var moduleRole in moduleRoles)
            {
                ModuleModel module = await _moduleRepository.FindAsync(module => module.Id == moduleRole.ModuleId);
                modules.Add(module);
            }

            return modules;
        }

        private async Task<IEnumerable<ScreenModel>> GetScreens(IEnumerable<RoleScreenModel> roleScreens)
        {
            List<ScreenModel> modules = new List<ScreenModel>();

            foreach (var roleScreen in roleScreens)
            {
                ScreenModel screen = await _screenRepository.FindAsync(screen => screen.Id == roleScreen.ScreenId);
                modules.Add(screen);
            }

            return modules;
        }

        private string BuildToken(UserModel user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleId)
            };

            string secretKey = Environment.GetEnvironmentVariable(EnviromentVariables.JwtSecretKey);
            string issuer = Environment.GetEnvironmentVariable(EnviromentVariables.JwtValidIssuer);
            string audience = Environment.GetEnvironmentVariable(EnviromentVariables.JwtValidAudience);

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddHours(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IOperationResult<PermissionsViewModel>> GetPermissions(string token)
        {
            JwtSecurityToken securityToken = ValidateJwtToken(token);

            if (securityToken == default(JwtSecurityToken))
            {
                return OperationResult<PermissionsViewModel>.Fail("Token invalido");
            }

            Claim claim = securityToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role);

            RoleModel role = await _roleRepository.FindAsync(role => role.Id == claim.Value, role => role.ModuleRoles, role => role.RoleScreens);

            IEnumerable<ModuleModel> modules = await GetModules(role.ModuleRoles);
            IEnumerable<ScreenModel> screens = await GetScreens(role.RoleScreens);

            PermissionsViewModel permission = new PermissionsViewModel
            {
                Modules = modules.Select(module => module.ToViewModel()),
                Screens = screens.Select(screen => screen.ToViewModel())
            };

            return OperationResult<PermissionsViewModel>.Ok(permission);
        }

        private JwtSecurityToken ValidateJwtToken(string token)
        {
            try
            {
                string secretKey = Environment.GetEnvironmentVariable(EnviromentVariables.JwtSecretKey);
                string issuer = Environment.GetEnvironmentVariable(EnviromentVariables.JwtValidIssuer);
                string audience = Environment.GetEnvironmentVariable(EnviromentVariables.JwtValidAudience);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(secretKey);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidIssuer = issuer,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return (JwtSecurityToken)validatedToken;
            }
            catch (Exception)
            {
                return default(JwtSecurityToken);
            }
        }
    }
}
