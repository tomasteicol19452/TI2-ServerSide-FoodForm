using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodForm.Models
{
    public class Gostos
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Valor que define se foi gostada ou desgostada a receita, podendo-se atribuir um gosto ou desgosto por receita. Valores true = gostou.
        /// </summary>
        public Boolean Gosto { get; set; }

        /// <summary>
        /// Utilizador responsavel pelo gosto
        /// </summary>
        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; }
        public Utilizadores Utilizador { get; set; }

        /// <summary>
        /// Receita gostada
        /// </summary>
        [ForeignKey(nameof(Receita))]
        public int ReceitaFK { get; set; }
        public Receitas Receita{ get; set; }
    }
}
