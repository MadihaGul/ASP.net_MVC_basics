using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.net_MVC_basics.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
