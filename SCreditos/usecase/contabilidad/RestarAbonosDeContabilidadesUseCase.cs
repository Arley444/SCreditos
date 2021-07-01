using SCreditos.models;
using SCreditos.repos.repocontabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.contabilidad
{
    class RestarAbonosDeContabilidadesUseCase
    {
        public static List<Contabilidad> restarAbonosAContabilidades(List<Abono> abonos, List<Contabilidad> contabilidads)
        {
            return new RepositoryContabilidad().restarAbonoContabilidad(abonos, contabilidads);
        }
    }
}
