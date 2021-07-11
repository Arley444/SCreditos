using SCreditos.models;
using SCreditos.repos.repocliente;
using System;

namespace SCreditos.usecase.cliente
{
    class EditarTelefonoClienteUseCase
    {
        public static Cobro editarTelefonoCliente(String pTelefono, int pId, String pCobroDelcliente)
        {
            return new RepositoryCliente().editarTelefono(pTelefono, pId, pCobroDelcliente);
        }
    }
}
