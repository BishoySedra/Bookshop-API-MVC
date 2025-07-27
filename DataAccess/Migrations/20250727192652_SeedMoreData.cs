using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "MasterSchema",
                table: "Categories",
                columns: new[] { "Id", "catName", "catOrder", "isDeleted" },
                values: new object[,]
                {
                    { 3, "History", 3, false },
                    { 4, "Technology", 4, false },
                    { 5, "Philosophy", 5, false }
                });

            migrationBuilder.InsertData(
                schema: "MasterSchema",
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "BookPrice", "Title" },
                values: new object[,]
                {
                    { 7, "Neil deGrasse Tyson", 2, "Science made simple", 41.990000000000002, "Astrophysics for People in a Hurry" },
                    { 8, "Richard Dawkins", 2, "Evolution explained", 52.990000000000002, "The Selfish Gene" },
                    { 4, "Yuval Noah Harari", 3, "A brief history of humankind", 64.989999999999995, "Sapiens" },
                    { 5, "Robert C. Martin", 4, "Best practices for writing clean code", 74.989999999999995, "Clean Code" },
                    { 6, "Marcus Aurelius", 5, "Thoughts of Marcus Aurelius", 29.989999999999998, "Meditations" },
                    { 9, "Sun Tzu", 3, "Classic Chinese military treatise", 24.989999999999998, "The Art of War" },
                    { 10, "Plato", 5, "Philosophical dialogue by Plato", 34.990000000000002, "The Republic" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
