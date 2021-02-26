using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadCaminhoes.Models
{
    public class Caminhao
    {
        public int Id { get; set; }
        public string AnoFabricacao { get; set; }
        public Modelo Modelo { get; set; }

    }
}
