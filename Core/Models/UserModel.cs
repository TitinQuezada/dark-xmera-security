namespace Core.Models
{
    public sealed class UserModel : BaseModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public RoleModel Role { get; set; }
    }
}
