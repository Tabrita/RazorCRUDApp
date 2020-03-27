using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorCRUDApp.Migrations
{
    public partial class ProductTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFile",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Categories");
        }
    }
}
