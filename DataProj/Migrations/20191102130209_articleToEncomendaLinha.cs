using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProj.Migrations
{
    public partial class articleToEncomendaLinha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoUnit",
                table: "EncomendaLinha",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<Guid>(
                name: "IdArticle",
                table: "EncomendaLinha",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EncomendaLinha_IdArticle",
                table: "EncomendaLinha",
                column: "IdArticle");

            migrationBuilder.AddForeignKey(
                name: "FK_EncomendaLinha_Article_IdArticle",
                table: "EncomendaLinha",
                column: "IdArticle",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncomendaLinha_Article_IdArticle",
                table: "EncomendaLinha");

            migrationBuilder.DropIndex(
                name: "IX_EncomendaLinha_IdArticle",
                table: "EncomendaLinha");

            migrationBuilder.DropColumn(
                name: "IdArticle",
                table: "EncomendaLinha");

            migrationBuilder.AlterColumn<double>(
                name: "PrecoUnit",
                table: "EncomendaLinha",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
