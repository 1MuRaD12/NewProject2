using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class createslider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titles",
                table: "sliders",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titles",
                table: "sliders");
        }
    }
}
