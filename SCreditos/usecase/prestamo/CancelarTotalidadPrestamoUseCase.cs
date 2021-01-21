using SCreditos.models;
using SCreditos.repos.repoprestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.prestamo
{
    class CancelarTotalidadPrestamoUseCase
    {
        public static Cobro cancelarTotalidadPrestamo(Cobro cobro, DateTime fecha, Prestamo prestamo)
        {
            return new RepositoryPrestamo().cancelarTotalidadPrestamo(fecha, cobro, prestamo);
        }
    }
}
