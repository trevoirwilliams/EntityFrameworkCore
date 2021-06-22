using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkNet5.Data.Migrations
{
    public partial class AddedDefaultTeamsAndCoaches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Name" },
                values: new object[] { 20, "Sample League" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "LeagueId", "Name" },
                values: new object[] { 20, 20, "Trevoir Williams - Sample Team" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "LeagueId", "Name" },
                values: new object[] { 21, 20, "Trevoir Williams - Sample Team" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "LeagueId", "Name" },
                values: new object[] { 22, 20, "Trevoir Williams - Sample Team" });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "Name", "TeamId" },
                values: new object[] { 20, "Trevoir Williams", 20 });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "Name", "TeamId" },
                values: new object[] { 21, "Trevoir Williams - Sample 1", 21 });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "Name", "TeamId" },
                values: new object[] { 22, "Trevoir Williams - Sample 2", 22 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
