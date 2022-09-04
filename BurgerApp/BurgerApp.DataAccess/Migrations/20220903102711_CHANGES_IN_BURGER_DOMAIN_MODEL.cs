using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerApp.DataAccess.Migrations
{
    public partial class CHANGES_IN_BURGER_DOMAIN_MODEL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBBQSauce",
                table: "Burgers");

            migrationBuilder.DropColumn(
                name: "HasFries",
                table: "Burgers");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOrdered",
                value: new DateTime(2022, 9, 3, 12, 27, 10, 849, DateTimeKind.Local).AddTicks(5005));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOrdered",
                value: new DateTime(2022, 9, 2, 12, 27, 10, 849, DateTimeKind.Local).AddTicks(5045));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasBBQSauce",
                table: "Burgers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasFries",
                table: "Burgers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOrdered",
                value: new DateTime(2022, 9, 3, 12, 10, 17, 445, DateTimeKind.Local).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOrdered",
                value: new DateTime(2022, 9, 2, 12, 10, 17, 445, DateTimeKind.Local).AddTicks(4806));
        }
    }
}
