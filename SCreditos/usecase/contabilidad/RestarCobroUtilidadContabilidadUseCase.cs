using SCreditos.models;
using SCreditos.repos.repocontabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.contabilidad
{
    class RestarCobroUtilidadContabilidadUseCase
    {
        public static List<Contabilidad> restarAbonosAContabilidades(Contabilidad contabilidad, Prestamo prestamo)
        {
            return new RepositoryContabilidad().restarCobroUtilidadContabilidad(contabilidad, prestamo);
        }
    }
}
