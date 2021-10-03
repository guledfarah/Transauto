using Microsoft.EntityFrameworkCore.Migrations;

namespace Transauto.Services.ProductAPI.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "Entree", "fried triangular shaped pastry with a savory filling like spiced onions, beef meat, and other ingredients", "https://transautostatifiles.blob.core.windows.net/productimages/sambusa.jpg", "Sambusa", 12.4 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "Dessert", "a layered pastry dessert made of filo pastry, filled with chopped nuts, and sweetened with syrup or honey", "https://transautostatifiles.blob.core.windows.net/productimages/baklava.jpg", "Baklava", 2.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);
        }
    }
}
