using BurgerApp.Domain.Enums;
using BurgerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.DataAccess.Data
{
    public static class DataSeed
    {
        public static void InsertDataInDb(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burger>()
                .HasData(
                new Burger
                {
                    Id = 1,
                    Name = "Hamburger",
                    Description = "Beef Patty, Onions, Tomatoes, Pickles, Lettuce, Ketchup, Mayo, Mustard",
                    ImageUrl = @"https://imagesvc.meredithcorp.io/v3/mm/image?q=60&c=sc&poi=%5B1000%2C700%5D&w=2000&h=1000&url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2022%2F03%2F11%2F49404-Juiciest-Hamburgers-Ever-mfs-052.jpg",
                    Price = 180
                },
                new Burger
                {
                    Id = 2,
                    Name = "Cheeseburger",
                    Description = "Beef Patty, Cheddar Cheese, Grilled Onions & Tomatoes, Pickles, Lettuce, Ketchup, Mayo, Mustard",
                    ImageUrl = @"https://dam.kraftheinzcompany.com/adaptivemedia/rendition/195370-3000x2000.jpg?id=093000b4880e99e6cd87fa511235a789145c5a0a&ht=2000&wd=3000&version=1&clid=pim",
                    Price = 200
                },
                new Burger
                {
                    Id = 3,
                    Name = "Baconburger",
                    Description = "Beef Patty, Cheddar Cheese, Beef Bacon, Grilled Onions & Tomatoes, Pickles, Lettuce, Ketchup, Mayo, Mustard",
                    ImageUrl = @"https://media.istockphoto.com/photos/bacon-burger-picture-id520215281?k=20&m=520215281&s=170667a&w=0&h=KcEFpxMByOgezAt21h9-mEQ-4bSD7aLWb8n1FSwBAxk=",
                    Price = 230
                },
                new Burger
                {
                    Id = 4,
                    Name = "MegaBurger",
                    Description = "Double Beef Patty, Double Cheddar Cheese, Beef Bacon, Grilled Onions & Tomatoes, Pickles, Lettuce, Mayo, BBQ Sauce",
                    ImageUrl = @"https://www.kitchensanctuary.com/wp-content/uploads/2021/05/Double-Cheeseburger-square-FS-42.jpg",
                    Price = 260
                });

            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Ilija",
                    LastName = "Mitev",
                    Address = "RadisaniHillsBoulevard bb",
                    Email = "ilija@mitev.com",
                    Password = "1234"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Pink",
                    LastName = "Panther",
                    Address = "Vlajko street bb",
                    Email = "pink@panther.com",
                    Password = "1234"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Minnie",
                    LastName = "Mouse",
                    Address = "Club Soda bb.",
                    Email = "minnie@mouse.com",
                    Password = "1234"
                });

            modelBuilder.Entity<Order>()
                .HasData(
                new Order
                {
                    Id = 1,
                    PaymentMethod = PaymentMethod.Cash,
                    Location = "Skopje North",
                    IsDelivered = false,
                    UserId = 1,
                    TimeOrdered = DateTime.Now
                },
                new Order
                {
                    Id = 2,
                    PaymentMethod = PaymentMethod.Card,
                    Location = "Skopje South",
                    IsDelivered = true,
                    UserId = 3,
                    TimeOrdered = DateTime.Now.AddDays(-1)
                });

            modelBuilder.Entity<BurgerOrder>()
                .HasData(
                new BurgerOrder
                {
                    Id = 1,
                    BurgerId = 1,
                    OrderId = 1,
                },
                new BurgerOrder
                {
                    Id = 2,
                    BurgerId = 4,
                    OrderId = 1,
                },
                new BurgerOrder
                {
                    Id = 3,
                    BurgerId = 2,
                    OrderId = 2,
                });

        }
    }
}
