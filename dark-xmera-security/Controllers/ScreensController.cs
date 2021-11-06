using Core.Helpers;
using Core.Interfaces;
using Core.Managers;
using Core.ViewModels.Screen;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dark_xmera_security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreensController : ControllerBase
    {
        private readonly ScreenManager _screenManager;

        public ScreensController(ScreenManager screenManager)
        {
            _screenManager = screenManager;
        }

        [HttpGet]
        public async Task<HttpResponse<IEnumerable<ScreenViewModel>>> GetAll()
        {
            IOperationResult<IEnumerable<ScreenViewModel>> operationResult = await _screenManager.GetAll();

            if (!operationResult.Success)
            {
                return HttpResponse<IEnumerable<ScreenViewModel>>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<IEnumerable<ScreenViewModel>>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpGet("{id}")]
        public async Task<HttpResponse<ScreenViewModel>> GetById(string id)
        {
            IOperationResult<ScreenViewModel> operationResult = await _screenManager.GetById(id);

            if (!operationResult.Success)
            {
                return HttpResponse<ScreenViewModel>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<ScreenViewModel>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpPost]
        public async Task<HttpResponse<bool>> Create(ScreenCreateOrEditViewModel action)
        {
            IOperationResult<bool> operationResult = await _screenManager.Create(action);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpPut("{id}")]
        public async Task<HttpResponse<bool>> Update(string id, ScreenCreateOrEditViewModel action)
        {
            IOperationResult<bool> operationResult = await _screenManager.Update(id, action);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponse<bool>> Delete(string id)
        {
            IOperationResult<bool> operationResult = await _screenManager.Delete(id);

            if (!operationResult.Success)
            {
                return HttpResponse<bool>.GetFailedResponse(operationResult.Message);
            }

            return HttpResponse<bool>.GetSuccessResponse(operationResult.Entity);
        }
    }
}
