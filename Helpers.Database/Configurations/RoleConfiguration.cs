using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpers.Database.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleModel>
    {
        public void Configure(EntityTypeBuilder<RoleModel> builder)
        {
            builder.Property(role => role.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(role => role.Name).IsUnique();

            builder.Property(role => role.Description).IsRequired().HasMaxLength(100);

            builder.Property(role => role.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(role => role.UpdatedDate).HasDefaultValueSql("getdate()");

            builder.HasOne(role => role.Status).WithMany(status => status.Roles).HasForeignKey(role => role.StatusId).IsRequired();

            builder.HasData(new RoleModel {
                Id = "108d0430-3a5b-423b-a23a-393d35e681f4" ,
                Name = "Admin" ,
                Description = "Este es el rol con todos los permisos" ,
                StatusId = (int)Statuses.Active
            });
        }
    }
}
