using Npgsql;
using SCreditos.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCreditos.repos.repocartera
{
    class RepositoryCartera
    {
        private Conexion conexion;

        private NpgsqlCommand command;

        private NpgsqlDataReader consulta;

        private List<Cartera> listaCarteras;

        public List<Cartera> findAll(String pCobro)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptCartera.select_all(pCobro), Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();
                if (consulta.HasRows)
                {
                    listaCarteras = new List<Cartera>();
                    while (consulta.Read())
                    {
                        //this.setEstado(consulta.GetString(13));
                        listaCarteras.Add(new Cartera(
                            consulta.GetInt32(0),
                            consulta.GetInt32(4),
                            pCobro,
                            consulta.GetDate(2).ToString(),
                            consulta.GetDate(3).ToString(),
                            "SAVE",
                            consulta.GetDouble(5),
                            consulta.GetDouble(6),
                            consulta.GetDouble(7),
                            consulta.GetDouble(8),
                            consulta.GetDouble(9),
                            consulta.GetDouble(10),
                            consulta.GetDouble(11),
                            consulta.GetDouble(12)
                            ));
                    }
                }

                Conexion.desconectar();

                return listaCarteras;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Listar Carteras Por Cobro");
            }

            return null;
        }
    }
}
