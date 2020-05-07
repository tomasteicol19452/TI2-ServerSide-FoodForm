using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodForm.Models
{
    public class Moderadores
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Email referente a esta conta de moderador
        /// </summary>
        [Required(ErrorMessage = "Preenchimento do Email obrigatório.")]
        [StringLength(255, ErrorMessage = "O {0} não pode exceder os {1} caracteres.")]
        [RegularExpression("[A-Za-z0-9#$%&'*+/=?^_`{|}~-]+[@]{1}[A-Za-z0-9]+[.]{1}[A-Za-z]{2,3]")]
        public string Email { get; set; }
    }
}
