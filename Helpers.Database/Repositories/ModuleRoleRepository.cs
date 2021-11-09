using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Models;

namespace Helpers.Database.Repositories
{
    public sealed class ModuleRoleRepository : BaseRepository<ModuleRoleModel> , IModuleRoleRepository
    {
        public ModuleRoleRepository(DarkXmeraSecurityDbContext applicationContext) : base(applicationContext)
        {

        }
    }
}
