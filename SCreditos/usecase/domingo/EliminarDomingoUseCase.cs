using SCreditos.models;
using SCreditos.repos.repodomingo;
using System;

namespace SCreditos.usecase.domingo
{
    class EliminarDomingoUseCase
    {
        public static Cobro eliminarDomingo(String cobro, Prestamo prestamo)
        {
            return new RepositoryDomingo().eliminarDomingo(cobro, prestamo);
        }
    }
}
