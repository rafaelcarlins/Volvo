using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadCaminhoes.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        
        [Required]
        public string Tipo { get; set; }
        
        [Required]
        public string AnoModelo { get; set; }
        
        public string Descricao { get; set; }
    }
}
