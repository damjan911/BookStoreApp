using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedCustomerUserAndBookToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "City", "FirstName", "LastName", "State" },
                values: new object[,]
                {
                    { 1, "Berkeley", "Abraham", "Bennet", "CA" },
                    { 2, "Menlo Park", "Johnson", "White", "CA" },
                    { 3, "San Francisco", "Charlene", "Locksley", "CA" },
                    { 4, "Oakland", "Dean", "Straight", "CA" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown, USA", "Alice", "Johnson" },
                    { 2, "123 Main St, Anytown, USA", "Alice", "Johnson" },
                    { 3, "789 Oak St, Smallville", "Carol", "Davis" },
                    { 4, "101 Pine St, Cityville", "David", "Brown" },
                    { 5, "222 Cedar St, Villageville", "Emily", "White" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "ISBN", "Title" },
                values: new object[,]
                {
                    { 1, 3, 2, -123455811, "The Mystery of Shadows" },
                    { 2, 2, 1, -987653343, "The Fantasy Realm" },
                    { 3, 4, 3, -543210009, "Thrills and Chills" },
                    { 4, 1, 1, -567889145, "Enchanted Kingdom" },
                    { 5, 4, 2, -12344700, "Midnight Secrets" }
                });

            migrationBuilder.InsertData(
                table: "BookCustomer",
                columns: new[] { "Id", "BookId", "CustomerId", "Genre" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 1, 2, 2 },
                    { 3, 4, 3, 1 },
                    { 4, 5, 4, 2 },
                    { 5, 3, 5, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookCustomer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookCustomer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookCustomer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookCustomer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookCustomer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
