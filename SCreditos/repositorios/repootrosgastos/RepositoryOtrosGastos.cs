using Npgsql;
using SCreditos.models;
using SCreditos.repos.repocontabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCreditos.repositorios.repootrosgastos
{
    class RepositoryOtrosGastos
    {
        private Conexion conexion;

        public Contabilidad save(int pIdContabilidad, String pNombreCobro, String pDescripcion, DateTime pFecha, Double pValor)
        {
            try
            {
                Conexion.desconectar();
                NpgsqlCommand command = new NpgsqlCommand(ScriptOtroGasto.create_one_gasto(pIdContabilidad, pNombreCobro, pDescripcion, pFecha, pValor), Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();

                Conexion.desconectar();

                return new RepositoryContabilidad().findById(pIdContabilidad);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Consulta: Guardar Otro Gasto");
            }

            return null;
        }
    }
}
