using Core.Helpers;
using Core.Interfaces;
using Core.Managers;
using Core.ViewModels.Module;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dark_xmera_security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly ModuleManager _moduleManager;

        public ModulesController(ModuleManager moduleManager)
        {
            _moduleManager = moduleManager;
        }

        [HttpGet]
        public async Task<HttpResponse<IEnumerable<ModuleViewModel>>> GetAll()
        {
            IOperationResult<IEnumerable<ModuleViewModel>> operationResult = await _moduleManager.GetAll();

            if (!operationResult.Success)
            {
                return HttpResponse<IEnumerable<ModuleViewModel>>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<IEnumerable<ModuleViewModel>>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpGet("{id}")]
        public async Task<HttpResponse<ModuleViewModel>> GetById(string id)
        {
            IOperationResult<ModuleViewModel> operationResult = await _moduleManager.GetById(id);

            if (!operationResult.Success)
            {
                return HttpResponse<ModuleViewModel>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<ModuleViewModel>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpPost]
        public async Task<HttpResponse<bool>> Create(ModuleCreateOrEditViewModel action)
        {
            IOperationResult<bool> operationResult = await _moduleManager.Create(action);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpPut("{id}")]
        public async Task<HttpResponse<bool>> Update(string id, ModuleCreateOrEditViewModel action)
        {
            IOperationResult<bool> operationResult = await _moduleManager.Update(id, action);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpDelete]
        public async Task<HttpResponse<bool>> Delete(string id)
        {
            IOperationResult<bool> operationResult = await _moduleManager.Delete(id);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }
    }
}
