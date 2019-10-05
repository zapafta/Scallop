using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProj.Migrations
{
    public partial class removeOptiona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Category_IdCategory",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Article_Image_IdImage",
                table: "Article");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdImage",
                table: "Article",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdCategory",
                table: "Article",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Category_IdCategory",
                table: "Article",
                column: "IdCategory",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Image_IdImage",
                table: "Article",
                column: "IdImage",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Category_IdCategory",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Article_Image_IdImage",
                table: "Article");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdImage",
                table: "Article",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "IdCategory",
                table: "Article",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Category_IdCategory",
                table: "Article",
                column: "IdCategory",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Image_IdImage",
                table: "Article",
                column: "IdImage",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
