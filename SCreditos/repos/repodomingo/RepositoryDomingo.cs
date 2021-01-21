using Npgsql;
using SCreditos.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCreditos.repos.repodomingo
{
    class RepositoryDomingo
    {
        private Conexion conexion;

        public Domingo findByIdPrestamo(int pIdPrestamo)
        {
            try
            {
                Conexion.desconectar();
                NpgsqlCommand command = new NpgsqlCommand(ScriptDomingo.select_one_domingo_by_id_prestamo(pIdPrestamo), Conexion.conexion);
                Conexion.conectar();
                NpgsqlDataReader consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    consulta.Read();

                    return new Domingo(consulta.GetInt32(0), consulta.GetInt32(1), consulta.GetInt32(2), consulta.GetDouble(3), consulta.GetDouble(4), consulta.GetDouble(5));
                }
                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Buscar domingo por id de prestamo");
            }

            return null;
        }
    }
}
