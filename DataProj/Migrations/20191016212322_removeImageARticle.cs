using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProj.Migrations
{
    public partial class removeImageARticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Image_IdImage",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_IdImage",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "IdImage",
                table: "Article");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdImage",
                table: "Article",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Article_IdImage",
                table: "Article",
                column: "IdImage");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Image_IdImage",
                table: "Article",
                column: "IdImage",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
