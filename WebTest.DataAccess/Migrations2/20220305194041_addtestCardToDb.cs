using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTest.DataAccess.Migrations
{
    public partial class addtestCardToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsCart_Categories_CategoryId",
                table: "TestsCart");

            migrationBuilder.DropIndex(
                name: "IX_TestsCart_CategoryId",
                table: "TestsCart");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TestsCart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TestsCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestsCart_CategoryId",
                table: "TestsCart",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestsCart_Categories_CategoryId",
                table: "TestsCart",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
