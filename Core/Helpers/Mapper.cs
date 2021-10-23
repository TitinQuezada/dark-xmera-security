using Core.Models;
using Core.ViewModels.Module;
using Core.ViewModels.Screen;

namespace Core.Helpers
{
    public static class Mapper
    {
        public static ModuleViewModel ToViewModel(this ModuleModel module)
        {
            return new ModuleViewModel
            {
                Id = module.Id,
                Name = module.Name,
                Description = module.Description,
                Url = module.Url,
                CreatedDate = module.CreatedDate,
                UpdatedDate = module.UpdatedDate
            };
        }

        public static ScreenViewModel ToViewModel(this ScreenModel module)
        {
            return new ScreenViewModel
            {
                Id = module.Id,
                Name = module.Name,
                Description = module.Description,
                Url = module.Url,
                CreatedDate = module.CreatedDate,
                UpdatedDate = module.UpdatedDate
            };
        }
    }
}
