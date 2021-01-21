using SCreditos.repos.repocontabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.contabilidad
{
    class ExisteContabilidadEnLaFecha
    {
        public static Boolean existe(String pCobro, String pFecha)
        {
            return new RepositoryContabilidad().contabilidadesDespues(pCobro, pFecha);
        }
    }
}
