using SCreditos.models;
using SCreditos.repos.repogasto;

namespace SCreditos.usecase.gasto
{
    class GuardarGastoDiarioUseCase
    {
        public static void guardarGasto(Gasto gasto)
        {
            new RepositoryGasto().saveGasto(gasto);
        }
    }
}
