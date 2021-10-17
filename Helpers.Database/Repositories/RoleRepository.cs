using Core.Interfaces.Repositories;
using Core.Models;

namespace Helpers.Database.Repositories
{
    public sealed class RoleRepository : BaseRepository<RoleModel>, IRoleRepository
    {
        public RoleRepository(DarkXmeraSecurityDbContext applicationContext) : base(applicationContext)
        {

        }
    }
}
