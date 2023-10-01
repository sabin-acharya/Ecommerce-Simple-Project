using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Data.Migrations
{
    public partial class RemoveOrderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Orders_OrderId",
                table: "Buys");

            migrationBuilder.DropIndex(
                name: "IX_Buys_OrderId",
                table: "Buys");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b865da8-5c8d-440e-899d-f452e67303c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2822438d-6624-4c21-812c-f37636b3cb48");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Buys");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bc378c6-83bd-4a72-98d2-dbff1451ac91", "2", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eeceb1d1-a899-49f5-9271-6f1d6a87989d", "1", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bc378c6-83bd-4a72-98d2-dbff1451ac91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eeceb1d1-a899-49f5-9271-6f1d6a87989d");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Buys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b865da8-5c8d-440e-899d-f452e67303c0", "2", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2822438d-6624-4c21-812c-f37636b3cb48", "1", "Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Buys_OrderId",
                table: "Buys",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Orders_OrderId",
                table: "Buys",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
