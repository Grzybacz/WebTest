using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTest.DataAccess.Migrations
{
    public partial class addtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Categories_CategoryId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_TestsCart_Tests_TestId",
                table: "TestsCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestsCart",
                table: "TestsCart");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TestsCart");

            migrationBuilder.RenameTable(
                name: "TestsCart",
                newName: "TestCarts");

            migrationBuilder.RenameIndex(
                name: "IX_TestsCart_TestId",
                table: "TestCarts",
                newName: "IX_TestCarts_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestCarts",
                table: "TestCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCarts_Tests_TestId",
                table: "TestCarts",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Categories_CategoryId",
                table: "Tests",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCarts_Tests_TestId",
                table: "TestCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Categories_CategoryId",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestCarts",
                table: "TestCarts");

            migrationBuilder.RenameTable(
                name: "TestCarts",
                newName: "TestsCart");

            migrationBuilder.RenameIndex(
                name: "IX_TestCarts_TestId",
                table: "TestsCart",
                newName: "IX_TestsCart_TestId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TestsCart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestsCart",
                table: "TestsCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Categories_CategoryId",
                table: "Tests",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestsCart_Tests_TestId",
                table: "TestsCart",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
