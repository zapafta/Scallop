using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProj.Migrations
{
    public partial class addNamedss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeUtilizador",
                table: "EncomendaCabec",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeUtilizador",
                table: "EncomendaCabec");
        }
    }
}
