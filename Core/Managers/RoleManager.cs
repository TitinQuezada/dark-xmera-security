using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Managers
{
    public sealed class RoleManager
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleScreenRepository _roleScreenRepository;
        private readonly IModuleRoleRepository _moduleRoleRepository;

        public RoleManager(IRoleRepository roleRepository, IRoleScreenRepository roleScreenRepository, IModuleRoleRepository moduleRoleRepository)
        {
            _roleRepository = roleRepository;
            _roleScreenRepository = roleScreenRepository;
            _moduleRoleRepository = moduleRoleRepository;
        }

        public async Task<IOperationResult<IEnumerable<RoleViewModel>>> GetAll()
        {
            IEnumerable<RoleModel> screens = await _roleRepository.GetAllAsync();
            IEnumerable<RoleViewModel> rolesResult = screens.Select(role => BuildRoleViewModel(role)).ToList();
            return OperationResult<IEnumerable<RoleViewModel>>.Ok(rolesResult);
        }

        public async Task<IOperationResult<RoleViewModel>> GetById(string id)
        {
            RoleModel role = await _roleRepository.FindAsync(action => action.Id == id);

            if (role == default(RoleModel))
            {
                return OperationResult<RoleViewModel>.Fail("No se encontro el role");
            }

            RoleViewModel roleResult = BuildRoleViewModel(role);
            return OperationResult<RoleViewModel>.Ok(roleResult);
        }

        private RoleViewModel BuildRoleViewModel(RoleModel role)
        {
            return new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                CreatedDate = role.CreatedDate,
                UpdatedDate = role.UpdatedDate
            };
        }

        public async Task<IOperationResult<bool>> Create(RoleCreateOrEditViewModel role)
        {
            RoleModel screenToCreate = await BuildRoleModel(role);

            screenToCreate.Id = Guid.NewGuid().ToString();
            screenToCreate.CreatedDate = DateTime.Now;
            screenToCreate.UpdatedDate = DateTime.Now;

            _roleRepository.Create(screenToCreate);
            await _roleRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }

        private async Task<RoleModel> BuildRoleModel(RoleCreateOrEditViewModel role)
        {
            IEnumerable<RoleScreenModel> screens = await GetRoleScreens(role.ScreensIds);
            IEnumerable<ModuleRoleModel> modules = await GetModules(role.ModulesIds);

            return new RoleModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                CreatedDate = role.CreatedDate,
                UpdatedDate = role.UpdatedDate,
                RoleScreens = screens,
                ModuleRoles = modules
            };
        }

        private async Task<IEnumerable<RoleScreenModel>> GetRoleScreens(IEnumerable<string> screensIds)
        {
            List<RoleScreenModel> roleScreens = new List<RoleScreenModel>();

            foreach (string screenId in screensIds)
            {
                RoleScreenModel screen = await _roleScreenRepository.FindAsync(roleScreen => roleScreen.ScreenId == screenId);
                roleScreens.Add(screen);
            }

            return roleScreens;
        }

        private async Task<IEnumerable<ModuleRoleModel>> GetModules(IEnumerable<string> modulesIds)
        {
            List<ModuleRoleModel> modules = new List<ModuleRoleModel>();

            foreach (string moduleId in modulesIds)
            {
                ModuleRoleModel module = await _moduleRoleRepository.FindAsync(moduleRole => moduleRole.ModuleId == moduleId);
                modules.Add(module);
            }

            return modules;
        }

        public async Task<IOperationResult<bool>> Update(string id, RoleCreateOrEditViewModel roleToUpdate)
        {
            if (!roleToUpdate.Id.Equals(id))
            {
                return OperationResult<bool>.Fail("No se encontro el rol para editar");
            }

            RoleModel roleToUpdateResult = await _roleRepository.FindAsync(role => role.Id == roleToUpdate.Id, action => action.RoleScreens);

            roleToUpdateResult.Name = roleToUpdate.Name;
            roleToUpdateResult.Description = roleToUpdate.Description;
            roleToUpdateResult.UpdatedDate = DateTime.Now;
            roleToUpdateResult.RoleScreens = await GetRoleScreens(roleToUpdate.ScreensIds);
            roleToUpdateResult.ModuleRoles = await GetModules(roleToUpdate.ModulesIds);

            await _roleRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }
        public async Task<IOperationResult<bool>> Delete(string id)
        {
            _roleRepository.Delete(id);
            await _roleRepository.SaveAsync();

            return OperationResult<bool>.Ok();
        }
    }
}
