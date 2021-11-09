using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpers.Database.Configurations
{
    public class RoleScreenModelConfiguration : IEntityTypeConfiguration<RoleScreenModel>
    {
        public void Configure(EntityTypeBuilder<RoleScreenModel> builder)
        {
            builder.HasKey(moduleRole => new { moduleRole.ScreenId, moduleRole.RoleId });

            builder
                .HasOne(moduleRole => moduleRole.Screen)
                .WithMany(screen => screen.RoleScreens)
                .HasForeignKey(moduleRole => moduleRole.ScreenId);


            builder
              .HasOne(moduleRole => moduleRole.Role)
              .WithMany(role => role.RoleScreens)
              .HasForeignKey(moduleRole => moduleRole.RoleId);

            builder.HasData(new RoleScreenModel
            {
                RoleId = "108d0430-3a5b-423b-a23a-393d35e681f4",
                ScreenId = "c29c6db6-41e4-4be9-b7e9-c2432241641c",
                StatusId = (int)Statuses.Active
            },
            new RoleScreenModel
            {
                RoleId = "108d0430-3a5b-423b-a23a-393d35e681f4",
                ScreenId = "6082c3a3-be96-4f63-8c1b-24b4f8de38f0",
                StatusId = (int)Statuses.Active
            },
             new RoleScreenModel
             {
                 RoleId = "108d0430-3a5b-423b-a23a-393d35e681f4",
                 ScreenId = "8e0a4306-f3fd-43f4-8ae0-c1f68bcd2d9b",
                 StatusId = (int)Statuses.Active
             });
        }
    }
}
