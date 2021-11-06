using Core.Helpers;
using Core.Interfaces;
using Core.Managers;
using Core.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dark_xmera_security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager _userManager;

        public UsersController(UserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<HttpResponse<IEnumerable<UserViewModel>>> GetAll()
        {
            IOperationResult<IEnumerable<UserViewModel>> operationResult = await _userManager.GetAll();

            if (!operationResult.Success)
            {
                return HttpResponse<IEnumerable<UserViewModel>>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<IEnumerable<UserViewModel>>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpGet("{id}")]
        public async Task<HttpResponse<UserViewModel>> GetById(string id)
        {
            IOperationResult<UserViewModel> operationResult = await _userManager.GetById(id);

            if (!operationResult.Success)
            {
                return HttpResponse<UserViewModel>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<UserViewModel>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpPost]
        public async Task<HttpResponse<bool>> Create(UserCreateOrEditViewModel action)
        {
            IOperationResult<bool> operationResult = await _userManager.Create(action);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpPut("{id}")]
        public async Task<HttpResponse<bool>> Update(string id, UserCreateOrEditViewModel action)
        {
            IOperationResult<bool> operationResult = await _userManager.Update(id, action);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponse<bool>> Delete(string id)
        {
            IOperationResult<bool> operationResult = await _userManager.Delete(id);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }
    }
}
