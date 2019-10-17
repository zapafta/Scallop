using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProj.Migrations
{
    public partial class addImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleImage");

            migrationBuilder.AddColumn<Guid>(
                name: "ArticleId",
                table: "Image",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_ArticleId",
                table: "Image",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Article_ArticleId",
                table: "Image",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Article_ArticleId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ArticleId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Image");

            migrationBuilder.CreateTable(
                name: "ArticleImage",
                columns: table => new
                {
                    IdArticle = table.Column<Guid>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleImage", x => new { x.IdArticle, x.IdImage });
                    table.ForeignKey(
                        name: "FK_ArticleImage_Article_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleImage_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImage_IdImage",
                table: "ArticleImage",
                column: "IdImage");
        }
    }
}
