using Core.Interfaces.Repositories;
using Core.Models;

namespace Helpers.Database.Repositories
{
    public sealed class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(DarkXmeraSecurityDbContext applicationContext) : base(applicationContext)
        {
        }
    }
}
