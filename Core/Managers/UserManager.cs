using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.Encrypt;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Managers
{
    public sealed class UserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEncryptService _encryptService;

        public UserManager(IUserRepository userRepository, IRoleRepository roleRepository, IEncryptService encryptService)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _encryptService = encryptService;
        }

        public async Task<IOperationResult<IEnumerable<UserViewModel>>> GetAll()
        {
            IEnumerable<UserModel> users = await _userRepository.GetAllAsync(user => user.Role);
            IEnumerable<UserViewModel> usersResult = users.Select(user => BuildUserViewModel(user)).ToList();
            return OperationResult<IEnumerable<UserViewModel>>.Ok(usersResult);
        }

        public async Task<IOperationResult<UserViewModel>> GetById(string id)
        {
            UserModel user = await _userRepository.FindAsync(action => action.Id == id);

            if (user == default(UserModel))
            {
                return OperationResult<UserViewModel>.Fail("No se encontro el usuario");
            }

            UserViewModel userResult = BuildUserViewModel(user);
            return OperationResult<UserViewModel>.Ok(userResult);
        }

        private UserViewModel BuildUserViewModel(UserModel user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                RoleId = user.Role.Id,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate
            };
        }

        public async Task<IOperationResult<bool>> Create(UserCreateOrEditViewModel user)
        {
            UserModel userToCreate = await BuildUserModel(user);

            userToCreate.Id = Guid.NewGuid().ToString();
            userToCreate.CreatedDate = DateTime.Now;
            userToCreate.UpdatedDate = DateTime.Now;

            _userRepository.Create(userToCreate);
            await _userRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }

        private async Task<UserModel> BuildUserModel(UserCreateOrEditViewModel user)
        {
            RoleModel role = await _roleRepository.FindAsync(role => role.Id == user.RoleId);
            string password = _encryptService.EncryptText(user.Password);

            return new UserModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Password = password,
                Role = role,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate
            };
        }

        public async Task<IOperationResult<bool>> Update(string id, UserCreateOrEditViewModel userToUpdate)
        {
            if (!userToUpdate.Id.Equals(id))
            {
                return OperationResult<bool>.Fail("No se encontro el usuario para editar");
            }

            UserModel userToUpdateResult = await _userRepository.FindAsync(user => user.Id == userToUpdate.Id);
            RoleModel role = await _roleRepository.FindAsync(role => role.Id == userToUpdate.RoleId);

            userToUpdateResult.UserName = userToUpdate.UserName;
            userToUpdateResult.Password = _encryptService.EncryptText(userToUpdate.Password);
            userToUpdateResult.Email = userToUpdate.Email;
            userToUpdateResult.Role = role;
            userToUpdateResult.UpdatedDate = DateTime.Now;

            await _userRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }

        public async Task<IOperationResult<bool>> Delete(string id)
        {
            _userRepository.Delete(id);
            await _userRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }
    }
}
