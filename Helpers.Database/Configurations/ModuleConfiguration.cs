using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpers.Database.Configurations
{
    public class ModuleConfiguration : IEntityTypeConfiguration<ModuleModel>
    {
        public void Configure(EntityTypeBuilder<ModuleModel> builder)
        {
            builder.Property(module => module.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(module => module.Name).IsUnique();

            builder.Property(module => module.Description).IsRequired().HasMaxLength(100);

            builder.HasIndex(module => module.Url).IsUnique();
            builder.Property(module => module.Url).IsRequired().HasMaxLength(50);

            builder.Property(module => module.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(module => module.UpdatedDate).HasDefaultValueSql("getdate()");

            builder.HasOne(module => module.Status).WithMany(status => status.Modules).HasForeignKey(module => module.StatusId).IsRequired();

            builder.HasData(new ModuleModel
            {
                Id = "d6c1a4a2-4f70-4ce1-9dd7-87cad50a8ea7",
                Name = "Seguridad",
                Description = "Este es el modulo de seguridad",
                Url = "security",
                StatusId = (int)Statuses.Active
            });
        }
    }
}
