using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addforeignkeyserverscript : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Script_DestinationServerId",
                table: "Script",
                column: "DestinationServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Script_Server_DestinationServerId",
                table: "Script",
                column: "DestinationServerId",
                principalTable: "Server",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Script_Server_DestinationServerId",
                table: "Script");

            migrationBuilder.DropIndex(
                name: "IX_Script_DestinationServerId",
                table: "Script");
        }
    }
}
