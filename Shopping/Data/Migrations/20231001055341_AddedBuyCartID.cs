using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Data.Migrations
{
    public partial class AddedBuyCartID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bc378c6-83bd-4a72-98d2-dbff1451ac91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eeceb1d1-a899-49f5-9271-6f1d6a87989d");

            migrationBuilder.CreateTable(
                name: "BuyCartIdModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartItemId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyCartIdModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyCartIdModels_Buys_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Buys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyCartIdModels_CartItems_CartItemId",
                        column: x => x.CartItemId,
                        principalTable: "CartItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "572f5dd5-d8b9-435b-b6f7-cdd4bde1d631", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae7b34db-0d72-40af-a478-189f3001a354", "2", "Customer", "Customer" });

            migrationBuilder.CreateIndex(
                name: "IX_BuyCartIdModels_CartItemId",
                table: "BuyCartIdModels",
                column: "CartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyCartIdModels_LocationId",
                table: "BuyCartIdModels",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyCartIdModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "572f5dd5-d8b9-435b-b6f7-cdd4bde1d631");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae7b34db-0d72-40af-a478-189f3001a354");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bc378c6-83bd-4a72-98d2-dbff1451ac91", "2", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eeceb1d1-a899-49f5-9271-6f1d6a87989d", "1", "Admin", "Admin" });
        }
    }
}
