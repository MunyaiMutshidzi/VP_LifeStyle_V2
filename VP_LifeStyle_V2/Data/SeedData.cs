using VP_Lifestyle.Models;
using VP_LifeStyle_V2.Models;
using Microsoft.EntityFrameworkCore;
using VP_Lifestyle.Data;

namespace VP_LifeStyle_V2.Data
{
    public class SeedData
    {
        //Inside a normal void method (same parameters)
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            //Same for both EntityFramework & AspNetCore Identity
            LifestyleDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetService<LifestyleDbContext>();

            //To be able to initialize the seedData ensure the Dbset has been created on the DB context.
            //Same for both EntityFramework & AspNetCore Identity
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //Different for both EntityFramework & AspNetCore Identity
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                       new Category { CategoryName = "Breakfast", CategoryDescription = "Popular" },
                       new Category { CategoryName = "Launch", CategoryDescription = "Special" },
                       new Category { CategoryName = "Dinner", CategoryDescription = "Lovely" }
                    );
            }
            context.SaveChanges();

            if (!context.Products.Any())
            {

                context.Products.AddRange(
                    new Product
                    {   //1
                        CategoryID = 1,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-1.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //2
                        CategoryID = 1,
                        ProductName = "Beef burger",
                        ProductCode = "menu-2.jpg",
                        Price = 200,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //3
                        CategoryID = 1,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-3.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //4
                        CategoryID = 1,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-4.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //5
                        CategoryID = 1,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-5.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //6
                        CategoryID = 1,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-6.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //7
                        CategoryID = 1,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-7.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //8
                        CategoryID = 1,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-8.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //9
                        CategoryID = 2,
                        ProductName = "Chicken Burger",
                        Price = (decimal)115.00,
                        ProductCode = "menu-1.jpg",
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //10
                        CategoryID = 2,
                        ProductName = "Chicken Burger",
                        Price = (decimal)115.00,
                        ProductCode = "menu-2.jpg",
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //11
                        CategoryID = 2,
                        ProductName = "Chicken Burger",
                        Price = (decimal)115.00,
                        ProductCode = "menu-3.jpg",
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //12
                        CategoryID = 2,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-4.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //13
                        CategoryID = 2,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-5.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //14
                        CategoryID = 2,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-6.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //15
                        CategoryID = 2,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-7.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //16
                        CategoryID = 2,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-8.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //17
                        CategoryID = 3,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-1.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //18
                        CategoryID = 3,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-2.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //19
                        CategoryID = 3,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-3.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //20
                        CategoryID = 3,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-4.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {  //21
                        CategoryID = 3,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-5.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {  //22
                        CategoryID = 3,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-6.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {  //23
                        CategoryID = 3,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-7.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    },
                    new Product
                    {   //24
                        CategoryID = 3,
                        ProductName = "Chicken Burger",
                        ProductCode = "menu-8.jpg",
                        Price = (decimal)115.00,
                        ProductDescription = "Ipsum ipsum clita erat amet dolor justo diam"
                    }
                    );

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                        new Customer { CustomerFirstName = "Mutshidzi", CustomerLastName = "Munyai", Registration = DateTime.Parse("2024-10-20"), CustomerEmail = "Munyai@gmail.com" },
                        new Customer { CustomerFirstName = "Unarine", CustomerLastName = "Munyai", Registration = DateTime.Parse("2024-11-05"), CustomerEmail = "  Unarine@gmail.com" },
                        new Customer { CustomerFirstName = "Kira", CustomerLastName = "Menance", Registration = DateTime.Parse("2024-1-20-07"), CustomerEmail = "Kira@gmail.com" },
                        new Customer { CustomerFirstName = "Peter", CustomerLastName = "Parker", Registration = DateTime.Parse("2024-10-11"), CustomerEmail = "Peter@gmail.com" },
                        new Customer { CustomerFirstName = "Zan", CustomerLastName = "Ndlovue", Registration = DateTime.Parse("2024-10-20-4"), CustomerEmail = "Zan@gmail.com" },
                        new Customer { CustomerFirstName = "Mutshidzi", CustomerLastName = "Munyai", Registration = DateTime.Parse("2024-10-20"), CustomerEmail = "Munyai@gmail.com" },
                        new Customer { CustomerFirstName = "Unarine", CustomerLastName = "Munyai", Registration = DateTime.Parse("2024-11-05"), CustomerEmail = "  Unarine@gmail.com" },
                        new Customer { CustomerFirstName = "Kira", CustomerLastName = "Menance", Registration = DateTime.Parse("2024-1-20-07"), CustomerEmail = "Kira@gmail.com" },
                        new Customer { CustomerFirstName = "Peter", CustomerLastName = "Parker", Registration = DateTime.Parse("2024-10-11"), CustomerEmail = "Peter@gmail.com" },
                        new Customer { CustomerFirstName = "Zan", CustomerLastName = "Ndlovue", Registration = DateTime.Parse("2024-10-20-4"), CustomerEmail = "Zan@gmail.com" },
                        new Customer { CustomerFirstName = "Mutshidzi", CustomerLastName = "Munyai", Registration = DateTime.Parse("2024-10-20"), CustomerEmail = "Munyai@gmail.com" },
                        new Customer { CustomerFirstName = "Unarine", CustomerLastName = "Munyai", Registration = DateTime.Parse("2024-11-05"), CustomerEmail = "  Unarine@gmail.com" },
                        new Customer { CustomerFirstName = "Kira", CustomerLastName = "Menance", Registration = DateTime.Parse("2024-1-20-07"), CustomerEmail = "Kira@gmail.com" },
                        new Customer { CustomerFirstName = "Peter", CustomerLastName = "Parker", Registration = DateTime.Parse("2024-10-11"), CustomerEmail = "Peter@gmail.com" },
                        new Customer { CustomerFirstName = "Zan", CustomerLastName = "Ndlovue", Registration = DateTime.Parse("2024-10-20-4"), CustomerEmail = "Zan@gmail.com" }

                        );

                };

                if (!context.Reservations.Any())
                {
                    context.Reservations.AddRange(
                    new Reservation { CustomerID = 1, ProductID = 2, ReservationName = "Mutshidzi-Reservation", TableType = TableType.Solo },
                    new Reservation { CustomerID = 2, ProductID = 4, ReservationName = "Unarine-Reservation", TableType = TableType.Family },
                    new Reservation { CustomerID = 3, ProductID = 6, ReservationName = "Kira-Reservation", TableType = TableType.Couple },
                    new Reservation { CustomerID = 4, ProductID = 8, ReservationName = "Peter-Reservation", TableType = TableType.Family },
                    new Reservation { CustomerID = 5, ProductID = 10, ReservationName = "Zan-Reservation", TableType = TableType.Solo },
                     new Reservation { CustomerID = 6,ProductID = 2, ReservationName = "Mutshidzi-Reservation", TableType = TableType.Solo },
                    new Reservation { CustomerID = 7, ProductID = 4, ReservationName = "Unarine-Reservation", TableType = TableType.Family },
                    new Reservation { CustomerID = 8, ProductID = 6, ReservationName = "Kira-Reservation", TableType = TableType.Couple },
                    new Reservation { CustomerID = 9, ProductID = 8, ReservationName = "Peter-Reservation", TableType = TableType.Family },
                    new Reservation { CustomerID = 10,ProductID = 10, ReservationName = "Zan-Reservation", TableType = TableType.Solo },
                     new Reservation { CustomerID = 11,ProductID = 2, ReservationName = "Mutshidzi-Reservation", TableType = TableType.Solo },
                    new Reservation { CustomerID = 12,ProductID = 4, ReservationName = "Unarine-Reservation", TableType = TableType.Family },
                    new Reservation { CustomerID = 13,ProductID = 6, ReservationName = "Kira-Reservation", TableType = TableType.Couple },
                    new Reservation { CustomerID = 14,ProductID = 8, ReservationName = "Peter-Reservation", TableType = TableType.Family },
                    new Reservation { CustomerID = 15,ProductID = 10, ReservationName = "Zan-Reservation", TableType = TableType.Solo }
                    );

                };
                context.SaveChanges();
            }
        }
    }
}
