using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProj.Migrations
{
    public partial class addOrdenacaoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ordenacao",
                table: "Article",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ordenacao",
                table: "Article");
        }
    }
}
