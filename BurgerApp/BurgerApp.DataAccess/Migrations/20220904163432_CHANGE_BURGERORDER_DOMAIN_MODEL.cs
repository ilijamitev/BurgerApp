using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerApp.DataAccess.Migrations
{
    public partial class CHANGE_BURGERORDER_DOMAIN_MODEL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOrdered",
                value: new DateTime(2022, 9, 4, 18, 34, 32, 122, DateTimeKind.Local).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOrdered",
                value: new DateTime(2022, 9, 3, 18, 34, 32, 122, DateTimeKind.Local).AddTicks(5246));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
