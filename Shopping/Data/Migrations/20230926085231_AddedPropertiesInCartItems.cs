using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Data.Migrations
{
    public partial class AddedPropertiesInCartItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14835438-a673-464b-9c69-50e4443f5443");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5974f9ca-8fb9-4600-9ece-9df8158c3c40");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "14835438-a673-464b-9c69-50e4443f5443", "2", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5974f9ca-8fb9-4600-9ece-9df8158c3c40", "1", "Admin", "Admin" });
        }
    }
}
