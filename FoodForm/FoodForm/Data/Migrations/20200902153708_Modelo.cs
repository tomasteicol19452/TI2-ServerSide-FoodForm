using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodForm.Data.Migrations
{
    public partial class Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fotografia",
                table: "AspNetUsers",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Moderadores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 255, nullable: false)
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
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Imagem = table.Column<string>(maxLength: 255, nullable: true)
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
                    Titulo = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Imagem = table.Column<string>(nullable: true),
                    Dificuldade = table.Column<string>(nullable: false),
                    Tempo = table.Column<int>(nullable: false),
                    PessoasServidas = table.Column<int>(nullable: false),
                    Ingredientes = table.Column<string>(nullable: true),
                    Autor = table.Column<int>(nullable: false),
                    UtilizadoresID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Receitas_Utilizadores_Autor",
                        column: x => x.Autor,
                        principalTable: "Utilizadores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receitas_Utilizadores_UtilizadoresID",
                        column: x => x.UtilizadoresID,
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
                    Conteudo = table.Column<string>(nullable: false),
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
                    Conteudo = table.Column<string>(nullable: false),
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

            migrationBuilder.InsertData(
                table: "Moderadores",
                columns: new[] { "ID", "Email" },
                values: new object[] { 1, "mod@mail.com" });

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "ID", "Email", "Imagem", "Nome" },
                values: new object[,]
                {
                    { 1, "ze@mail.com", "ze.jpg", "Zé" },
                    { 2, "to@mail.com", "to.jpg", "Tó" },
                    { 3, "ruca@mail.com", "ruca.jpg", "Ruca" },
                    { 4, "joao@mail.com", "joao.jpg", "João" },
                    { 5, "rick@mail.com", "rick.jpg", "Rick" },
                    { 6, "morty@mail.com", "morty.png", "Morty" }
                });

            migrationBuilder.InsertData(
                table: "Receitas",
                columns: new[] { "ID", "Autor", "Descricao", "Dificuldade", "Imagem", "Ingredientes", "PessoasServidas", "Tempo", "Titulo", "UtilizadoresID" },
                values: new object[] { 1, 1, "Receita deliciosa! Adiciona-se 60g de cereais a uma taça, e depois 250ml de leite. Nunca o reverso!", "Fácil", "cereais.jpg", "Leite; Cereais;", 1, 1, "Leite com cereais", null });

            migrationBuilder.InsertData(
                table: "Receitas",
                columns: new[] { "ID", "Autor", "Descricao", "Dificuldade", "Imagem", "Ingredientes", "PessoasServidas", "Tempo", "Titulo", "UtilizadoresID" },
                values: new object[] { 2, 1, "O clássico lanche. Uma bola ou papo-seco e manteiga. Simples!", "Fácil", "pao.jpg", "Pão; Manteiga;", 1, 1, "Pão com manteiga", null });

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
                name: "IX_Receitas_Autor",
                table: "Receitas",
                column: "Autor");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_UtilizadoresID",
                table: "Receitas",
                column: "UtilizadoresID");
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

            migrationBuilder.DropColumn(
                name: "Fotografia",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "AspNetUsers");
        }
    }
}
