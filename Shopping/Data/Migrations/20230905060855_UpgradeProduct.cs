using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.Data.Migrations
{
    public partial class UpgradeProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descriptioin",
                table: "Products",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Descriptioin");
        }
    }
}
