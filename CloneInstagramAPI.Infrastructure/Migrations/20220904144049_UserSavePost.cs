using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloneInstagramAPI.Infrastructure.Migrations
{
    public partial class UserSavePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Save",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Save", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Save_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Save_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Save_PostId",
                table: "Save",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Save_UserId",
                table: "Save",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Save");
        }
    }
}
