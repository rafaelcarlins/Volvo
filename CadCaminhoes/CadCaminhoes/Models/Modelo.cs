using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadCaminhoes.Models
{
    public class Modelo
    {
        public int ID { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public DateTime DataModelo { get; set; }
        public bool Permitido { get; set; }

    }
}
