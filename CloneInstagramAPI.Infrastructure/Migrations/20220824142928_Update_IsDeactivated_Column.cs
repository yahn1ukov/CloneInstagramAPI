using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloneInstagramAPI.Infrastructure.Migrations
{
    public partial class Update_IsDeactivated_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "IsDeactived",
                table: "Users",
                newName: "IsDeactivated");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "IsDeactivated",
                table: "Users",
                newName: "IsDeactived");
        }
    }
}
