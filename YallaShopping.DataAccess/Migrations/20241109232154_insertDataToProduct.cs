using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YallaShopping.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class insertDataToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageURL", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 9, "Alex Johnson", 1, "Learn JavaScript from scratch.", "1000000003", "", 40.0, 35.0, 25.0, 30.0, "JavaScript for Beginners" },
                    { 10, "Mary Stone", 1, "Deep dive into ASP.NET Core development.", "1000000004", "", 70.0, 65.0, 55.0, 60.0, "Mastering ASP.NET Core" },
                    { 11, "Emily Davis", 1, "Guide to using Entity Framework Core.", "1000000005", "", 45.0, 40.0, 30.0, 35.0, "Entity Framework Core Essentials" },
                    { 12, "Robert C. Martin", 1, "A handbook of agile software craftsmanship.", "1000000006", "", 90.0, 85.0, 75.0, 80.0, "Clean Code" },
                    { 13, "Sarah Green", 1, "Complete Python guide for beginners.", "1000000007", "", 55.0, 50.0, 40.0, 45.0, "Python Programming" },
                    { 14, "Michael Allen", 1, "An overview of AI concepts.", "1000000008", "", 80.0, 75.0, 65.0, 70.0, "Artificial Intelligence Basics" },
                    { 15, "Rachel Lee", 1, "Learn SQL for analyzing data.", "1000000009", "", 65.0, 60.0, 50.0, 55.0, "SQL for Data Analysis" },
                    { 16, "David Clark", 1, "Comprehensive guide on data structures.", "1000000010", "", 95.0, 90.0, 80.0, 85.0, "Data Structures and Algorithms" },
                    { 17, "Anna White", 1, "Step-by-step guide to machine learning.", "1000000011", "", 100.0, 95.0, 85.0, 90.0, "Machine Learning with Python" },
                    { 18, "Chris Black", 1, "Comprehensive guide to web development.", "1000000012", "", 75.0, 70.0, 60.0, 65.0, "Web Development Essentials" },
                    { 19, "Tom Brown", 1, "Complete guide to Java programming.", "1000000013", "", 85.0, 80.0, 70.0, 75.0, "Java Fundamentals" },
                    { 20, "Linda Blue", 1, "Learn Kotlin for Android app development.", "1000000014", "", 65.0, 60.0, 50.0, 55.0, "Kotlin for Android Developers" },
                    { 21, "Nancy Grey", 1, "Basics and applications of cloud computing.", "1000000015", "", 55.0, 50.0, 40.0, 45.0, "Understanding Cloud Computing" },
                    { 22, "Paul Adams", 1, "Guide to managing agile projects.", "1000000016", "", 60.0, 55.0, 45.0, 50.0, "Agile Project Management" },
                    { 23, "Sophie Turner", 1, "Practical guide to building apps with React.", "1000000017", "", 70.0, 65.0, 55.0, 60.0, "React.js in Practice" },
                    { 24, "George Lane", 1, "Basic principles of cybersecurity.", "1000000018", "", 80.0, 75.0, 65.0, 70.0, "Introduction to Cybersecurity" },
                    { 25, "Emma Clark", 1, "Techniques and tools for big data analysis.", "1000000019", "", 95.0, 90.0, 80.0, 85.0, "Big Data Analytics" },
                    { 26, "William Brown", 1, "Effective strategies for digital marketing.", "1000000020", "", 50.0, 45.0, 35.0, 40.0, "Digital Marketing Strategies" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);
        }
    }
}
