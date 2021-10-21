using System.Collections.Generic;

namespace Core.Models
{
    public class StatusModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<UserModel> Users { get; set; }

        public IEnumerable<ModuleModel> Modules { get; set; }

        public IEnumerable<ScreenModel> Screens { get; set; }

        public IEnumerable<ActionModel> Actions { get; set; }

        public IEnumerable<RoleModel> Roles { get; set; }

    }
}
