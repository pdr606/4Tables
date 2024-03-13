using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4Tables.Migrations
{
    /// <inheritdoc />
    public partial class addbaseentityinrestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_At",
                table: "Restaurants",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Updated_At",
                table: "Restaurants");
        }
    }
}
