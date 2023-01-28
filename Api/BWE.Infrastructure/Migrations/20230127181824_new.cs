using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_CreatedBy",
                table: "ScriptUserPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_UpdatedBy",
                table: "ScriptUserPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_UserId",
                table: "ScriptUserPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptUserPermission_Permission_PermissionId",
                table: "ScriptUserPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptUserPermission_Script_ScriptId",
                table: "ScriptUserPermission");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_CreatedBy",
                table: "ScriptUserPermission",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_UpdatedBy",
                table: "ScriptUserPermission",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_UserId",
                table: "ScriptUserPermission",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptUserPermission_Permission_PermissionId",
                table: "ScriptUserPermission",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptUserPermission_Script_ScriptId",
                table: "ScriptUserPermission",
                column: "ScriptId",
                principalTable: "Script",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_CreatedBy",
                table: "ScriptUserPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_UpdatedBy",
                table: "ScriptUserPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_UserId",
                table: "ScriptUserPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptUserPermission_Permission_PermissionId",
                table: "ScriptUserPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptUserPermission_Script_ScriptId",
                table: "ScriptUserPermission");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_CreatedBy",
                table: "ScriptUserPermission",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_UpdatedBy",
                table: "ScriptUserPermission",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_UserId",
                table: "ScriptUserPermission",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptUserPermission_Permission_PermissionId",
                table: "ScriptUserPermission",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptUserPermission_Script_ScriptId",
                table: "ScriptUserPermission",
                column: "ScriptId",
                principalTable: "Script",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
