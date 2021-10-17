using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpers.Database.Migrations
{
    public partial class addmoduleandscreenurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Screens",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Modules",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Modules",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Modules",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Description", "Name", "StatusId", "Url" },
                values: new object[] { "7aaf6fb5-b077-47a2-b18b-cf04be468171", "This is a security module", "Security", 1, "security" });

            migrationBuilder.CreateIndex(
                name: "IX_Screens_Url",
                table: "Screens",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_Url",
                table: "Modules",
                column: "Url",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Screens_Url",
                table: "Screens");

            migrationBuilder.DropIndex(
                name: "IX_Modules_Url",
                table: "Modules");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "7aaf6fb5-b077-47a2-b18b-cf04be468171");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Modules");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Modules",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Modules",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");
        }
    }
}
