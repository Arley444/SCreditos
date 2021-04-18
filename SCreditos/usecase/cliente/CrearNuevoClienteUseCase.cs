using SCreditos.models;
using SCreditos.repos.repocliente;
using System;

namespace SCreditos.usecase
{
    class CrearNuevoClienteUseCase
    {
        public static Cobro crearCliente(String pDespuesDe, int ruta, Cliente cliente)
        {
            return new RepositoryCliente().createCliente(pDespuesDe, ruta, cliente);
        }
    }
}
