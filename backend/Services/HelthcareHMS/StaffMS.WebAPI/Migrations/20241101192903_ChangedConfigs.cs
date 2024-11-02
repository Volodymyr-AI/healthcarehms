using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffMS.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedConfigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_GlobalAdminEntity_GlobalAdminId",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlobalAdminEntity",
                table: "GlobalAdminEntity");

            migrationBuilder.RenameTable(
                name: "GlobalAdminEntity",
                newName: "GlobalAdmins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlobalAdmins",
                table: "GlobalAdmins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_GlobalAdmins_GlobalAdminId",
                table: "Departments",
                column: "GlobalAdminId",
                principalTable: "GlobalAdmins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_GlobalAdmins_GlobalAdminId",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlobalAdmins",
                table: "GlobalAdmins");

            migrationBuilder.RenameTable(
                name: "GlobalAdmins",
                newName: "GlobalAdminEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlobalAdminEntity",
                table: "GlobalAdminEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_GlobalAdminEntity_GlobalAdminId",
                table: "Departments",
                column: "GlobalAdminId",
                principalTable: "GlobalAdminEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
