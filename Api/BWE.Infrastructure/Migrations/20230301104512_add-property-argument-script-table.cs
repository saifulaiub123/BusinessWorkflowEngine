using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addpropertyargumentscripttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Argument",
                table: "Script",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Argument",
                table: "Script");
        }
    }
}
