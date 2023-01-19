using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addforeignkeyserverscriptapplicationuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Server_CreatedBy",
                table: "Server",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Server_UpdatedBy",
                table: "Server",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Script_CreatedBy",
                table: "Script",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Script_UpdatedBy",
                table: "Script",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_CreatedBy",
                table: "Permission",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_UpdatedBy",
                table: "Permission",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_AspNetUsers_CreatedBy",
                table: "Permission",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_AspNetUsers_UpdatedBy",
                table: "Permission",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Script_AspNetUsers_CreatedBy",
                table: "Script",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Script_AspNetUsers_UpdatedBy",
                table: "Script",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Server_AspNetUsers_CreatedBy",
                table: "Server",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Server_AspNetUsers_UpdatedBy",
                table: "Server",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_AspNetUsers_CreatedBy",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_AspNetUsers_UpdatedBy",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Script_AspNetUsers_CreatedBy",
                table: "Script");

            migrationBuilder.DropForeignKey(
                name: "FK_Script_AspNetUsers_UpdatedBy",
                table: "Script");

            migrationBuilder.DropForeignKey(
                name: "FK_Server_AspNetUsers_CreatedBy",
                table: "Server");

            migrationBuilder.DropForeignKey(
                name: "FK_Server_AspNetUsers_UpdatedBy",
                table: "Server");

            migrationBuilder.DropIndex(
                name: "IX_Server_CreatedBy",
                table: "Server");

            migrationBuilder.DropIndex(
                name: "IX_Server_UpdatedBy",
                table: "Server");

            migrationBuilder.DropIndex(
                name: "IX_Script_CreatedBy",
                table: "Script");

            migrationBuilder.DropIndex(
                name: "IX_Script_UpdatedBy",
                table: "Script");

            migrationBuilder.DropIndex(
                name: "IX_Permission_CreatedBy",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Permission_UpdatedBy",
                table: "Permission");
        }
    }
}
