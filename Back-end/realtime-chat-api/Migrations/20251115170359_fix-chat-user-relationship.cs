using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace realtime_chat_api.Migrations
{
    /// <inheritdoc />
    public partial class fixchatuserrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_AdminId",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Chats",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_AdminId",
                table: "Chats",
                newName: "IX_Chats_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_UserId",
                table: "Chats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_UserId",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Chats",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_UserId",
                table: "Chats",
                newName: "IX_Chats_AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_AdminId",
                table: "Chats",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
