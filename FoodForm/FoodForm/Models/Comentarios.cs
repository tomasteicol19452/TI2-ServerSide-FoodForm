﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodForm.Models
{
    public class Comentarios
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Data em que o comentário é escrito e submetido
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Conteudo do comentário
        /// </summary>
        [Required(ErrorMessage = "Preenchimento do {0} obrigatório.")]
        public string Conteudo { get; set; }

        /// <summary>
        /// Utilizador que comentou a receita
        /// </summary>
        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; }
        public Utilizadores Utilizador { get; set; }

        /// <summary>
        /// Receita comentada
        /// </summary>
        [ForeignKey(nameof(Receita))]
        public int ReceitaFK { get; set; }
        public Receitas Receita { get; set; }
    }
}
