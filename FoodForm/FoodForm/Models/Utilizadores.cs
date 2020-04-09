using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodForm.Models
{
    public class Utilizadores
    {
        public Utilizadores()
        {
            ListaDeReceitas = new HashSet<Receitas>(); //coloca os dados na lista -> seleciona a os valores da tabela das receitas onde este utilizador está associado como criador
        }

        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public int Password { get; set; }

        public string Imagem { get; set; }

        //lista de Receitas a que um Utilizador está associado
        public ICollection<Receitas> ListaDeReceitas { get; set; }
    }
}
