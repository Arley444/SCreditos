using SCreditos.models;
using SCreditos.repos.repocontabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.contabilidad
{
    class GuardarContabilidadesUseCase
    {
        public static List<Contabilidad> guardarContabilidades(List<Contabilidad> pContabilidades, String pCobro)
        {
            return new RepositoryContabilidad().cambiarEstadoContabilidades(pContabilidades, pCobro);
        }
    }
}
