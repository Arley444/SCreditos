using SCreditos.models;
using SCreditos.repos.repocobro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.cobro
{
    class CargarCobrosUseCase
    {
        public static List<Cobro> cargarCobros()
        {
            return new RepositoryCobro().findAll();
        }
    }
}
