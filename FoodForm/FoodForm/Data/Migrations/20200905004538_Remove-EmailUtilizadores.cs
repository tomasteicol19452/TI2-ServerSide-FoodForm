using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodForm.Data.Migrations
{
    public partial class RemoveEmailUtilizadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Receitas_ReceitaFK",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Utilizadores_UtilizadorFK",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Receitas_ReceitaFK",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Utilizadores_UtilizadorFK",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Gostos_Receitas_ReceitaFK",
                table: "Gostos");

            migrationBuilder.DropForeignKey(
                name: "FK_Gostos_Utilizadores_UtilizadorFK",
                table: "Gostos");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Utilizadores_Autor",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "Fotografia",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Utilizadores",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 1,
                column: "UserID",
                value: "1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Receitas_ReceitaFK",
                table: "Comentarios",
                column: "ReceitaFK",
                principalTable: "Receitas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Utilizadores_UtilizadorFK",
                table: "Comentarios",
                column: "UtilizadorFK",
                principalTable: "Utilizadores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Receitas_ReceitaFK",
                table: "Denuncias",
                column: "ReceitaFK",
                principalTable: "Receitas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Utilizadores_UtilizadorFK",
                table: "Denuncias",
                column: "UtilizadorFK",
                principalTable: "Utilizadores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gostos_Receitas_ReceitaFK",
                table: "Gostos",
                column: "ReceitaFK",
                principalTable: "Receitas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gostos_Utilizadores_UtilizadorFK",
                table: "Gostos",
                column: "UtilizadorFK",
                principalTable: "Utilizadores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Utilizadores_Autor",
                table: "Receitas",
                column: "Autor",
                principalTable: "Utilizadores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Receitas_ReceitaFK",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Utilizadores_UtilizadorFK",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Receitas_ReceitaFK",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Utilizadores_UtilizadorFK",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Gostos_Receitas_ReceitaFK",
                table: "Gostos");

            migrationBuilder.DropForeignKey(
                name: "FK_Gostos_Utilizadores_UtilizadorFK",
                table: "Gostos");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Utilizadores_Autor",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Utilizadores");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Utilizadores",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Utilizadores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fotografia",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 1,
                column: "Email",
                value: "ze@mail.com");

            migrationBuilder.UpdateData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 2,
                column: "Email",
                value: "to@mail.com");

            migrationBuilder.UpdateData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 3,
                column: "Email",
                value: "ruca@mail.com");

            migrationBuilder.UpdateData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 4,
                column: "Email",
                value: "joao@mail.com");

            migrationBuilder.UpdateData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 5,
                column: "Email",
                value: "rick@mail.com");

            migrationBuilder.UpdateData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 6,
                column: "Email",
                value: "morty@mail.com");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Receitas_ReceitaFK",
                table: "Comentarios",
                column: "ReceitaFK",
                principalTable: "Receitas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Utilizadores_UtilizadorFK",
                table: "Comentarios",
                column: "UtilizadorFK",
                principalTable: "Utilizadores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Receitas_ReceitaFK",
                table: "Denuncias",
                column: "ReceitaFK",
                principalTable: "Receitas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Utilizadores_UtilizadorFK",
                table: "Denuncias",
                column: "UtilizadorFK",
                principalTable: "Utilizadores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gostos_Receitas_ReceitaFK",
                table: "Gostos",
                column: "ReceitaFK",
                principalTable: "Receitas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gostos_Utilizadores_UtilizadorFK",
                table: "Gostos",
                column: "UtilizadorFK",
                principalTable: "Utilizadores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Utilizadores_Autor",
                table: "Receitas",
                column: "Autor",
                principalTable: "Utilizadores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
