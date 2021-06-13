using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiTest.Migrations
{
    public partial class Profileupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[] { 1, "Huixtla", null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Mexico" });

            migrationBuilder.InsertData(
                table: "Profile",
                columns: new[] { "Id", "Avatar", "Nickname" },
                values: new object[] { 1, "avatar.jpg", "nickname" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, null, "Aguascaliente" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
