using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addScriptHistorytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_CreatedBy",
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

            migrationBuilder.CreateTable(
                name: "ScriptHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScriptId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Output = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScriptHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScriptHistory_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScriptHistory_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScriptHistory_Script_ScriptId",
                        column: x => x.ScriptId,
                        principalTable: "Script",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScriptHistory_CreatedBy",
                table: "ScriptHistory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptHistory_ScriptId",
                table: "ScriptHistory",
                column: "ScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptHistory_UpdatedBy",
                table: "ScriptHistory",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_CreatedBy",
                table: "ScriptUserPermission",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_CreatedBy",
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

            migrationBuilder.DropTable(
                name: "ScriptHistory");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptUserPermission_AspNetUsers_CreatedBy",
                table: "ScriptUserPermission",
                column: "CreatedBy",
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
    }
}
