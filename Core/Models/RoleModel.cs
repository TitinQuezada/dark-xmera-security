
using System.Collections.Generic;

namespace Core.Models
{
    public sealed class RoleModel : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<UserModel> Users { get; set; }

        public IEnumerable<ModuleRoleModel> ModuleRoles { get; set; }

        public IEnumerable<RoleScreenModel> RoleScreens { get; set; }
    }
}
