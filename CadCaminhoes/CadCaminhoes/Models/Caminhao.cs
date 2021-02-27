using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadCaminhoes.Models
{
    public class Caminhao
    {
        public int CaminhaoID { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public DateTime AnoFabricacao { get; set; }
        [Required]
        public DateTime DataModelo { get; set; }
        public int ModeloID { get; set; }
        public Modelo Modelo { get; set; }
    }
}
