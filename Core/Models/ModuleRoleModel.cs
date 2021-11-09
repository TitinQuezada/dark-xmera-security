namespace Core.Models
{
    public sealed class ModuleRoleModel : BaseModel
    {
        public string ModuleId { get; set; }
        public ModuleModel Module { get; set; }

        public string RoleId { get; set; }
        public RoleModel Role { get; set; }
    }
}
