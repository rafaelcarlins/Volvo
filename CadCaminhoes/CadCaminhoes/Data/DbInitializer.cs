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

            if (context.Modelos.Any())
            {
                return;   // DB has been seeded
            }

            var modelos = new Modelo[]
            {
                new Modelo { Tipo= "FH", DataModelo="2021-02-26"},
                new Modelo {  Tipo= "FM", DataModelo="2021-02-26"},
            };
            foreach (Modelo s in modelos)
            {
                context.Modelos.Add(s);
            }
            context.SaveChanges();

        }
    }
}
