using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCreditos.models;
using SCreditos.repos.repocliente;

namespace SCreditos.usecase.cliente
{
    class EditarDireccionClienteUseCase
    {
        internal static Cobro editarDireccionCliente(String pDireccion, int pId, String pCobro)
        {
            return new RepositoryCliente().editarDireccion(pDireccion, pId, pCobro);
        }
    }
}
