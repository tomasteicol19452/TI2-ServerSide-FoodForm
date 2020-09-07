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

        /// <summary>
        /// Denuncia da receita em questão no caso de ser imprópria. O moderador depois de rever a denuncia, elimina a denuncia e/ou apaga a receita.
        /// </summary>
        [Required(ErrorMessage = "Preenchimento do {0} obrigatório.")]        
        public string Conteudo { get; set; }

        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; }
        public Utilizadores Utilizador { get; set; }

        [ForeignKey(nameof(Receita))]
        public int ReceitaFK { get; set; }
        public Receitas Receita { get; set; }
    }
}
