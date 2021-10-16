using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpers.Database.Configurations
{
    public class ActionConfiguration : IEntityTypeConfiguration<ActionModel>
    {
        public void Configure(EntityTypeBuilder<ActionModel> builder)
        {
            builder.Property(module => module.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(module => module.Name).IsUnique();

            builder.Property(module => module.Description).IsRequired().HasMaxLength(100);
        }
    }
}
