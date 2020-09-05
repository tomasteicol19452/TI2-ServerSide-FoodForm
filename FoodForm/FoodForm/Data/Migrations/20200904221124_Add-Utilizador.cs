using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodForm.Data.Migrations
{
    public partial class AddUtilizador : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Utilizadores",
                nullable: true);

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
                name: "UserName",
                table: "Utilizadores");

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
