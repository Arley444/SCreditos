using SCreditos.models;
using SCreditos.repos.repoabono;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.abono
{
    class AumentarValorRestanteAbonoUseCase
    {
        public static Cobro aumentarValorRestanteAbono(String cobro, List<Abono> abonos, Double valor)
        {
            return new RepositoryAbono().aumentarAbonos(cobro, abonos, valor);
        }
    }
}
