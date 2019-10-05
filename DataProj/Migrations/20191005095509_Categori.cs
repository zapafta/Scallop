using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProj.Migrations
{
    public partial class Categori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdCategory",
                table: "Article",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_IdCategory",
                table: "Article",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Category_IdCategory",
                table: "Article",
                column: "IdCategory",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Category_IdCategory",
                table: "Article");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Article_IdCategory",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Article");
        }
    }
}
