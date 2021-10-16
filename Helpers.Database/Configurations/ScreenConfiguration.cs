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
        }
    }
}
