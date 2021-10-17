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

        public RoleManager(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
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
            RoleModel screenToCreate = BuildRoleModel(role);

            screenToCreate.Id = Guid.NewGuid().ToString();
            screenToCreate.CreatedDate = DateTime.Now;
            screenToCreate.UpdatedDate = DateTime.Now;

            _roleRepository.Create(screenToCreate);
            await _roleRepository.SaveAsync();
            return OperationResult<bool>.Ok();
        }

        private RoleModel BuildRoleModel(RoleCreateOrEditViewModel role)
        {
            return new RoleModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                CreatedDate = role.CreatedDate,
                UpdatedDate = role.UpdatedDate
            };
        }

        public async Task<IOperationResult<bool>> Update(string id, RoleCreateOrEditViewModel roleToUpdate)
        {
            if (!roleToUpdate.Id.Equals(id))
            {
                return OperationResult<bool>.Fail("No se encontro el rol para editar");
            }

            RoleModel roleToUpdateResult = await _roleRepository.FindAsync(action => action.Id == roleToUpdate.Id);

            roleToUpdateResult.Name = roleToUpdate.Name;
            roleToUpdateResult.Description = roleToUpdate.Description;
            roleToUpdateResult.UpdatedDate = DateTime.Now;

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
