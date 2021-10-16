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
        }
    }
}
