using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Helpers.Database.Configurations
{
    public class ModuleConfiguration : IEntityTypeConfiguration<ModuleModel>
    {
        public void Configure(EntityTypeBuilder<ModuleModel> builder)
        {
            builder.Property(module => module.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(module => module.Name).IsUnique();

            builder.Property(module => module.Description).IsRequired().HasMaxLength(100);

            builder.HasIndex(screen => screen.Url).IsUnique();
            builder.Property(screen => screen.Url).IsRequired().HasMaxLength(50);

            builder.Property(screen => screen.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(screen => screen.UpdatedDate).HasDefaultValueSql("getdate()");


            builder.HasData(new ModuleModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Security",
                Description = "This is a security module",
                Url = "security",
                Status = null
            });
        }
    }
}
