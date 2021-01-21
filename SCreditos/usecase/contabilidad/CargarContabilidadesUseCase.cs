using SCreditos.models;
using SCreditos.repos.repocontabilidad;
using System;
using System.Collections.Generic;

namespace SCreditos.usecase.contabilidad
{
    class CargarContabilidadesUseCase
    {
        public static List<Contabilidad> cargarContabilidades(Cobro cobro)
        {
            return new RepositoryContabilidad().findAllByCobro(cobro.getNombre());
        }
    }
}
