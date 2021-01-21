using SCreditos.models;
using SCreditos.repos.repocontabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.contabilidad
{
    class ConsultarContabilidadesFechaCobro
    {
        public static List<Contabilidad> consultarContabilidadFechaCobro(Cobro cobro, String pFecha)
        {
            return new RepositoryContabilidad().findByCobroAndDate(cobro.getNombre(), pFecha);
        }
    }
}
