using SCreditos.models;
using SCreditos.repos.repoprestamo;

namespace SCreditos.usecase.prestamo
{
    class CrearNuevoPrestamoUseCase
    {
        public static Cobro crearNuevoPrestamo(Cobro cobro, Prestamo prestamo)
        {
            return new RepositoryPrestamo().crearNuevoPrestamo(cobro, prestamo);
        }
    }
}
