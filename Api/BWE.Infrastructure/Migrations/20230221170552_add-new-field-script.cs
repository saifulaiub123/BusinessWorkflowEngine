using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addnewfieldscript : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SendTo",
                table: "Script",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendTo",
                table: "Script");
        }
    }
}
