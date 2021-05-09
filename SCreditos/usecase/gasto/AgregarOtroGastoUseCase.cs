using SCreditos.models;
using SCreditos.repositorios.repootrosgastos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.gasto
{
    class AgregarOtroGastoUseCase
    {
        public static Contabilidad agregarGasto(int idContabilidad, String nombreCobro, String descripcion, DateTime fecha, Double valor)
        {
            return new RepositoryOtrosGastos().save(idContabilidad, nombreCobro, descripcion, fecha, valor);
        }
    }
}
