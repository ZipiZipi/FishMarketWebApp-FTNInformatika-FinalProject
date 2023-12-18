using Microsoft.EntityFrameworkCore.Migrations;

namespace ZavrsniTest.Migrations
{
    public partial class Migracija3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ribarnice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GodinaOtvaranja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ribarnice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ribe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sorta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    RibarnicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ribe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ribe_Ribarnice_RibarnicaId",
                        column: x => x.RibarnicaId,
                        principalTable: "Ribarnice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ribarnice",
                columns: new[] { "Id", "GodinaOtvaranja", "Naziv" },
                values: new object[] { 1, 1951, "Lidl" });

            migrationBuilder.InsertData(
                table: "Ribarnice",
                columns: new[] { "Id", "GodinaOtvaranja", "Naziv" },
                values: new object[] { 2, 2022, "Univerexport" });

            migrationBuilder.InsertData(
                table: "Ribarnice",
                columns: new[] { "Id", "GodinaOtvaranja", "Naziv" },
                values: new object[] { 3, 1999, "Idea" });

            migrationBuilder.InsertData(
                table: "Ribe",
                columns: new[] { "Id", "Cena", "Kolicina", "Mesto", "RibarnicaId", "Sorta" },
                values: new object[] { 1, 1400m, 10, "Smederevo", 1, "Saran" });

            migrationBuilder.InsertData(
                table: "Ribe",
                columns: new[] { "Id", "Cena", "Kolicina", "Mesto", "RibarnicaId", "Sorta" },
                values: new object[] { 2, 1000m, 15, "Kovin", 2, "Smudj" });

            migrationBuilder.InsertData(
                table: "Ribe",
                columns: new[] { "Id", "Cena", "Kolicina", "Mesto", "RibarnicaId", "Sorta" },
                values: new object[] { 3, 999m, 20, "Pancevo", 3, "Stuka" });

            migrationBuilder.CreateIndex(
                name: "IX_Ribe_RibarnicaId",
                table: "Ribe",
                column: "RibarnicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ribe");

            migrationBuilder.DropTable(
                name: "Ribarnice");
        }
    }
}
