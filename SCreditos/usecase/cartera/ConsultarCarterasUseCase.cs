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

        public static Cartera consultarUltimaCartera(String pCobro)
        {
            return new RepositoryCartera().obtenerUltimaCartera(pCobro);
        }

        public static Cobro guardarCartera(Cartera pCartera)
        {
            return new RepositoryCartera().guardarCartera(pCartera);
        }
    }
}
