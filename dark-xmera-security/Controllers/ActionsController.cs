using Core.Helpers;
using Core.Interfaces;
using Core.Managers;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dark_xmera_security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {
        private readonly ActionManager _actionManager;

        public ActionsController(ActionManager actionManager)
        {
            _actionManager = actionManager;
        }

        [HttpGet]
        public async Task<HttpResponse<IEnumerable<ActionViewModel>>> GetAll()
        {
            IOperationResult<IEnumerable<ActionViewModel>> operationResult = await _actionManager.GetAll();

            if (!operationResult.Success)
            {
                return HttpResponse<IEnumerable<ActionViewModel>>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<IEnumerable<ActionViewModel>>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpGet("{id}")]
        public async Task<HttpResponse<ActionViewModel>> GetById(string id)
        {
            IOperationResult<ActionViewModel> operationResult = await _actionManager.GetById(id);

            if (!operationResult.Success)
            {
                return HttpResponse<ActionViewModel>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<ActionViewModel>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpPost]
        public async Task<HttpResponse<bool>> Create(ActionCreateOrEditViewModel action)
        {
            IOperationResult<bool> operationResult = await _actionManager.Create(action);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpPut("{id}")]
        public async Task<HttpResponse<bool>> Update(string id, ActionCreateOrEditViewModel action)
        {
            IOperationResult<bool> operationResult = await _actionManager.Update(id ,action);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponse<bool>> Delete(string id)
        {
            IOperationResult<bool> operationResult = await _actionManager.Delete(id);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }
    }
}
