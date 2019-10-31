using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProj.Migrations
{
    public partial class FixEncomendaCabec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncomendaLinha_UserSite_IdUserSite",
                table: "EncomendaLinha");

            migrationBuilder.DropIndex(
                name: "IX_EncomendaLinha_IdUserSite",
                table: "EncomendaLinha");

            migrationBuilder.DropColumn(
                name: "IdUserSite",
                table: "EncomendaLinha");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUserSite",
                table: "EncomendaCabec",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EncomendaCabec_IdUserSite",
                table: "EncomendaCabec",
                column: "IdUserSite");

            migrationBuilder.AddForeignKey(
                name: "FK_EncomendaCabec_UserSite_IdUserSite",
                table: "EncomendaCabec",
                column: "IdUserSite",
                principalTable: "UserSite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncomendaCabec_UserSite_IdUserSite",
                table: "EncomendaCabec");

            migrationBuilder.DropIndex(
                name: "IX_EncomendaCabec_IdUserSite",
                table: "EncomendaCabec");

            migrationBuilder.DropColumn(
                name: "IdUserSite",
                table: "EncomendaCabec");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUserSite",
                table: "EncomendaLinha",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EncomendaLinha_IdUserSite",
                table: "EncomendaLinha",
                column: "IdUserSite");

            migrationBuilder.AddForeignKey(
                name: "FK_EncomendaLinha_UserSite_IdUserSite",
                table: "EncomendaLinha",
                column: "IdUserSite",
                principalTable: "UserSite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
