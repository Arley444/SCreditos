using SCreditos.models;
using SCreditos.repos.repocliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.cliente
{
    class EditarNombreClienteUseCase
    {
        public static Cobro editarNombreCliente(String pNombre, int pId, String pCobroDelcliente)
        {
            return new RepositoryCliente().editarNombre(pNombre, pId, pCobroDelcliente);
        }
    }
}
