using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.net_MVC_basics.Migrations
{
    public partial class UpdatedApplicationUserandseededadminandroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a5e3560f-e8b2-45bd-b86a-2f127ff237e3", "aa2dfa02-d1ed-4820-a17a-98b401da7e84" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa2dfa02-d1ed-4820-a17a-98b401da7e84");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a5e3560f-e8b2-45bd-b86a-2f127ff237e3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "75841111-9fc4-46b6-bda4-b157e08abf98", "74e08013-820c-4bca-a442-7874fdeedecd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a79c19c3-b4fe-4d0d-8f32-cdcf59af3d63", "8178b463-cec5-4a02-bb42-a49d81c03c87", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ea2e7d95-66b7-46cd-bc7c-2654d5e3cecb", 0, new DateTime(2022, 1, 26, 22, 20, 10, 128, DateTimeKind.Local).AddTicks(101), "1009f344-2202-4ecc-8fb5-0ddf744292b6", "admin@admin.com", false, "Admin", "Adminlast", false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEMkBZqbVpjEdlKOnhP1I6J4tafhgj5gb8eEH34wlw1me3Wt/29nSn8qXQkLZBLapuw==", null, false, "7825364c-99f0-440c-9b09-df6119d24b02", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ea2e7d95-66b7-46cd-bc7c-2654d5e3cecb", "75841111-9fc4-46b6-bda4-b157e08abf98" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a79c19c3-b4fe-4d0d-8f32-cdcf59af3d63");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ea2e7d95-66b7-46cd-bc7c-2654d5e3cecb", "75841111-9fc4-46b6-bda4-b157e08abf98" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75841111-9fc4-46b6-bda4-b157e08abf98");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea2e7d95-66b7-46cd-bc7c-2654d5e3cecb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa2dfa02-d1ed-4820-a17a-98b401da7e84", "448b95bc-dd7c-458b-b39e-f1e2991beee6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00000000-0000-0000-0000-000000000000", "79b72391-87ae-4774-9bcc-39a6009e19ec", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a5e3560f-e8b2-45bd-b86a-2f127ff237e3", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7dc745c6-c5cb-4087-a7ac-dbee8fb6f4ff", "admin@admin.com", false, "Admin", "Adminlast", false, null, "admin@admin.com", "ADMIN", "AQAAAAEAACcQAAAAEDiC+NJZ/ThXx6+eKaKUu8yA+fga/exhxMSy0PK0iZCjTIxIgLkmbYK5G7dkbr5/gA==", null, false, "41efd801-0603-452b-a1c6-ca85ab4eb282", false, "ADMIN@ADMIN.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a5e3560f-e8b2-45bd-b86a-2f127ff237e3", "aa2dfa02-d1ed-4820-a17a-98b401da7e84" });
        }
    }
}
