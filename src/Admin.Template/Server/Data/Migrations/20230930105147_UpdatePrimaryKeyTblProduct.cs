using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Admin.Template.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePrimaryKeyTblProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CreateBy", "CreateByName", "Created", "Description", "IsDeleted", "ModifyBy", "ModifyByName", "ModifyDate", "Name", "Price", "Unit" },
                values: new object[,]
                {
                    { 1L, "Adidas", null, "Admin", new DateTime(2023, 9, 30, 17, 51, 46, 515, DateTimeKind.Local).AddTicks(7268), "text lorem ipsum dolor sit amet", false, null, "Admin", null, "Tech Toys", 1200m, "Nomal" },
                    { 2L, "Adidas", null, "Admin", new DateTime(2023, 9, 30, 17, 51, 46, 515, DateTimeKind.Local).AddTicks(7296), "text lorem ipsum dolor sit amet", false, null, "Admin", null, "Crazy Creations", 1200m, "Nomal" },
                    { 3L, "Adidas", null, "Admin", new DateTime(2023, 9, 30, 17, 51, 46, 515, DateTimeKind.Local).AddTicks(7302), "text lorem ipsum dolor sit amet", false, null, "Admin", null, "Innovative Imaginings", 1200m, "Nomal" },
                    { 4L, "Adidas", null, "Admin", new DateTime(2023, 9, 30, 17, 51, 46, 515, DateTimeKind.Local).AddTicks(7307), "text lorem ipsum dolor sit amet", false, null, "Admin", null, "Design Den", 1200m, "Nomal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
