using SCreditos.models;
using SCreditos.repos.repocartera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.cartera
{
    class ConsultarCarterasUseCase
    {
        public static List<Cartera> consultarCarteras(String pCobro)
        {
            return new RepositoryCartera().findAll(pCobro);
        }
    }
}
