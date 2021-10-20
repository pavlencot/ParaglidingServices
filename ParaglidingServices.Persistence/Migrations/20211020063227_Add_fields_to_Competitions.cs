using Microsoft.EntityFrameworkCore.Migrations;

namespace ParaglidingServices.Persistence.Migrations
{
    public partial class Add_fields_to_Competitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompetitionName",
                table: "Competitions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompetitionName",
                table: "Competitions");
        }
    }
}
