using SCreditos.models;
using SCreditos.repos.repoprestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.prestamo
{
    class CalificarPrestamoUseCase
    {
        private static RepositoryPrestamo repository;

        public static void calificarPrestamo(Prestamo prestamo)
        {
            repository = new RepositoryPrestamo();
            repository.calificarPrestamo(prestamo);
        }
    }
}
