using SCreditos.models;
using SCreditos.repos.repocliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.cliente
{
    class EliminarClienteUseCase
    {
        public static Cobro eliminarCliente(String pCobro, Cliente pCliente, int pRuta)
        {
            return new RepositoryCliente().eliminarCliente(pCobro, pCliente, pRuta);
        }
    }
}
