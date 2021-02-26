using CadCaminhoes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadCaminhoes.Data
{
    public class CaminhaoContext :DbContext
    {
        public CaminhaoContext(DbContextOptions<CaminhaoContext> options) : base(options)
        {

        }

        public DbSet<Modelo> Modelo { get; set; }

    }
}
