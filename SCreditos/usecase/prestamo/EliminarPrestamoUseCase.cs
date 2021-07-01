using SCreditos.models;
using SCreditos.repos.repoprestamo;
using System;

namespace SCreditos.usecase.prestamo
{
    class EliminarPrestamoUseCase
    {
        public static Cobro eliminarPrestamo(String cobro, Prestamo prestamo)
        {
            return new RepositoryPrestamo().eliminarPrestamo(cobro, prestamo);
        }
    }
}
