using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpers.Database.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.Property(user => user.UserName).IsRequired().HasMaxLength(20);
            builder.HasIndex(user => user.UserName).IsUnique();

            builder.Property(user => user.Password).IsRequired();

            builder.Property(user => user.Email).IsRequired();
            builder.HasIndex(user => user.Email).IsUnique();

            builder.Property(user => user.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(user => user.UpdatedDate).HasDefaultValueSql("getdate()");

            builder.HasOne(user => user.Role).WithMany(role => role.Users).HasForeignKey(user => user.RoleId).IsRequired();
            builder.HasOne(user => user.Status).WithMany(status => status.Users).HasForeignKey(user => user.StatusId).IsRequired();

            builder.HasData(new UserModel { 
                Id = "0dafe045-02ca-4e57-b4b8-b74bd4675dad",
                UserName = "admin",
                Email = "admin258@yopmail.com",
                RoleId = "108d0430-3a5b-423b-a23a-393d35e681f4",
                Password = "21232f297a57a5a743894a0e4a801fc3",
                StatusId = (int)Statuses.Active
            });
        }
    }
}
