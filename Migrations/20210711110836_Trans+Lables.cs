using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstBlazor.Migrations
{
    public partial class TransLables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransLables",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    LableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransLables", x => new { x.TransactionId, x.LableId });
                    table.ForeignKey(
                        name: "FK_TransLables_Lables_LableId",
                        column: x => x.LableId,
                        principalTable: "Lables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransLables_Trans_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Trans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransLables_LableId",
                table: "TransLables",
                column: "LableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransLables");
        }
    }
}
