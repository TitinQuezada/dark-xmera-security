using Core.Helpers;
using Core.Interfaces;
using Core.Managers;
using Core.ViewModels.Role;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dark_xmera_security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager _roleManager;

        public RolesController(RoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<HttpResponse<IEnumerable<RoleViewModel>>> GetAll()
        {
            IOperationResult<IEnumerable<RoleViewModel>> operationResult = await _roleManager.GetAll();

            if (!operationResult.Success)
            {
                return HttpResponse<IEnumerable<RoleViewModel>>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<IEnumerable<RoleViewModel>>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpGet("{id}")]
        public async Task<HttpResponse<RoleViewModel>> GetById(string id)
        {
            IOperationResult<RoleViewModel> operationResult = await _roleManager.GetById(id);

            if (!operationResult.Success)
            {
                return HttpResponse<RoleViewModel>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<RoleViewModel>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpPost]
        public async Task<HttpResponse<bool>> Create(RoleCreateOrEditViewModel action)
        {
            IOperationResult<bool> operationResult = await _roleManager.Create(action);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpPut("{id}")]
        public async Task<HttpResponse<bool>> Update(string id, RoleCreateOrEditViewModel action)
        {
            IOperationResult<bool> operationResult = await _roleManager.Update(id, action);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpDelete]
        public async Task<HttpResponse<bool>> Delete(string id)
        {
            IOperationResult<bool> operationResult = await _roleManager.Delete(id);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }
    }
}
