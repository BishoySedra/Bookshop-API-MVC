using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ApplyPendingChanges_2 : Migration
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
                    { 1, "Fiction", 1, false },
                    { 2, "Science", 2, false }
                });

            migrationBuilder.InsertData(
                schema: "MasterSchema",
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "BookPrice", "Title" },
                values: new object[,]
                {
                    { 1, "George Orwell", 1, "Dystopian novel", 49.990000000000002, "1984" },
                    { 2, "Andy Weir", 2, "Sci-fi survival story", 59.990000000000002, "The Martian" },
                    { 3, "Aldous Huxley", 1, "Classic dystopia", 39.990000000000002, "Brave New World" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "MasterSchema",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
