using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addScriptUserPermissiontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Script",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ScriptPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScriptId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScriptPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScriptPermission_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScriptPermission_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScriptPermission_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScriptPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScriptPermission_Script_ScriptId",
                        column: x => x.ScriptId,
                        principalTable: "Script",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScriptPermission_CreatedBy",
                table: "ScriptPermission",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptPermission_PermissionId",
                table: "ScriptPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptPermission_ScriptId",
                table: "ScriptPermission",
                column: "ScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptPermission_UpdatedBy",
                table: "ScriptPermission",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptPermission_UserId",
                table: "ScriptPermission",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScriptPermission");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Script");
        }
    }
}
