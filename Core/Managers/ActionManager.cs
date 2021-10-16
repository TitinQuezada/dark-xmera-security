using Core.Helpers;
using Core.Interfaces;
using Core.Models;
using Core.ViewModels;
using System;
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

        public async Task<IOperationResult<ActionViewModel>> GetById(string id)
        {
            ActionModel action = await _actionRepository.FindAsync(action => action.Id == id);

            if (action == default(ActionModel))
            {
                return OperationResult<ActionViewModel>.Fail("No se encontro la acción");
            }

            ActionViewModel actionResult = BuildActionViewModel(action);
            return OperationResult<ActionViewModel>.Ok(actionResult);
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

        public async Task<IOperationResult<bool>> Create(ActionCreateOrEditViewModel action)
        {
            ActionModel actionToCreate = BuildActionModel(action);

            actionToCreate.Id = Guid.NewGuid().ToString();
            actionToCreate.CreatedDate = DateTime.Now;
            actionToCreate.UpdatedDate = DateTime.Now;

            _actionRepository.Create(actionToCreate);
            await _actionRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }

        private ActionModel BuildActionModel(ActionCreateOrEditViewModel action)
        {
            return new ActionModel
            {
                Id = action.Id,
                Name = action.Name,
                Description = action.Description,
                CreatedDate = action.CreatedDate,
                UpdatedDate = action.UpdatedDate
            };
        }

        public async Task<IOperationResult<bool>> Update(string id, ActionCreateOrEditViewModel actionToUpdate)
        {
            if (!actionToUpdate.Id.Equals(id))
            {
                return OperationResult<bool>.Fail("No se encontro la acción para editar");
            }

            ActionModel actionToUpdateResult = await _actionRepository.FindAsync(action => action.Id == actionToUpdate.Id);

            actionToUpdateResult.Name = actionToUpdate.Name;
            actionToUpdateResult.Description = actionToUpdate.Description;
            actionToUpdateResult.UpdatedDate = DateTime.Now;

            await _actionRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }

        public async Task<IOperationResult<bool>> Delete(string id)
        {
            _actionRepository.Delete(id);
            await _actionRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }
    }
}
