using Npgsql;
using SCreditos.models;
using SCreditos.repos.repocobro;
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

        private NpgsqlCommand command;

        private NpgsqlDataReader consulta;

        private RepositoryCobro repositoryCobro;

        public Domingo findByIdPrestamo(int pIdPrestamo)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptDomingo.select_one_domingo_by_id_prestamo(pIdPrestamo), Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();

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

        public Cobro eliminarDomingo(string cobro, Prestamo prestamo)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptDomingo.eliminar_domingo(prestamo), Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();

                repositoryCobro = new RepositoryCobro();
                return repositoryCobro.findByNombre(cobro);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: eliminar domingo cliente");
            }

            return null;
        }
    }
}
