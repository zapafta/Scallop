using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProj.Migrations
{
    public partial class fixArticleDisableDes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ArticleID",
                table: "EncomendaLinha",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EncomendaLinha_ArticleID",
                table: "EncomendaLinha",
                column: "ArticleID");

            migrationBuilder.AddForeignKey(
                name: "FK_EncomendaLinha_Article_ArticleID",
                table: "EncomendaLinha",
                column: "ArticleID",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncomendaLinha_Article_ArticleID",
                table: "EncomendaLinha");

            migrationBuilder.DropIndex(
                name: "IX_EncomendaLinha_ArticleID",
                table: "EncomendaLinha");

            migrationBuilder.DropColumn(
                name: "ArticleID",
                table: "EncomendaLinha");
        }
    }
}
