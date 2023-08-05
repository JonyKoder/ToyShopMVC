using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerminalPortal.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToyImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Toys",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Toys");
        }
    }
}
