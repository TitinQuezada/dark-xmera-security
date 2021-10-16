using Core.Helpers;
using Core.Interfaces;
using Core.Models;
using Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Managers
{
    public sealed class ActionManager
    {
        private readonly IActionRepository _actionRepository;

        public ActionManager(IActionRepository actionRepository)
        {
            _actionRepository = actionRepository;
        }

        public async Task<IOperationResult<IEnumerable<ActionViewModel>>> GetAll()
        {
            IEnumerable<ActionModel> actions = await _actionRepository.GetAllAsync();
            IEnumerable<ActionViewModel> actionsResult = actions.Select(action => BuildActionViewModel(action)).ToList();
            return OperationResult<IEnumerable<ActionViewModel>>.Ok(actionsResult);
        }

        private ActionViewModel BuildActionViewModel(ActionModel action)
        {
            return new ActionViewModel
            {
                Id = action.Id,
                Name = action.Name,
                Description = action.Description,
                CreatedDate = action.CreatedDate,
                UpdatedDate = action.UpdatedDate
            };
        }
    }
}
