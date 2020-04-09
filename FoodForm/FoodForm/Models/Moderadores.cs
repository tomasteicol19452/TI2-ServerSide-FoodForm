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

        public int Email { get; set; }

        public int Password { get; set; }
    }
}
