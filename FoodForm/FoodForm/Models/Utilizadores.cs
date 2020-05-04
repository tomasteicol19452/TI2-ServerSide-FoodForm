using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodForm.Models
{
    public class Utilizadores
    {
        public Utilizadores()
        {
            MinhasReceitas = new HashSet<Receitas>(); //coloca os dados na lista -> seleciona a os valores da tabela das receitas onde este utilizador está associado como criador
            ReceitasGostadas = new HashSet<Receitas>();
        }

        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Nome que identifica o Utilizador
        /// </summary>
        [Required(ErrorMessage = "Preenchimento do {0} obrigatório.")]
        [StringLength(40, ErrorMessage ="O {0} não pode exceder os {1} caracteres.")]
        [RegularExpression("[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+(( | d[ao](s)? | e |-|'| d')[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+){1,3}")]
        public string Nome { get; set; }

        /// <summary>
        /// Endereço de correio electronico do utilizador
        /// </summary>
        [Required(ErrorMessage = "Preenchimento do Email obrigatório.")]
        [StringLength(255, ErrorMessage = "O {0} não pode exceder os {1} caracteres.")]
        [RegularExpression("[A-Za-z0-9#$%&'*+/=?^_`{|}~-]+[@]{1}[A-Za-z0-9]+[.]{1}[A-Za-z]{2,3]")]
        public string Email { get; set; }

        /// <summary>
        /// Referencia remetente á localização do ficheiro de imagem deste utilizador
        /// </summary>
        [StringLength(255, ErrorMessage = "O nome do ficheiro não pode exceder os {1} caracteres.")]
        [RegularExpression("[A-Za-z0-9]+(.jpg|.png){1}")]
        public string Imagem { get; set; }

        /// <summary>
        /// Lista de receitas criadas por este utilizador
        /// </summary>
        [InverseProperty("Utilizador")]
        public ICollection<Receitas> MinhasReceitas { get; set; }

        /// <summary>
        /// Lista de receitas que este utilizador gostou
        /// </summary>
        public ICollection<Receitas> ReceitasGostadas { get; set; }
    }
}
