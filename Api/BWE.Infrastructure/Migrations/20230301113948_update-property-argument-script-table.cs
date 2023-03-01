using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatepropertyargumentscripttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Argument",
                table: "Script",
                newName: "Parameter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Parameter",
                table: "Script",
                newName: "Argument");
        }
    }
}
