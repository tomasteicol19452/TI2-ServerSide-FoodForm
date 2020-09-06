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

        /// <summary>
        /// Nome do prato ou receita descrita no post
        /// </summary>
        [Required(ErrorMessage = "Preenchimento do {0} obrigatório.")]
        public string Titulo { get; set; }

        /// <summary>
        /// Receita effectiva e/ou modo de praparação da receita
        /// </summary>
        [Required(ErrorMessage = "Preenchimento da {0} obrigatória.")]
        public string Descricao { get; set; }

        /// <summary>
        /// Referencia da imagem respectiva ao prato
        /// </summary>
        [StringLength(255, ErrorMessage = "O nome do ficheiro não pode exceder os {1} caracteres.")]
        [RegularExpression("[A-Za-z0-9]+(.jpg|.png){1}", ErrorMessage ="Esse formato de ficheiro não é válido.")]
        public string Imagem { get; set; }

        /// <summary>
        /// Dificuldade de confeção da receita geralmente categorizado por Fácil, Média, Difícil
        /// </summary>
        [Required(ErrorMessage = "Preenchimento da {0} obrigatória.")]
        [RegularExpression("(Fácil|Intermédio|Difícil){1}")]
        public string Dificuldade { get; set; }

        /// <summary>
        /// Tempo médio que demora a preparação e cofeção do prato em minutos
        /// </summary>
        [Required(ErrorMessage = "Preenchimento do {0} obrigatório.")]
        [RegularExpression("[1-9]{1}[0-9]{0,3}", ErrorMessage ="Entre 1 e 4 dígitos.")]
        public int Tempo { get; set; }

        /// <summary>
        /// Numero de pessoas que a dose referenciada na receita serve normalmente
        /// </summary>
        [Required(ErrorMessage = "Preenchimento das {0} é obrigatório.")]
        [RegularExpression("[1-9]{1}[0-9]{0,1}", ErrorMessage = "Numero de pessoas deve ser entre 1 e 99.")]
        public int PessoasServidas { get; set; }

        /// <summary>
        /// Ingredientes base presentes na receita
        /// </summary>
        [RegularExpression("[A-ZÓÂÍa-zçáéíóúàèìòùãõäëïöüâêîôûñ ]+[;]", ErrorMessage ="Os ingredientes devem estar separados por ';'.")]
        public string Ingredientes { get; set; }

        /// <summary>
        /// Utilizador que criou esta receita (ou versão dela) 
        /// </summary>
        [ForeignKey(nameof(Utilizador))]
        public int Autor { get; set; }
        public Utilizadores Utilizador { get; set; }

        /// <summary>
        /// Lista de comentários feitos a esta receita
        /// </summary>
        public ICollection<Comentarios> ListaDeComentarios { get; set; }
    }
}
