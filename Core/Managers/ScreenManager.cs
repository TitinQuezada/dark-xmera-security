using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.ViewModels.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Managers
{
    public sealed class ScreenManager
    {
        private readonly IScreenRepository _screenRepository;

        public ScreenManager(IScreenRepository screenRepository)
        {
            _screenRepository = screenRepository;
        }

        public async Task<IOperationResult<IEnumerable<ScreenViewModel>>> GetAll()
        {
            IEnumerable<ScreenModel> screens = await _screenRepository.GetAllAsync();
            IEnumerable<ScreenViewModel> screenssResult = screens.Select(screen => BuildScreenViewModel(screen)).ToList();
            return OperationResult<IEnumerable<ScreenViewModel>>.Ok(screenssResult);
        }

        public async Task<IOperationResult<ScreenViewModel>> GetById(string id)
        {
            ScreenModel screen = await _screenRepository.FindAsync(action => action.Id == id);

            if (screen == default(ScreenModel))
            {
                return OperationResult<ScreenViewModel>.Fail("No se encontro la pantalla");
            }

            ScreenViewModel screenResult = BuildScreenViewModel(screen);
            return OperationResult<ScreenViewModel>.Ok(screenResult);
        }

        private ScreenViewModel BuildScreenViewModel(ScreenModel screen)
        {
            return new ScreenViewModel
            {
                Id = screen.Id,
                Name = screen.Name,
                Url = screen.Url,
                Description = screen.Description,
                CreatedDate = screen.CreatedDate,
                UpdatedDate = screen.UpdatedDate
            };
        }

        public async Task<IOperationResult<bool>> Create(ScreenCreateOrEditViewModel screen)
        {
            ScreenModel screenToCreate = BuildScreenModel(screen);

            screenToCreate.Id = Guid.NewGuid().ToString();
            screenToCreate.CreatedDate = DateTime.Now;
            screenToCreate.UpdatedDate = DateTime.Now;

            _screenRepository.Create(screenToCreate);
            await _screenRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }

        private ScreenModel BuildScreenModel(ScreenCreateOrEditViewModel screen)
        {
            return new ScreenModel
            {
                Id = screen.Id,
                Name = screen.Name,
                Description = screen.Description,
                CreatedDate = screen.CreatedDate,
                UpdatedDate = screen.UpdatedDate,
                Url = screen.Url,
                ModuleId = screen.ModuleId
            };
        }

        public async Task<IOperationResult<bool>> Update(string id, ScreenCreateOrEditViewModel screenToUpdate)
        {
            if (!screenToUpdate.Id.Equals(id))
            {
                return OperationResult<bool>.Fail("No se encontro la pantalla para editar");
            }

            ScreenModel screenToUpdateResult = await _screenRepository.FindAsync(action => action.Id == screenToUpdate.Id);

            screenToUpdateResult.Name = screenToUpdate.Name;
            screenToUpdateResult.Description = screenToUpdate.Description;
            screenToUpdateResult.UpdatedDate = DateTime.Now;
            screenToUpdateResult.Url = screenToUpdate.Url;

            await _screenRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }

        public async Task<IOperationResult<bool>> Delete(string id)
        {
            _screenRepository.Delete(id);
            await _screenRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }
    }
}
