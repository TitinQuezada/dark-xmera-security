using System.Collections.Generic;

namespace Core.Models
{
    public class ModuleModel : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public IEnumerable<RoleModel> Roles { get; set; }

        public IEnumerable<ScreenModel> Screens { get; set; }
    }
}
