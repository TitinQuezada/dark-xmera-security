using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpers.Database.Configurations
{
    public class ModuleRolesConfiguration : IEntityTypeConfiguration<ModuleRoleModel>
    {
        public void Configure(EntityTypeBuilder<ModuleRoleModel> builder)
        {
            builder.HasKey(moduleRole => new { moduleRole.ModuleId, moduleRole.RoleId });

            builder
                .HasOne(moduleRole => moduleRole.Module)
                .WithMany(module => module.ModuleRoles)
                .HasForeignKey(moduleRole => moduleRole.ModuleId);


            builder
              .HasOne(moduleRole => moduleRole.Role)
              .WithMany(role => role.ModuleRoles)
              .HasForeignKey(moduleRole => moduleRole.RoleId);


            builder.HasData(new ModuleRoleModel
            {
                RoleId = "108d0430-3a5b-423b-a23a-393d35e681f4",
                ModuleId = "d6c1a4a2-4f70-4ce1-9dd7-87cad50a8ea7",
                StatusId = (int)Statuses.Active
            });
        }
    }
}
