namespace Core.ViewModels.Screen
{
    public class ScreenCreateOrEditViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string ModuleId { get; set; }
    }
}
