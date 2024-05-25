using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello.Migrations
{
    public partial class BlogsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "Surprizes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "SurprizeLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "Sliders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "SliderInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "ProductImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "Positions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "Experts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Description", "Image", "SoftDelete", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 7, 13, 40, 14, 192, DateTimeKind.Local).AddTicks(4050), "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", "blog-feature-img-1.jpg", false, "Flower Power" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Description", "Image", "SoftDelete", "Title" },
                values: new object[] { 2, new DateTime(2024, 5, 7, 13, 40, 14, 192, DateTimeKind.Local).AddTicks(4062), "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", "blog-feature-img-3.jpg", false, "Local Florists" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Description", "Image", "SoftDelete", "Title" },
                values: new object[] { 3, new DateTime(2024, 5, 7, 13, 40, 14, 192, DateTimeKind.Local).AddTicks(4063), "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", "blog-feature-img-4.jpg", false, "Flower Beauty" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "Surprizes");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "SurprizeLists");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "SliderInfos");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "Experts");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "Categories");
        }
    }
}
