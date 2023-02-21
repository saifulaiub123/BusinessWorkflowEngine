using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addScriptHistoryupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ScriptHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ScriptHistory");
        }
    }
}
