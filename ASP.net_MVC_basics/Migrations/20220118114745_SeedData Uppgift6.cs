using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.net_MVC_basics.Migrations
{
    public partial class SeedDataUppgift6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "CityId", "Name", "Phone" },
                values: new object[] { 1, 1, "Anna", "+46718899111" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "CityId", "Name", "Phone" },
                values: new object[] { 2, 1, "Annika", "+46718899122" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "CityId", "Name", "Phone" },
                values: new object[] { 3, 2, "Ali", "+46718894444" });

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
                table: "PeopleLanguage",
                columns: new[] { "LanguageId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 4, 3 },
                    { 1, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PeopleLanguage",
                keyColumns: new[] { "LanguageId", "PersonId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PeopleLanguage",
                keyColumns: new[] { "LanguageId", "PersonId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleLanguage",
                keyColumns: new[] { "LanguageId", "PersonId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleLanguage",
                keyColumns: new[] { "LanguageId", "PersonId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PeopleLanguage",
                keyColumns: new[] { "LanguageId", "PersonId" },
                keyValues: new object[] { 4, 3 });
        }
    }
}
