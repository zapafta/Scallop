using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataProj.Migrations
{
    public partial class addCabecEncomendaUserAndlinha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EncomendaCabec",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Payment = table.Column<bool>(nullable: false),
                    Localidade = table.Column<string>(nullable: false),
                    Morada = table.Column<string>(nullable: false),
                    CodPostal = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncomendaCabec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSite",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EncomendaLinha",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdEncomendaCabec = table.Column<Guid>(nullable: false),
                    IsPayment = table.Column<bool>(nullable: false),
                    PrecoUnit = table.Column<double>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateModification = table.Column<DateTime>(nullable: false),
                    UserCreation = table.Column<string>(nullable: false),
                    IdUserSite = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncomendaLinha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncomendaLinha_EncomendaCabec_IdEncomendaCabec",
                        column: x => x.IdEncomendaCabec,
                        principalTable: "EncomendaCabec",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncomendaLinha_UserSite_IdUserSite",
                        column: x => x.IdUserSite,
                        principalTable: "UserSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EncomendaLinha_IdEncomendaCabec",
                table: "EncomendaLinha",
                column: "IdEncomendaCabec");

            migrationBuilder.CreateIndex(
                name: "IX_EncomendaLinha_IdUserSite",
                table: "EncomendaLinha",
                column: "IdUserSite");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncomendaLinha");

            migrationBuilder.DropTable(
                name: "EncomendaCabec");

            migrationBuilder.DropTable(
                name: "UserSite");
        }
    }
}
