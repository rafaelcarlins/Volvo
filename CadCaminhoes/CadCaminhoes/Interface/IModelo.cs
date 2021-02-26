using CadCaminhoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadCaminhoes.Interface
{
    public interface IModelo
    {

        IEnumerable<Modelo> ObterTodos();
    }
}
