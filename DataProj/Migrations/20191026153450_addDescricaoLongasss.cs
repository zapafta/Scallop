using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProj.Migrations
{
    public partial class addDescricaoLongasss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescricaoLonga",
                table: "Article",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoLonga",
                table: "Article");
        }
    }
}
