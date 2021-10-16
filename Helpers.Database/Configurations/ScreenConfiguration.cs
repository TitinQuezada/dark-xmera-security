using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpers.Database.Configurations
{
    public class ScreenConfiguration : IEntityTypeConfiguration<ScreenModel>
    {
        public void Configure(EntityTypeBuilder<ScreenModel> builder)
        {
            builder.Property(module => module.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(module => module.Name).IsUnique();

            builder.Property(module => module.Description).IsRequired().HasMaxLength(100);
        }
    }
}
