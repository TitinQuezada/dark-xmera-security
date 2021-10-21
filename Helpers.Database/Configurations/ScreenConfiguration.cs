using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpers.Database.Configurations
{
    public class ScreenConfiguration : IEntityTypeConfiguration<ScreenModel>
    {
        public void Configure(EntityTypeBuilder<ScreenModel> builder)
        {
            builder.Property(screen => screen.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(screen => screen.Name).IsUnique();

            builder.Property(screen => screen.Description).IsRequired().HasMaxLength(100);

            builder.HasIndex(screen => screen.Url).IsUnique();
            builder.Property(screen => screen.Url).IsRequired().HasMaxLength(50);

            builder.HasOne(screen => screen.Status).WithMany(status => status.Screens).HasForeignKey(screen => screen.StatusId).IsRequired();
            builder.HasOne(screen => screen.Module).WithMany(module => module.Screens).HasForeignKey(screen => screen.ModuleId).IsRequired();
        }
    }
}
