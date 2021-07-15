using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstBlazor.Migrations
{
    public partial class TansChanged2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trans_Accounts_AccountId",
                table: "Trans");

            migrationBuilder.DropForeignKey(
                name: "FK_Trans_Category_CategoryId",
                table: "Trans");

            migrationBuilder.DropIndex(
                name: "IX_Trans_AccountId",
                table: "Trans");

            migrationBuilder.DropIndex(
                name: "IX_Trans_CategoryId",
                table: "Trans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Trans_AccountId",
                table: "Trans",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_CategoryId",
                table: "Trans",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trans_Accounts_AccountId",
                table: "Trans",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trans_Category_CategoryId",
                table: "Trans",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
