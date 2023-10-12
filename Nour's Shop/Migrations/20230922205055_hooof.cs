using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nour_Shop.Migrations
{
    /// <inheritdoc />
    public partial class hooof : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    times = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    payment = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    remainingtime = table.Column<decimal>(name: "remaining time", type: "numeric(18,0)", nullable: true),
                    Uid = table.Column<int>(type: "int", nullable: true),
                    Pid = table.Column<int>(type: "int", nullable: true),
                    orderdate = table.Column<DateTime>(name: "order date", type: "date", nullable: true),
                    deliverydate = table.Column<DateTime>(name: "delivery date", type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    catogary = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    description = table.Column<string>(type: "ntext", nullable: true),
                    image = table.Column<string>(type: "ntext", nullable: false),
                    brand = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Oid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_orders",
                        column: x => x.Oid,
                        principalTable: "orders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    UserName = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Oid = table.Column<int>(type: "int", nullable: true),
                    sex = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_orders",
                        column: x => x.Oid,
                        principalTable: "orders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_Pid",
                table: "orders",
                column: "Pid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_Uid",
                table: "orders",
                column: "Uid");

            migrationBuilder.CreateIndex(
                name: "IX_products_Oid",
                table: "products",
                column: "Oid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Oid",
                table: "Users",
                column: "Oid");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Users",
                table: "orders",
                column: "Uid",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products",
                table: "orders",
                column: "Pid",
                principalTable: "products",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Users",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_products",
                table: "orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
