using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Helpers.Database
{
    public class DarkXmeraSecurityDbContext : DbContext
    {
        public DarkXmeraSecurityDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<RoleModel> Roles { get; set; }

        public DbSet<ModuleModel> Modules { get; set; }

        public DbSet<ScreenModel> Screens { get; set; }

        public DbSet<ActionModel> Actions { get; set; }

        public DbSet<StatusModel> Statuses { get; set; }

        public DbSet<ModuleRoleModel> ModuleRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(DarkXmeraSecurityDbContext)));



            base.OnModelCreating(modelBuilder);
        }
    }
}
