using SCreditos.repos.repocliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.cliente
{
    class ExisteClienteUseCase
    {
        public static Boolean existeCliente(String pCedula)
        {
            return new RepositoryCliente().existeCliente(pCedula);
        }
    }
}
