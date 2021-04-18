using SCreditos.models;
using SCreditos.repos.repocliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.cliente
{
    class EditarRutaClienteUseCase
    {
        public static Cobro editarRutaCliente(Cliente pClienteActual, Cliente pClienteProximo, String pAccion)
        {
            return new RepositoryCliente().editarRutaCliente(pClienteActual, pClienteProximo, pAccion);
        }
    }
}
