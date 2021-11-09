using Core.Enums;
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

            builder.Property(screen => screen.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(screen => screen.UpdatedDate).HasDefaultValueSql("getdate()");

            builder.HasOne(screen => screen.Status).WithMany(status => status.Screens).HasForeignKey(screen => screen.StatusId).IsRequired();
            builder.HasOne(screen => screen.Module).WithMany(module => module.Screens).HasForeignKey(screen => screen.ModuleId).IsRequired();


            builder.HasData(new ScreenModel
            {
                Id = "c29c6db6-41e4-4be9-b7e9-c2432241641c",
                Name = "Roles",
                Description = "Pantalla de configuración de roles",
                ModuleId = "d6c1a4a2-4f70-4ce1-9dd7-87cad50a8ea7",
                Url = "roles",
                StatusId = (int)Statuses.Active
            },
            new ScreenModel
            {
                Id = "6082c3a3-be96-4f63-8c1b-24b4f8de38f0",
                Name = "Modules",
                Description = "Pantalla de configuración de modulos",
                ModuleId = "d6c1a4a2-4f70-4ce1-9dd7-87cad50a8ea7",
                Url = "modules",
                StatusId = (int)Statuses.Active
            },
             new ScreenModel
             {
                 Id = "8e0a4306-f3fd-43f4-8ae0-c1f68bcd2d9b",
                 Name = "Screens",
                 Description = "Pantalla de configuración de pantallas",
                 ModuleId = "d6c1a4a2-4f70-4ce1-9dd7-87cad50a8ea7",
                 Url = "screens",
                 StatusId = (int)Statuses.Active
             });
        }
    }
}
