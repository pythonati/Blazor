using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstBlazor.Migrations
{
    public partial class IndexesforTran : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TranType",
                table: "Trans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trans_AccountId",
                table: "Trans",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_CategoryId",
                table: "Trans",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_TranType",
                table: "Trans",
                column: "TranType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trans_AccountId",
                table: "Trans");

            migrationBuilder.DropIndex(
                name: "IX_Trans_CategoryId",
                table: "Trans");

            migrationBuilder.DropIndex(
                name: "IX_Trans_TranType",
                table: "Trans");

            migrationBuilder.DropColumn(
                name: "TranType",
                table: "Trans");
        }
    }
}
