using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FoodForm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodForm.Data
{
    /// <summary>
    /// Construtor da classe que serve tambem para ligar a classe à base de dados
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Preenchimento do {0} obrigatório.")]
        [StringLength(40, ErrorMessage = "O {0} não pode exceder os {1} caracteres.")]
        [RegularExpression("[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+(( | d[ao](s)? | e |-|'| d')[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+){1,3}")]
        public string Nome { get; set; }

        [StringLength(255, ErrorMessage = "O nome do ficheiro não pode exceder os {1} caracteres.")]
        [RegularExpression("[A-Za-z0-9]+(.jpg|.png){1}")]
        
        public DateTime Timestamp { get; set; }
    }


    public class FoodFormDB : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Construtor da classe que serve tambem para ligar a classe à base de dados
        /// </summary>
        /// <param name="options"></param>
        public FoodFormDB(DbContextOptions<FoodFormDB> options)
            : base(options)
        {
        }

        /// <summary>
        /// Inserção da seed na base de dados
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);//importar o que havia no onModelCreating


            modelBuilder.Entity<Utilizadores>().HasData(
               new Utilizadores { ID = 1, Nome = "Zé", Imagem = "ze.jpg", UserID="1" },
               new Utilizadores { ID = 2, Nome = "Tó", Imagem = "to.jpg" },
               new Utilizadores { ID = 3, Nome = "Ruca", Imagem = "ruca.jpg" },
               new Utilizadores { ID = 4, Nome = "João", Imagem = "joao.jpg" },
               new Utilizadores { ID = 5, Nome = "Rick", Imagem = "rick.jpg" },
               new Utilizadores { ID = 6, Nome = "Morty", Imagem = "morty.png" }
                );

            modelBuilder.Entity<Moderadores>().HasData(
               new Moderadores { ID = 1, Email = "mod@mail.com" }
                );

            modelBuilder.Entity<Receitas>().HasData(
               new Receitas
               {
                   ID = 1,
                   Titulo = "Leite com cereais",
                   Descricao = "Receita deliciosa! Adiciona-se 60g de cereais a uma taça, e depois 250ml de leite. Nunca o reverso!",
                   Ingredientes = "Leite; Cereais;",
                   Tempo = 1,
                   Dificuldade = "Fácil",
                   PessoasServidas = 1,
                   Autor = 1,
                   Imagem = "cereais.jpg"
               },
               new Receitas
               {
                   ID = 2,
                   Titulo = "Pão com manteiga",
                   Descricao = "O clássico lanche. Uma bola ou papo-seco e manteiga. Simples!",
                   Ingredientes = "Pão; Manteiga;",
                   Tempo = 1,
                   Dificuldade = "Fácil",
                   PessoasServidas = 1,
                   Autor = 1,
                   Imagem = "pao.jpg"
               }
                );
        }

        /// <summary>
        /// Modelos das tabelas a serem adicionados a base de dados
        /// </summary>
        public DbSet<Utilizadores> Utilizadores { get; set; }
        public DbSet<Receitas> Receitas { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Gostos> Gostos { get; set; }
        public DbSet<Moderadores> Moderadores { get; set; }
        public DbSet<Denuncias> Denuncias { get; set; }
    }
}
