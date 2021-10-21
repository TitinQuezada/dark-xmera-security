using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpers.Database.Configurations
{
    public class ActionConfiguration : IEntityTypeConfiguration<ActionModel>
    {
        public void Configure(EntityTypeBuilder<ActionModel> builder)
        {
            builder.Property(action => action.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(action => action.Name).IsUnique();

            builder.Property(action => action.Description).IsRequired().HasMaxLength(100);

            builder.HasOne(action => action.Status).WithMany(status => status.Actions).HasForeignKey(action => action.StatusId).IsRequired();
        }
    }
}
