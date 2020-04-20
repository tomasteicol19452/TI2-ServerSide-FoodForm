using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodForm.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moderadores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moderadores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    Imagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Imagem = table.Column<string>(nullable: true),
                    UtilizadorFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Receitas_Utilizadores_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    Conteudo = table.Column<string>(nullable: true),
                    UtilizadorFK = table.Column<int>(nullable: false),
                    ReceitaFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comentarios_Receitas_ReceitaFK",
                        column: x => x.ReceitaFK,
                        principalTable: "Receitas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentarios_Utilizadores_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Denuncias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    Conteudo = table.Column<string>(nullable: true),
                    UtilizadorFK = table.Column<int>(nullable: false),
                    ReceitaFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Denuncias_Receitas_ReceitaFK",
                        column: x => x.ReceitaFK,
                        principalTable: "Receitas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Denuncias_Utilizadores_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gostos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gosto = table.Column<bool>(nullable: false),
                    UtilizadorFK = table.Column<int>(nullable: false),
                    ReceitaFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gostos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gostos_Receitas_ReceitaFK",
                        column: x => x.ReceitaFK,
                        principalTable: "Receitas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gostos_Utilizadores_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ReceitaFK",
                table: "Comentarios",
                column: "ReceitaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UtilizadorFK",
                table: "Comentarios",
                column: "UtilizadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_ReceitaFK",
                table: "Denuncias",
                column: "ReceitaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_UtilizadorFK",
                table: "Denuncias",
                column: "UtilizadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Gostos_ReceitaFK",
                table: "Gostos",
                column: "ReceitaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Gostos_UtilizadorFK",
                table: "Gostos",
                column: "UtilizadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_UtilizadorFK",
                table: "Receitas",
                column: "UtilizadorFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Denuncias");

            migrationBuilder.DropTable(
                name: "Gostos");

            migrationBuilder.DropTable(
                name: "Moderadores");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
