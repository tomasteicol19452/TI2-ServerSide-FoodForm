using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodForm.Models
{
    public class Denuncias
    {
        [Key]
        public int ID { get; set; }

        public DateTime Data { get; set; }

        public string Conteudo { get; set; }

        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; }
        public Utilizadores Utilizador { get; set; }

        [ForeignKey(nameof(Receita))]
        public int ReceitaFK { get; set; }
        public Receitas Receita { get; set; }
    }
}
