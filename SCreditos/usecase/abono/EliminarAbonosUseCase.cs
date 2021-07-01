using SCreditos.models;
using SCreditos.repos.repoabono;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.abono
{
    class EliminarAbonosUseCase
    {
        public static Cobro eliminarAbonos(String cobro, Prestamo prestamo)
        {
            return new RepositoryAbono().eliminarAbonos(cobro, prestamo);
        }
    }
}
