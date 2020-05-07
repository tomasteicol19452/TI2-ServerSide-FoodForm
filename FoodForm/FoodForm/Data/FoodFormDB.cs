using FoodForm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodForm.Data
{
    /// <summary>
    /// classe que define uma, neste caso a unica, base de dados para utilizar no projecto
    /// </summary>
    public class FoodFormDB : DbContext
    {
        /// <summary>
        /// construtor da classe que serve tambem para ligar a classe à base de dados
        /// </summary>
        /// <param name="options"></param>
        public FoodFormDB(DbContextOptions<FoodFormDB> options) : base(options) { }

        /// <summary>
        /// Inserção da seed na base de dados
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilizadores>().HasData(
               new Utilizadores { ID = 1, Nome = "Zé", Email = "ze@mail.com", Imagem = "ze.jpg" },
               new Utilizadores { ID = 2, Nome = "Tó", Email = "to@mail.com", Imagem = "to.jpg" },
               new Utilizadores { ID = 3, Nome = "Ruca", Email = "ruca@mail.com", Imagem = "ruca.jpg" },
               new Utilizadores { ID = 4, Nome = "João", Email = "joao@mail.com", Imagem = "joao.jpg" },
               new Utilizadores { ID = 5, Nome = "Rick", Email = "rick@mail.com", Imagem = "rick.jpg" },
               new Utilizadores { ID = 6, Nome = "Morty", Email = "morty@mail.com", Imagem = "morty.png" }
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
                   Titulo = "Pão com manteiga.",
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
