using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4Tables.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClienteOrderEntity_Products_ProductId",
                table: "ClienteOrderEntity");

            migrationBuilder.DropIndex(
                name: "IX_ClienteOrderEntity_ProductId",
                table: "ClienteOrderEntity");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ClienteOrderEntity");

            migrationBuilder.CreateTable(
                name: "ClienteOrderEntityProductEntity",
                columns: table => new
                {
                    ClientOrdersId = table.Column<long>(type: "bigint", nullable: false),
                    ProductsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteOrderEntityProductEntity", x => new { x.ClientOrdersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ClienteOrderEntityProductEntity_ClienteOrderEntity_ClientOr~",
                        column: x => x.ClientOrdersId,
                        principalTable: "ClienteOrderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteOrderEntityProductEntity_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteOrderEntityProductEntity_ProductsId",
                table: "ClienteOrderEntityProductEntity",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteOrderEntityProductEntity");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "ClienteOrderEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ClienteOrderEntity_ProductId",
                table: "ClienteOrderEntity",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteOrderEntity_Products_ProductId",
                table: "ClienteOrderEntity",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
