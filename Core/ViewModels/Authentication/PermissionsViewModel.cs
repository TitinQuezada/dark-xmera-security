using Core.ViewModels.Module;
using Core.ViewModels.Screen;
using System.Collections.Generic;

namespace Core.ViewModels.Authentication
{
    public sealed class PermissionsViewModel
    {
        public IEnumerable<ModuleViewModel> Modules { get; set; }

        public IEnumerable<ScreenViewModel> Screens { get; set; }
    }
}
