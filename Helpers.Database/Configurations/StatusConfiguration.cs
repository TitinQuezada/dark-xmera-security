using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpers.Database.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<StatusModel>
    {
        public void Configure(EntityTypeBuilder<StatusModel> builder)
        {
            builder.Property(status => status.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(status => status.Name).IsUnique();

            builder.Property(status => status.Description).IsRequired().HasMaxLength(100);

            builder.HasData(
                new StatusModel { Id = 1 , Name = "Active" , Description = "Active record"},
                     new StatusModel { Id = 2, Name = "Inactive", Description = "Inactive record" });
        }
    }
}
