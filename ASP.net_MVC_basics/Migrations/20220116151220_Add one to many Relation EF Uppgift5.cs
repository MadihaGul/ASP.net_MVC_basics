using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.net_MVC_basics.Migrations
{
    public partial class AddonetomanyRelationEFUppgift5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "CityModelId",
                table: "People",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(maxLength: 100, nullable: false),
                    CountryModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryModelId",
                        column: x => x.CountryModelId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_CityModelId",
                table: "People",
                column: "CityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryModelId",
                table: "Cities",
                column: "CountryModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityModelId",
                table: "People",
                column: "CityModelId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityModelId",
                table: "People");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_People_CityModelId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityModelId",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "City", "Name", "Phone" },
                values: new object[] { 1, "Stockholm", "Anna", "+46718899111" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "City", "Name", "Phone" },
                values: new object[] { 2, "Lund", "Annika", "+46718899122" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "City", "Name", "Phone" },
                values: new object[] { 3, "Uppsala", "Ali", "+46718894444" });
        }
    }
}
