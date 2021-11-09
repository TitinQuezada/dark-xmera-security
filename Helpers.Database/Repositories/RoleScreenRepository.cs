using Core.Interfaces.Repositories;
using Core.Models;

namespace Helpers.Database.Repositories
{
    public sealed class RoleScreenRepository : BaseRepository<RoleScreenModel>, IRoleScreenRepository
    {
        public RoleScreenRepository(DarkXmeraSecurityDbContext applicationContext) : base(applicationContext)
        {

        }
    }
}
