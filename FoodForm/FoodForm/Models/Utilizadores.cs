using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodForm.Models
{
    public class Utilizadores
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public int Password { get; set; }

        public string Imagem { get; set; }
    }
}
