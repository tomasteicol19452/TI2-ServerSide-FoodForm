using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodForm.Models
{
    public class Receitas
    {
        public Receitas()
        {
            ListaDeComentarios = new HashSet<Comentarios>();
        }

        [Key]
        public int ID { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public string Dificuldade { get; set; }

        public int Tempo { get; set; }

        public int PessoasServidas { get; set; }

        public string Ingredientes { get; set; }

        //FK para o criador desta receita
        [ForeignKey(nameof(Utilizador))]
        public int Autor { get; set; }
        public Utilizadores Utilizador { get; set; }

        public ICollection<Comentarios> ListaDeComentarios { get; set; }
    }
}
