using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YallaShopping.Models;

namespace YallaShopping.DataAccess.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ProductImage> ProductImages{ get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Scifi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId =1
                },
                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 1
                }
                // ,new Product
                // {
                //     Id = 8,
                //     Title = "Advanced C# Techniques",
                //     Description = "Advanced concepts and patterns in C#.",
                //     ISBN = "1000000002",
                //     Author = "John Smith",
                //     ListPrice = 60.0,
                //     Price = 55.0,
                //     Price50 = 50.0,
                //     Price100 = 45.0,
                //     CategoryId = 1,
                //     ImageURL = ""
                // },
                //new Product
                //{
                //    Id = 9,
                //    Title = "JavaScript for Beginners",
                //    Description = "Learn JavaScript from scratch.",
                //    ISBN = "1000000003",
                //    Author = "Alex Johnson",
                //    ListPrice = 40.0,
                //    Price = 35.0,
                //    Price50 = 30.0,
                //    Price100 = 25.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 10,
                //    Title = "Mastering ASP.NET Core",
                //    Description = "Deep dive into ASP.NET Core development.",
                //    ISBN = "1000000004",
                //    Author = "Mary Stone",
                //    ListPrice = 70.0,
                //    Price = 65.0,
                //    Price50 = 60.0,
                //    Price100 = 55.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 11,
                //    Title = "Entity Framework Core Essentials",
                //    Description = "Guide to using Entity Framework Core.",
                //    ISBN = "1000000005",
                //    Author = "Emily Davis",
                //    ListPrice = 45.0,
                //    Price = 40.0,
                //    Price50 = 35.0,
                //    Price100 = 30.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 12,
                //    Title = "Clean Code",
                //    Description = "A handbook of agile software craftsmanship.",
                //    ISBN = "1000000006",
                //    Author = "Robert C. Martin",
                //    ListPrice = 90.0,
                //    Price = 85.0,
                //    Price50 = 80.0,
                //    Price100 = 75.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 13,
                //    Title = "Python Programming",
                //    Description = "Complete Python guide for beginners.",
                //    ISBN = "1000000007",
                //    Author = "Sarah Green",
                //    ListPrice = 55.0,
                //    Price = 50.0,
                //    Price50 = 45.0,
                //    Price100 = 40.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 14,
                //    Title = "Artificial Intelligence Basics",
                //    Description = "An overview of AI concepts.",
                //    ISBN = "1000000008",
                //    Author = "Michael Allen",
                //    ListPrice = 80.0,
                //    Price = 75.0,
                //    Price50 = 70.0,
                //    Price100 = 65.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 15,
                //    Title = "SQL for Data Analysis",
                //    Description = "Learn SQL for analyzing data.",
                //    ISBN = "1000000009",
                //    Author = "Rachel Lee",
                //    ListPrice = 65.0,
                //    Price = 60.0,
                //    Price50 = 55.0,
                //    Price100 = 50.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 16,
                //    Title = "Data Structures and Algorithms",
                //    Description = "Comprehensive guide on data structures.",
                //    ISBN = "1000000010",
                //    Author = "David Clark",
                //    ListPrice = 95.0,
                //    Price = 90.0,
                //    Price50 = 85.0,
                //    Price100 = 80.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 17,
                //    Title = "Machine Learning with Python",
                //    Description = "Step-by-step guide to machine learning.",
                //    ISBN = "1000000011",
                //    Author = "Anna White",
                //    ListPrice = 100.0,
                //    Price = 95.0,
                //    Price50 = 90.0,
                //    Price100 = 85.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 18,
                //    Title = "Web Development Essentials",
                //    Description = "Comprehensive guide to web development.",
                //    ISBN = "1000000012",
                //    Author = "Chris Black",
                //    ListPrice = 75.0,
                //    Price = 70.0,
                //    Price50 = 65.0,
                //    Price100 = 60.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 19,
                //    Title = "Java Fundamentals",
                //    Description = "Complete guide to Java programming.",
                //    ISBN = "1000000013",
                //    Author = "Tom Brown",
                //    ListPrice = 85.0,
                //    Price = 80.0,
                //    Price50 = 75.0,
                //    Price100 = 70.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 20,
                //    Title = "Kotlin for Android Developers",
                //    Description = "Learn Kotlin for Android app development.",
                //    ISBN = "1000000014",
                //    Author = "Linda Blue",
                //    ListPrice = 65.0,
                //    Price = 60.0,
                //    Price50 = 55.0,
                //    Price100 = 50.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 21,
                //    Title = "Understanding Cloud Computing",
                //    Description = "Basics and applications of cloud computing.",
                //    ISBN = "1000000015",
                //    Author = "Nancy Grey",
                //    ListPrice = 55.0,
                //    Price = 50.0,
                //    Price50 = 45.0,
                //    Price100 = 40.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 22,
                //    Title = "Agile Project Management",
                //    Description = "Guide to managing agile projects.",
                //    ISBN = "1000000016",
                //    Author = "Paul Adams",
                //    ListPrice = 60.0,
                //    Price = 55.0,
                //    Price50 = 50.0,
                //    Price100 = 45.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 23,
                //    Title = "React.js in Practice",
                //    Description = "Practical guide to building apps with React.",
                //    ISBN = "1000000017",
                //    Author = "Sophie Turner",
                //    ListPrice = 70.0,
                //    Price = 65.0,
                //    Price50 = 60.0,
                //    Price100 = 55.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 24,
                //    Title = "Introduction to Cybersecurity",
                //    Description = "Basic principles of cybersecurity.",
                //    ISBN = "1000000018",
                //    Author = "George Lane",
                //    ListPrice = 80.0,
                //    Price = 75.0,
                //    Price50 = 70.0,
                //    Price100 = 65.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 25,
                //    Title = "Big Data Analytics",
                //    Description = "Techniques and tools for big data analysis.",
                //    ISBN = "1000000019",
                //    Author = "Emma Clark",
                //    ListPrice = 95.0,
                //    Price = 90.0,
                //    Price50 = 85.0,
                //    Price100 = 80.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //},
                //new Product
                //{
                //    Id = 26,
                //    Title = "Digital Marketing Strategies",
                //    Description = "Effective strategies for digital marketing.",
                //    ISBN = "1000000020",
                //    Author = "William Brown",
                //    ListPrice = 50.0,
                //    Price = 45.0,
                //    Price50 = 40.0,
                //    Price100 = 35.0,
                //    CategoryId = 1,
                //    ImageURL = ""
                //}
            );
        }
    }
}
