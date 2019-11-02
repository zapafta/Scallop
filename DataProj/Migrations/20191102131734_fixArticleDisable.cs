using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProj.Migrations
{
    public partial class fixArticleDisable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Category_IdCategory",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_EncomendaCabec_UserSite_IdUserSite",
                table: "EncomendaCabec");

            migrationBuilder.DropForeignKey(
                name: "FK_EncomendaLinha_Article_IdArticle",
                table: "EncomendaLinha");

            migrationBuilder.DropForeignKey(
                name: "FK_EncomendaLinha_EncomendaCabec_IdEncomendaCabec",
                table: "EncomendaLinha");

            migrationBuilder.DropIndex(
                name: "IX_EncomendaLinha_IdArticle",
                table: "EncomendaLinha");

            migrationBuilder.DropColumn(
                name: "IdArticle",
                table: "EncomendaLinha");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Category_IdCategory",
                table: "Article",
                column: "IdCategory",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EncomendaCabec_UserSite_IdUserSite",
                table: "EncomendaCabec",
                column: "IdUserSite",
                principalTable: "UserSite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EncomendaLinha_EncomendaCabec_IdEncomendaCabec",
                table: "EncomendaLinha",
                column: "IdEncomendaCabec",
                principalTable: "EncomendaCabec",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Category_IdCategory",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_EncomendaCabec_UserSite_IdUserSite",
                table: "EncomendaCabec");

            migrationBuilder.DropForeignKey(
                name: "FK_EncomendaLinha_EncomendaCabec_IdEncomendaCabec",
                table: "EncomendaLinha");

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
                name: "FK_Article_Category_IdCategory",
                table: "Article",
                column: "IdCategory",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EncomendaCabec_UserSite_IdUserSite",
                table: "EncomendaCabec",
                column: "IdUserSite",
                principalTable: "UserSite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EncomendaLinha_Article_IdArticle",
                table: "EncomendaLinha",
                column: "IdArticle",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EncomendaLinha_EncomendaCabec_IdEncomendaCabec",
                table: "EncomendaLinha",
                column: "IdEncomendaCabec",
                principalTable: "EncomendaCabec",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
