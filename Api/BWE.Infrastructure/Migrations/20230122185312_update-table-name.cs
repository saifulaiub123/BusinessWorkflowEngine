using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScriptPermission_AspNetUsers_CreatedBy",
                table: "ScriptPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptPermission_AspNetUsers_UpdatedBy",
                table: "ScriptPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptPermission_AspNetUsers_UserId",
                table: "ScriptPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptPermission_Permission_PermissionId",
                table: "ScriptPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptPermission_Script_ScriptId",
                table: "ScriptPermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScriptPermission",
                table: "ScriptPermission");

            migrationBuilder.RenameTable(
                name: "ScriptPermission",
                newName: "ScriptUserPermission");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptPermission_UserId",
                table: "ScriptUserPermission",
                newName: "IX_ScriptUserPermission_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptPermission_UpdatedBy",
                table: "ScriptUserPermission",
                newName: "IX_ScriptUserPermission_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptPermission_ScriptId",
                table: "ScriptUserPermission",
                newName: "IX_ScriptUserPermission_ScriptId");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptPermission_PermissionId",
                table: "ScriptUserPermission",
                newName: "IX_ScriptUserPermission_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptPermission_CreatedBy",
                table: "ScriptUserPermission",
                newName: "IX_ScriptUserPermission_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScriptUserPermission",
                table: "ScriptUserPermission",
                column: "Id");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScriptUserPermission",
                table: "ScriptUserPermission");

            migrationBuilder.RenameTable(
                name: "ScriptUserPermission",
                newName: "ScriptPermission");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptUserPermission_UserId",
                table: "ScriptPermission",
                newName: "IX_ScriptPermission_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptUserPermission_UpdatedBy",
                table: "ScriptPermission",
                newName: "IX_ScriptPermission_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptUserPermission_ScriptId",
                table: "ScriptPermission",
                newName: "IX_ScriptPermission_ScriptId");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptUserPermission_PermissionId",
                table: "ScriptPermission",
                newName: "IX_ScriptPermission_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptUserPermission_CreatedBy",
                table: "ScriptPermission",
                newName: "IX_ScriptPermission_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScriptPermission",
                table: "ScriptPermission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptPermission_AspNetUsers_CreatedBy",
                table: "ScriptPermission",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptPermission_AspNetUsers_UpdatedBy",
                table: "ScriptPermission",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptPermission_AspNetUsers_UserId",
                table: "ScriptPermission",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptPermission_Permission_PermissionId",
                table: "ScriptPermission",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptPermission_Script_ScriptId",
                table: "ScriptPermission",
                column: "ScriptId",
                principalTable: "Script",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
