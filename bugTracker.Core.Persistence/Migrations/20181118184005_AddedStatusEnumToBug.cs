using Microsoft.EntityFrameworkCore.Migrations;

namespace bugTracker.Core.Persistence.Migrations
{
    public partial class AddedStatusEnumToBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "bugs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "bugs");
        }
    }
}
