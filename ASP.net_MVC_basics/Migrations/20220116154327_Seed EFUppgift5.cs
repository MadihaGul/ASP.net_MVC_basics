using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.net_MVC_basics.Migrations
{
    public partial class SeedEFUppgift5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryModelId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityModelId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityModelId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryModelId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityModelId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CountryModelId",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "People",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Cities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[] { 1, "Sweden" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[] { 2, "Pakistan" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName", "CountryId" },
                values: new object[] { 1, "Lund", 1 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName", "CountryId" },
                values: new object[] { 2, "Islamabad", 2 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId",
                table: "Cities");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "CityModelId",
                table: "People",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryModelId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_People_CityModelId",
                table: "People",
                column: "CityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryModelId",
                table: "Cities",
                column: "CountryModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryModelId",
                table: "Cities",
                column: "CountryModelId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityModelId",
                table: "People",
                column: "CityModelId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
