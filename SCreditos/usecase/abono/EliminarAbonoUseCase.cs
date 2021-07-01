using SCreditos.models;
using SCreditos.repos.repoabono;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.abono
{
    class EliminarAbonoUseCase
    {
        public static Cobro eliminarAbono(String cobro, Abono abono, Prestamo prestamo, Contabilidad contabilidad)
        {
            return new RepositoryAbono().eliminarAbono(cobro, abono, prestamo, contabilidad);
        }
    }
}
