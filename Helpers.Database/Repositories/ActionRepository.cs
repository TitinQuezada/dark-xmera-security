using Core.Interfaces;
using Core.Models;

namespace Helpers.Database.Repositories
{
    public sealed class ActionRepository : BaseRepository<ActionModel> , IActionRepository
    {
        public ActionRepository(DarkXmeraSecurityDbContext applicationContext) : base(applicationContext)
        {

        }
    }
}
