using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Template.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2023, 10, 4, 18, 18, 36, 640, DateTimeKind.Local).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2023, 10, 4, 18, 18, 36, 640, DateTimeKind.Local).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2023, 10, 4, 18, 18, 36, 640, DateTimeKind.Local).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTime(2023, 10, 4, 18, 18, 36, 640, DateTimeKind.Local).AddTicks(4361));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2023, 9, 30, 17, 51, 46, 515, DateTimeKind.Local).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2023, 9, 30, 17, 51, 46, 515, DateTimeKind.Local).AddTicks(7296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2023, 9, 30, 17, 51, 46, 515, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTime(2023, 9, 30, 17, 51, 46, 515, DateTimeKind.Local).AddTicks(7307));
        }
    }
}
