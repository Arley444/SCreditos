using SCreditos.models;
using SCreditos.repos.repocliente;
using System;

namespace SCreditos.usecase.cliente
{
    class EditarCedulaClienteUseCase
    {
        public static Cobro editarCedulaCliente(String pCedula, String pIdCliente, String pCobro)
        {
            return new RepositoryCliente().editarCedula(pCedula, pIdCliente, pCobro);
        }
    }
}
