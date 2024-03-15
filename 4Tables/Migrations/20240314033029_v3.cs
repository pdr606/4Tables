using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4Tables.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClienteOrderEntity_Orders_OrderId",
                table: "ClienteOrderEntity");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "PriceWithGarcomFee",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "Observation",
                table: "Orders");

            migrationBuilder.AddColumn<long>(
                name: "ClienteOrderId",
                table: "Tables",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Orders",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceWithGarcomFee",
                table: "Orders",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Orders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "ClienteOrderEntity",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "ClienteOrderEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tables_ClienteOrderId",
                table: "Tables",
                column: "ClienteOrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteOrderEntity_Orders_OrderId",
                table: "ClienteOrderEntity",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_ClienteOrderEntity_ClienteOrderId",
                table: "Tables",
                column: "ClienteOrderId",
                principalTable: "ClienteOrderEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClienteOrderEntity_Orders_OrderId",
                table: "ClienteOrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_ClienteOrderEntity_ClienteOrderId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_ClienteOrderId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "ClienteOrderId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PriceWithGarcomFee",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "ClienteOrderEntity");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Tables",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceWithGarcomFee",
                table: "Tables",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "ClienteOrderEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteOrderEntity_Orders_OrderId",
                table: "ClienteOrderEntity",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
