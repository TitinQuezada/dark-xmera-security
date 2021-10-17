using Core.Interfaces.Repositories;
using Core.Models;

namespace Helpers.Database.Repositories
{
    public sealed class ScreenRepository : BaseRepository<ScreenModel>, IScreenRepository
    {
        public ScreenRepository(DarkXmeraSecurityDbContext applicationContext) : base(applicationContext)
        {
        }
    }
}
