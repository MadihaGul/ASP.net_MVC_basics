using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.net_MVC_basics.Migrations
{
    public partial class m2mEF6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Languages_LanguageModelLanguageId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_People_PeopleModelPersonId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_LanguageModelLanguageId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_PeopleModelPersonId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageModelLanguageId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "PeopleModelPersonId",
                table: "Languages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageModelLanguageId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeopleModelPersonId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageModelLanguageId",
                table: "Languages",
                column: "LanguageModelLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_PeopleModelPersonId",
                table: "Languages",
                column: "PeopleModelPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Languages_LanguageModelLanguageId",
                table: "Languages",
                column: "LanguageModelLanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_People_PeopleModelPersonId",
                table: "Languages",
                column: "PeopleModelPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
