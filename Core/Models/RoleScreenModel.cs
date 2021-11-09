namespace Core.Models
{
    public sealed class RoleScreenModel : BaseModel
    {
        public string ScreenId { get; set; }
        public ScreenModel Screen { get; set; }

        public string RoleId { get; set; }
        public RoleModel Role { get; set; }
    }
}
