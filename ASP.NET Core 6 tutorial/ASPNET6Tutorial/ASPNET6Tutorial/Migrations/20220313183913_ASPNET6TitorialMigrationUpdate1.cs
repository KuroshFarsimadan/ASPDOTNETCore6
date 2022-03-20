using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNET6Tutorial.Migrations
{
    public partial class ASPNET6TitorialMigrationUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PointOfInterest",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PointOfInterest");
        }
    }
}
