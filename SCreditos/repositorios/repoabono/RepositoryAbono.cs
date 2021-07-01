using Npgsql;
using SCreditos.models;
using SCreditos.repos.repocliente;
using SCreditos.repos.repocobro;
using SCreditos.repos.repoprestamo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SCreditos.repos.repoabono
{
    class RepositoryAbono
    {
        private Conexion conexion;

        private NpgsqlCommand command;

        private NpgsqlDataReader consulta;

        private RepositoryCobro repositoryCobro;

        private RepositoryCliente repositoryCliente;

        private RepositoryPrestamo repositoryPrestamo;

        public List<Abono> findByIdPrestamo(int pIdPrestamo)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptAbono.select_all_abonos_by_id_prestamo(pIdPrestamo), Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    List<Abono> lista = new List<Abono>();
                    while (consulta.Read())
                    {
                        lista.Add(new Abono(consulta.GetInt32(0), pIdPrestamo, new DateTime(consulta.GetDate(2).Year, consulta.GetDate(2).Month, consulta.GetDate(2).Day), consulta.GetDouble(3), consulta.GetDouble(4), consulta.GetString(5)));
                    }

                    return lista;
                }
                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Buscar abono por id de prestamo");
            }

            return null;
        }

        public Cobro pagarAbono(Cliente cliente, Abono abono, Prestamo prestamo)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptAbono.select_cargar_abono(cliente, abono), Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();

                repositoryPrestamo = new RepositoryPrestamo();
                repositoryPrestamo.calificarPrestamo(prestamo);

                repositoryCobro = new RepositoryCobro();
                return repositoryCobro.findByNombre(cliente.getCobro());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Pagar abono cliente");
            }

            return null;
        }

        public Cobro aumentarAbonos(String cobro, List<Abono> abonos, Double valorAumentar)
        {
            try
            {
                abonos.ForEach(abono =>
                {
                    Conexion.desconectar();
                    command = new NpgsqlCommand(ScriptAbono.aumentar_valor_restante_abono(abono, valorAumentar), Conexion.conexion);
                    Conexion.conectar();
                    command.ExecuteReader();
                });

                repositoryCobro = new RepositoryCobro();
                return repositoryCobro.findByNombre(cobro);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: aumentar valor restante abono cliente");
            }

            return null;
        }

        public Cobro eliminarAbono(String cobro, Abono abono, Prestamo prestamo, Contabilidad contabilidad)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptAbono.eliminar_abono(abono, prestamo, contabilidad), Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();

                repositoryCobro = new RepositoryCobro();
                return repositoryCobro.findByNombre(cobro);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: eliminar abono cliente");
            }

            return null;
        }

        public Cobro eliminarAbonos(String cobro, Prestamo prestamo)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptAbono.eliminar_abonos( prestamo), Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();

                repositoryCobro = new RepositoryCobro();
                return repositoryCobro.findByNombre(cobro);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: eliminar abonos cliente");
            }

            return null;
        }
    }
}
