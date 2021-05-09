using Npgsql;
using SCreditos.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCreditos.repos.repogasto
{
    class RepositoryGasto
    {
        private Conexion conexion;

        public void saveGasto(Gasto gasto)
        {
            try
            {
                Conexion.desconectar();
                NpgsqlCommand command = new NpgsqlCommand(ScriptGasto.create_one_gasto(gasto), Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();

                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Guardar gasto diario");
            }
        }
    }
}
