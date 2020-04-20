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
        //adicionar as tables à base de dados
        public DbSet<Utilizadores> Utilizadores { get; set; }
        public DbSet<Receitas> Receitas { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Gostos> Gostos { get; set; }
        public DbSet<Moderadores> Moderadores { get; set; }
        public DbSet<Denuncias> Denuncias { get; set; }
    }
}
