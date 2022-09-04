using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerApp.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burgers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    HasFries = table.Column<bool>(type: "bit", nullable: false),
                    HasBBQSauce = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burgers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    TimeOrdered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BurgerOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BurgerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurgerOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BurgerOrder_Burgers_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "Burgers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BurgerOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Burgers",
                columns: new[] { "Id", "Description", "HasBBQSauce", "HasFries", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Beef Patty, Onions, Tomatoes, Pickles, Lettuce, Ketchup, Mayo, Mustard", false, false, "https://imagesvc.meredithcorp.io/v3/mm/image?q=60&c=sc&poi=%5B1000%2C700%5D&w=2000&h=1000&url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2022%2F03%2F11%2F49404-Juiciest-Hamburgers-Ever-mfs-052.jpg", "Hamburger", 180.0 },
                    { 2, "Beef Patty, Cheddar Cheese, Grilled Onions & Tomatoes, Pickles, Lettuce, Ketchup, Mayo, Mustard", false, false, "https://dam.kraftheinzcompany.com/adaptivemedia/rendition/195370-3000x2000.jpg?id=093000b4880e99e6cd87fa511235a789145c5a0a&ht=2000&wd=3000&version=1&clid=pim", "Cheeseburger", 200.0 },
                    { 3, "Beef Patty, Cheddar Cheese, Beef Bacon, Grilled Onions & Tomatoes, Pickles, Lettuce, Ketchup, Mayo, Mustard", false, false, "https://media.istockphoto.com/photos/bacon-burger-picture-id520215281?k=20&m=520215281&s=170667a&w=0&h=KcEFpxMByOgezAt21h9-mEQ-4bSD7aLWb8n1FSwBAxk=", "Baconburger", 230.0 },
                    { 4, "Double Beef Patty, Double Cheddar Cheese, Beef Bacon, Grilled Onions & Tomatoes, Pickles, Lettuce, Mayo, BBQ Sauce", false, false, "https://www.kitchensanctuary.com/wp-content/uploads/2021/05/Double-Cheeseburger-square-FS-42.jpg", "MegaBurger", 260.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsActive", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "RadisaniHillsBoulevard bb", "ilija@mitev.com", "Ilija", true, "Mitev", "1234" },
                    { 2, "Vlajko street bb", "pink@panther.com", "Pink", true, "Panther", "1234" },
                    { 3, "Club Soda bb.", "minnie@mouse.com", "Minnie", true, "Mouse", "1234" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "IsDelivered", "Location", "PaymentMethod", "TimeOrdered", "UserId" },
                values: new object[] { 1, false, "Skopje North", 1, new DateTime(2022, 9, 3, 12, 10, 17, 445, DateTimeKind.Local).AddTicks(4769), 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "IsDelivered", "Location", "PaymentMethod", "TimeOrdered", "UserId" },
                values: new object[] { 2, true, "Skopje South", 2, new DateTime(2022, 9, 2, 12, 10, 17, 445, DateTimeKind.Local).AddTicks(4806), 3 });

            migrationBuilder.InsertData(
                table: "BurgerOrder",
                columns: new[] { "Id", "BurgerId", "OrderId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "BurgerOrder",
                columns: new[] { "Id", "BurgerId", "OrderId" },
                values: new object[] { 2, 4, 1 });

            migrationBuilder.InsertData(
                table: "BurgerOrder",
                columns: new[] { "Id", "BurgerId", "OrderId" },
                values: new object[] { 3, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_BurgerOrder_BurgerId",
                table: "BurgerOrder",
                column: "BurgerId");

            migrationBuilder.CreateIndex(
                name: "IX_BurgerOrder_OrderId",
                table: "BurgerOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BurgerOrder");

            migrationBuilder.DropTable(
                name: "Burgers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
