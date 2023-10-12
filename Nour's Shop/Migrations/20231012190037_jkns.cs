using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nour_Shop.Migrations
{
    /// <inheritdoc />
    public partial class jkns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Times",
                table: "products",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "times",
                table: "orders",
                type: "numeric(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Times",
                table: "products");

            migrationBuilder.AlterColumn<decimal>(
                name: "times",
                table: "orders",
                type: "numeric(18,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,0)",
                oldNullable: true);
        }
    }
}
