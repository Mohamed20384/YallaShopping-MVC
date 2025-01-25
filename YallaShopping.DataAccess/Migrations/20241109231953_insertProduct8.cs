using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YallaShopping.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class insertProduct8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageURL", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { 8, "John Smith", 1, "Advanced concepts and patterns in C#.", "1000000002", "", 60.0, 55.0, 45.0, 50.0, "Advanced C# Techniques" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
