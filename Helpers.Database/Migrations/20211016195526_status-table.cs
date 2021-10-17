using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpers.Database.Migrations
{
    public partial class statustable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Screens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Modules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Actions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Active record", "Active" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Inactive record", "Inactive" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusId",
                table: "Users",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Screens_StatusId",
                table: "Screens",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_StatusId",
                table: "Roles",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_StatusId",
                table: "Modules",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_StatusId",
                table: "Actions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_Name",
                table: "Statuses",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Statuses_StatusId",
                table: "Actions",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Statuses_StatusId",
                table: "Modules",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Statuses_StatusId",
                table: "Roles",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Screens_Statuses_StatusId",
                table: "Screens",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Statuses_StatusId",
                table: "Users",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Statuses_StatusId",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Statuses_StatusId",
                table: "Modules");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Statuses_StatusId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Screens_Statuses_StatusId",
                table: "Screens");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Statuses_StatusId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Users_StatusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Screens_StatusId",
                table: "Screens");

            migrationBuilder.DropIndex(
                name: "IX_Roles_StatusId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Modules_StatusId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Actions_StatusId",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Actions");
        }
    }
}
