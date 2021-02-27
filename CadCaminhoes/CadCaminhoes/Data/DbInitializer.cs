using CadCaminhoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadCaminhoes.Data
{
    public class DbInitializer
    {
        public static void Initialize(CaminhaoContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Modelos.Any())
            {
                var modelos = new Modelo[]
            {
                //new Modelo { Tipo = "FH", DataModelo = DateTime.Now, Permitido = true},
                //new Modelo {  Tipo = "FM", DataModelo = DateTime.Now, Permitido = true},
                                new Modelo { Tipo = "FH",  Permitido = true},
                new Modelo {  Tipo = "FM", Permitido = true},
            };
                foreach (Modelo s in modelos)
                {
                    context.Modelos.Add(s);
                }
                context.SaveChanges();
            }

        }
    }
}
