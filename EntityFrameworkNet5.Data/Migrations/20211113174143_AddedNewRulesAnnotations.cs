using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkNet5.Data.Migrations
{
    public partial class AddedNewRulesAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TicketPrice",
                table: "Matches",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Matches");
        }
    }
}
