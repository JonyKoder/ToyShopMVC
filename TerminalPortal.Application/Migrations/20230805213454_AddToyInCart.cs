using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerminalPortal.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddToyInCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Carts_CartId",
                table: "Toys");

            migrationBuilder.DropIndex(
                name: "IX_Toys_CartId",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Toys");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ToyId",
                table: "Carts",
                column: "ToyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Toys_ToyId",
                table: "Carts",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Toys_ToyId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ToyId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Toys",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toys_CartId",
                table: "Toys",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Carts_CartId",
                table: "Toys",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
