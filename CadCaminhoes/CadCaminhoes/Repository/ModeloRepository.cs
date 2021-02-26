using CadCaminhoes.Data;
using CadCaminhoes.Interface;
using CadCaminhoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadCaminhoes.Repository
{
    public class ModeloRepository : IModelo
    {

        protected readonly CaminhaoContext _dbContext;
        public ModeloRepository(CaminhaoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Modelo> ObterTodos()
        {
            var modelo = (from m in _dbContext.Modelo
                        
                         select new Modelo
                         {
                             Tipo = m.Tipo,
                             AnoModelo = m.AnoModelo,
                             Descricao = m.Descricao
                         }).ToList();
            return (modelo);
        }

    }
}
