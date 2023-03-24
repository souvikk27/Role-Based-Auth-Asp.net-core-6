using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleAuth.Migrations
{
    public partial class addauthentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_rolesRoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_rolesRoleId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_rolesRoleId",
                table: "Users",
                column: "rolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_rolesRoleId",
                table: "Users",
                column: "rolesRoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
