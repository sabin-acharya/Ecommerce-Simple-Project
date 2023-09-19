using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Data.Migrations
{
    public partial class AddCartServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Carts",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carts",
                newName: "CartId");
        }
    }
}
