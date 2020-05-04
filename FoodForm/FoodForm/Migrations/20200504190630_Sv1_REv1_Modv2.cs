using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodForm.Migrations
{
    public partial class Sv1_REv1_Modv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Moderadores");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Utilizadores",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Utilizadores",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Utilizadores",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Receitas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Dificuldade",
                table: "Receitas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Receitas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Conteudo",
                table: "Denuncias",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Conteudo",
                table: "Comentarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                    { 6, "morty@mail.com", "morty.jpg", "Morty" }
                });

            migrationBuilder.InsertData(
                table: "Receitas",
                columns: new[] { "ID", "Autor", "Descricao", "Dificuldade", "Imagem", "Ingredientes", "PessoasServidas", "Tempo", "Titulo", "UtilizadoresID" },
                values: new object[] { 1, 1, "Receita deliciosa! Adiciona-se 60g de cereais a uma taça, e depois 250ml de leite. Nunca o reverso!", "Fácil", "cereais.jpg", "Leite; Cereais;", 1, 1, "Leite com cereais", null });

            migrationBuilder.InsertData(
                table: "Receitas",
                columns: new[] { "ID", "Autor", "Descricao", "Dificuldade", "Imagem", "Ingredientes", "PessoasServidas", "Tempo", "Titulo", "UtilizadoresID" },
                values: new object[] { 2, 1, "O clássico lanche. Uma bola ou papo-seco e manteiga. Simples!", "Fácil", "pao.jpg", "Pão; Manteiga;", 1, 1, "Pão com manteiga.", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Moderadores",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Receitas",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Receitas",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Utilizadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Utilizadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Utilizadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Receitas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Dificuldade",
                table: "Receitas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Receitas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Moderadores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Conteudo",
                table: "Denuncias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Conteudo",
                table: "Comentarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
