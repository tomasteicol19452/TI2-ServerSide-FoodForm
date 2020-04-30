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

        [Required(ErrorMessage = "Preenchimento do {0} obrigatório.")]
        [StringLength(40, ErrorMessage ="O {0} não pode exceder os {1} caracteres.")]
        [RegularExpression("[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+(( | d[ao](s)? | e |-|'| d')[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+){1,3}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preenchimento do Email obrigatório.")]
        public string Email { get; set; }

        public string Imagem { get; set; }

        //lista de Receitas a que um Utilizador está associado
        [InverseProperty("Utilizador")]
        public ICollection<Receitas> MinhasReceitas { get; set; }

        //lista de receitas que o utilizador gostou (mais ou menos os favoritos)
        public ICollection<Receitas> ReceitasGostadas { get; set; }
    }
}
