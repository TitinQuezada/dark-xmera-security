using Core.Interfaces.Repositories;
using Core.Models;

namespace Helpers.Database.Repositories
{
    public sealed class ModuleRepository : BaseRepository<ModuleModel>, IModuleRepository
    {
        public ModuleRepository(DarkXmeraSecurityDbContext applicationContext) : base(applicationContext)
        {
        }
    }
}
