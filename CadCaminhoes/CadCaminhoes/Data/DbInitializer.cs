using CadCaminhoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadCaminhoes.Data
{
    public class DbInitializer
    {
        public static void Initialize(CaminhaoContext caminhao)
        {
            if (caminhao.Modelo.Any())
            {
                return;
            }
            else
            {
                var modelo = new Modelo[]
                {
                    new Modelo()
                    {
                        Tipo="FH",
                        AnoModelo= Convert.ToString( DateTime.Today),
                    }
                };
            }
        }
    }
}
