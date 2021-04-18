using SCreditos.models;
using SCreditos.repos.repoprestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.prestamo
{
    class EnviarClavoUseCase
    {
        public static Cobro enviarClavo(Cobro cobro, Prestamo prestamo, DateTime fecha)
        {
            return new RepositoryPrestamo().enviarClavo(cobro, prestamo, fecha);
        }
    }
}
