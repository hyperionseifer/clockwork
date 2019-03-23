using Microsoft.EntityFrameworkCore.Migrations;

namespace Clockwork.API.Migrations
{
    public partial class SchemaUpdatesV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Timezone",
                table: "CurrentTimeQueries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimezoneId",
                table: "CurrentTimeQueries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timezone",
                table: "CurrentTimeQueries");

            migrationBuilder.DropColumn(
                name: "TimezoneId",
                table: "CurrentTimeQueries");
        }
    }
}
