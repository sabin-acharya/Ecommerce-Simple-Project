using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Data.Migrations
{
    public partial class UseBuyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_CartItems_CartItemId",
                table: "Buys");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74fe8b3a-a68c-47c4-8283-966bbf279aea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b40e966e-bc75-4929-99d9-44ff9a69be63");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CardHolderName",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "CartItemId",
                table: "Buys",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_CartItemId",
                table: "Buys",
                newName: "IX_Buys_OrderId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "414eb763-93bb-4190-9c2a-242dbf816aa4", "2", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5ec5246-ab88-4fa0-92a7-b1d434672f35", "1", "Admin", "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Orders_OrderId",
                table: "Buys",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Orders_OrderId",
                table: "Buys");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "414eb763-93bb-4190-9c2a-242dbf816aa4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5ec5246-ab88-4fa0-92a7-b1d434672f35");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Buys",
                newName: "CartItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_OrderId",
                table: "Buys",
                newName: "IX_Buys_CartItemId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardHolderName",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74fe8b3a-a68c-47c4-8283-966bbf279aea", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b40e966e-bc75-4929-99d9-44ff9a69be63", "2", "Customer", "Customer" });

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_CartItems_CartItemId",
                table: "Buys",
                column: "CartItemId",
                principalTable: "CartItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
