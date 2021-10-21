using System.Collections.Generic;

namespace Core.ViewModels.Role
{
    public sealed class RoleCreateOrEditViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> ModulesIds { get; set; }

        public IEnumerable<string> ScreensIds { get; set; }
    }
}
