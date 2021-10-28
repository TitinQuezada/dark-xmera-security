using Core.Helpers;
using Core.Interfaces;
using Core.Managers;
using Core.ViewModels.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace dark_xmera_security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationManager _authenticationManager;

        public AuthenticationController(AuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        [HttpPost("login")]
        public async Task<HttpResponse<LoginResponseViewModel>> Login(LoginViewModel loginViewModel)
        {
            try
            {
                IOperationResult<LoginResponseViewModel> operationResult = await _authenticationManager.Login(loginViewModel);

                if (!operationResult.Success)
                {
                    return HttpResponse<LoginResponseViewModel>.GetFailedResponse(operationResult.Message);
                }

                return HttpResponse<LoginResponseViewModel>.GetSuccessResponse(operationResult.Entity);
            }
            catch (Exception ex)
            {

                return HttpResponse<LoginResponseViewModel>.GetFailedResponse(ex.ToString());

            }

        }

        [HttpPost("permissions")]
        public async Task<HttpResponse<PermissionsViewModel>> Permissions(PermissionsRequestViewModel permissionsRequest)
        {
            IOperationResult<PermissionsViewModel> operationResult = await _authenticationManager.GetPermissions(permissionsRequest.Token);

            if (!operationResult.Success)
            {
                return HttpResponse<PermissionsViewModel>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<PermissionsViewModel>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpGet()]
        public async Task<HttpResponse<PermissionsViewModel>> GetPermissions()
        {

            return HttpResponse<PermissionsViewModel>.GetSuccessResponse(new PermissionsViewModel());
        }
    }
}
