using System.Collections.Generic;

namespace Core.Models
{
    public class ScreenModel : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string ModuleId { get; set; }

        public ModuleModel Module { get; set; }

        public IEnumerable<RoleModel> Roles { get; set; }
    }
}
