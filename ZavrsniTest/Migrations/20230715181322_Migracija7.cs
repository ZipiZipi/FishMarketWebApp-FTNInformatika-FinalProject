using Microsoft.EntityFrameworkCore.Migrations;

namespace ZavrsniTest.Migrations
{
    public partial class Migracija7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ribarnice",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GodinaOtvaranja", "Naziv" },
                values: new object[] { 2015, "Dunav doo" });

            migrationBuilder.UpdateData(
                table: "Ribarnice",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GodinaOtvaranja", "Naziv" },
                values: new object[] { 2012, "Tisa str" });

            migrationBuilder.UpdateData(
                table: "Ribarnice",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GodinaOtvaranja", "Naziv" },
                values: new object[] { 2015, "Sveza riba" });

            migrationBuilder.UpdateData(
                table: "Ribe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cena", "Kolicina", "Mesto", "RibarnicaId", "Sorta" },
                values: new object[] { 1100m, 20, "Ribnjak Bager", 3, "Smudj" });

            migrationBuilder.UpdateData(
                table: "Ribe",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cena", "Kolicina", "Mesto", "RibarnicaId", "Sorta" },
                values: new object[] { 860m, 30, "Dunav", 1, "Saran" });

            migrationBuilder.UpdateData(
                table: "Ribe",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cena", "Kolicina", "Mesto", "RibarnicaId", "Sorta" },
                values: new object[] { 1300m, 10, "Tisa", 2, "Som" });

            migrationBuilder.InsertData(
                table: "Ribe",
                columns: new[] { "Id", "Cena", "Kolicina", "Mesto", "RibarnicaId", "Sorta" },
                values: new object[,]
                {
                    { 4, 780m, 12, "Ribnjak Ecka", 3, "Saran" },
                    { 5, 950m, 15, "Dunav", 1, "Smudj" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ribe",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ribe",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Ribarnice",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GodinaOtvaranja", "Naziv" },
                values: new object[] { 1951, "Lidl" });

            migrationBuilder.UpdateData(
                table: "Ribarnice",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GodinaOtvaranja", "Naziv" },
                values: new object[] { 2022, "Univerexport" });

            migrationBuilder.UpdateData(
                table: "Ribarnice",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GodinaOtvaranja", "Naziv" },
                values: new object[] { 1999, "Idea" });

            migrationBuilder.UpdateData(
                table: "Ribe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cena", "Kolicina", "Mesto", "RibarnicaId", "Sorta" },
                values: new object[] { 1400m, 10, "Smederevo", 1, "Saran" });

            migrationBuilder.UpdateData(
                table: "Ribe",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cena", "Kolicina", "Mesto", "RibarnicaId", "Sorta" },
                values: new object[] { 1000m, 15, "Kovin", 2, "Smudj" });

            migrationBuilder.UpdateData(
                table: "Ribe",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cena", "Kolicina", "Mesto", "RibarnicaId", "Sorta" },
                values: new object[] { 999m, 20, "Pancevo", 3, "Stuka" });
        }
    }
}
