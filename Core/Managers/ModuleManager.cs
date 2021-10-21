using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.ViewModels.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Managers
{
    public sealed class ModuleManager
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleManager(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<IOperationResult<IEnumerable<ModuleViewModel>>> GetAll()
        {
            IEnumerable<ModuleModel> modules = await _moduleRepository.GetAllAsync();
            IEnumerable<ModuleViewModel> modulesResult = modules.Select(module => BuildModuleViewModel(module)).ToList();
            return OperationResult<IEnumerable<ModuleViewModel>>.Ok(modulesResult);
        }

        public async Task<IOperationResult<ModuleViewModel>> GetById(string id)
        {
            ModuleModel screen = await _moduleRepository.FindAsync(action => action.Id == id);

            if (screen == default(ModuleModel))
            {
                return OperationResult<ModuleViewModel>.Fail("No se encontro la pantalla");
            }

            ModuleViewModel moduleResult = BuildModuleViewModel(screen);
            return OperationResult<ModuleViewModel>.Ok(moduleResult);
        }

        private ModuleViewModel BuildModuleViewModel(ModuleModel module)
        {
            return new ModuleViewModel
            {
                Id = module.Id,
                Name = module.Name,
                Url = module.Url,
                Description = module.Description,
                CreatedDate = module.CreatedDate,
                UpdatedDate = module.UpdatedDate
            };
        }

        public async Task<IOperationResult<bool>> Create(ModuleCreateOrEditViewModel module)
        {
            ModuleModel screenToCreate = BuildModuleModel(module);

            screenToCreate.Id = Guid.NewGuid().ToString();
            screenToCreate.CreatedDate = DateTime.Now;
            screenToCreate.UpdatedDate = DateTime.Now;

            _moduleRepository.Create(screenToCreate);
            await _moduleRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }

        private ModuleModel BuildModuleModel(ModuleCreateOrEditViewModel module)
        {
            return new ModuleModel
            {
                Id = module.Id,
                Name = module.Name,
                Description = module.Description,
                CreatedDate = module.CreatedDate,
                UpdatedDate = module.UpdatedDate,
                Url = module.Url
            };
        }

        public async Task<IOperationResult<bool>> Update(string id, ModuleCreateOrEditViewModel moduleToUpdate)
        {
            if (!moduleToUpdate.Id.Equals(id))
            {
                return OperationResult<bool>.Fail("No se encontro el modulo para editar");
            }

            ModuleModel moduleToUpdateResult = await _moduleRepository.FindAsync(action => action.Id == moduleToUpdate.Id);

            moduleToUpdateResult.Name = moduleToUpdate.Name;
            moduleToUpdateResult.Description = moduleToUpdate.Description;
            moduleToUpdateResult.UpdatedDate = DateTime.Now;
            moduleToUpdateResult.Url = moduleToUpdate.Url;

            await _moduleRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }

        public async Task<IOperationResult<bool>> Delete(string id)
        {
            _moduleRepository.Delete(id);
            await _moduleRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }
    }
}
