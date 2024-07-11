using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EatZilla.Migrations
{
    /// <inheritdoc />
    public partial class adddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "resturants",
                columns: new[] { "Rid", "Name", "OrderID", "type" },
                values: new object[,]
                {
                    { 101, "Taksh", 0, "Veg" },
                    { 102, "Nadbrhma", 0, "Snacks" },
                    { 103, "Mataji", 0, "Sweet" },
                    { 104, "Ashirwad", 0, "NonVeg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "resturants",
                keyColumn: "Rid",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "resturants",
                keyColumn: "Rid",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "resturants",
                keyColumn: "Rid",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "resturants",
                keyColumn: "Rid",
                keyValue: 104);
        }
    }
}
