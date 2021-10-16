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
            try
            {
                IOperationResult<IEnumerable<ActionViewModel>> operationResult = await _actionManager.GetAll();

                if (!operationResult.Success)
                {
                    return HttpResponse<IEnumerable<ActionViewModel>>.GetFailedResponse(operationResult.Message);
                }

                return HttpResponse<IEnumerable<ActionViewModel>>.GetSuccessResponse(operationResult.Entity);
            }
            catch (System.Exception ex)
            {
                return HttpResponse<IEnumerable<ActionViewModel>>.GetFailedResponse(ex.ToString());
            }

        }
    }
}
