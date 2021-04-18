using Npgsql;
using SCreditos.models;
using SCreditos.models.common;
using SCreditos.repos.repoabono;
using SCreditos.repos.repocobro;
using SCreditos.repos.repodomingo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCreditos.repos.repoprestamo
{
    class RepositoryPrestamo
    {
        private Conexion conexion;

        private NpgsqlCommand command;

        private NpgsqlDataReader consulta;

        private RepositoryDomingo repositoryDomingo;

        private RepositoryAbono repositoryAbono;

        private RepositoryCobro repositoryCobro;

        public List<Prestamo> findByCedulaCliente(String pCedula)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptPrestamo.select_one_prestamo_by_cedula_cliente(pCedula), Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    repositoryDomingo = new RepositoryDomingo();
                    repositoryAbono = new RepositoryAbono();
                    List<Prestamo> lista = new List<Prestamo>();

                    while (consulta.Read())
                    {
                        if (consulta.GetString(12).Equals(TipoPrestamo.NORMAL))
                        {
                            Prestamo prestamo = new Prestamo(consulta.GetString(1), consulta.GetDouble(2) / 1000);
                            prestamo.setId(consulta.GetInt32(0));
                            prestamo.setValorDebe(consulta.GetDouble(6));
                            prestamo.setValorPago(consulta.GetDouble(7));
                            prestamo.setEstado(consulta.GetString(8));
                            prestamo.setCalificacion(consulta.GetString(11));
                            prestamo.setTipoPrestamo(consulta.GetString(12));
                            if (!consulta.IsDBNull(9))
                            {
                                prestamo.setFechaInicio(new DateTime(consulta.GetDate(9).Year, consulta.GetDate(9).Month, consulta.GetDate(9).Day));
                            }

                            if (!consulta.IsDBNull(10))
                            {
                                prestamo.setFechaPago(new DateTime(consulta.GetDate(10).Year, consulta.GetDate(10).Month, consulta.GetDate(10).Day));
                            }
                            lista.Add(prestamo);
                        }
                        else
                        {
                            Prestamo prestamo = new Prestamo(consulta.GetString(1), consulta.GetDouble(2) / 1000, consulta.GetDouble(3));
                            prestamo.setId(consulta.GetInt32(0));
                            prestamo.setValorDebe(consulta.GetDouble(6));
                            prestamo.setValorPago(consulta.GetDouble(7));
                            prestamo.setEstado(consulta.GetString(8));
                            prestamo.setCalificacion(consulta.GetString(11));
                            prestamo.setTipoPrestamo(consulta.GetString(12));
                            if (!consulta.IsDBNull(9))
                            {
                                prestamo.setFechaInicio(new DateTime(consulta.GetDate(9).Year, consulta.GetDate(9).Month, consulta.GetDate(9).Day));
                            }

                            if (!consulta.IsDBNull(10))
                            {
                                prestamo.setFechaPago(new DateTime(consulta.GetDate(10).Year, consulta.GetDate(10).Month, consulta.GetDate(10).Day));
                            }
                            lista.Add(prestamo);
                        }
                    }

                    lista.ForEach(p => p.setDomingo(repositoryDomingo.findByIdPrestamo(p.getId())));

                    lista.ForEach(p => p.setAbonos(repositoryAbono.findByIdPrestamo(p.getId())));

                    return lista;
                }

                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Buscar prestamos por cedula de cliente");
            }

            return null;
        }

        public Cobro cancelarTotalidadPrestamo(DateTime fecha, Cobro cobro, Prestamo prestamo)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptPrestamo.cancelar_one_prestamo(prestamo, fecha, cobro), Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();

                repositoryCobro = new RepositoryCobro();

                return repositoryCobro.findByNombre(cobro.getNombre());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Cancelar totalidad de prestamo");
            }

            return null;
        }

        public Prestamo buscarUltimoPrestamoCedulaCliente(String pCedula)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptPrestamo.select_one_prestamo_last_by_cedula_cliente(pCedula), Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    consulta.Read();

                    if (consulta.GetString(12).Equals(TipoPrestamo.NORMAL))
                    {
                        Prestamo prestamo = new Prestamo(consulta.GetString(1), consulta.GetDouble(2) / 1000);
                        prestamo.setId(consulta.GetInt32(0));
                        prestamo.setValorDebe(consulta.GetDouble(6));
                        prestamo.setValorPago(consulta.GetDouble(7));
                        prestamo.setEstado(consulta.GetString(8));
                        prestamo.setCalificacion(consulta.GetString(11));
                        prestamo.setTipoPrestamo(consulta.GetString(12));
                        if (!consulta.IsDBNull(9))
                        {
                            prestamo.setFechaInicio(new DateTime(consulta.GetDate(9).Year, consulta.GetDate(9).Month, consulta.GetDate(9).Day));
                        }

                        if (!consulta.IsDBNull(10))
                        {
                            prestamo.setFechaPago(new DateTime(consulta.GetDate(10).Year, consulta.GetDate(10).Month, consulta.GetDate(10).Day));
                        }

                        Conexion.desconectar();

                        return prestamo;
                    }
                    else
                    {
                        Prestamo prestamo = new Prestamo(consulta.GetString(1), consulta.GetDouble(3) / 1000);
                        prestamo.setId(consulta.GetInt32(0));
                        prestamo.setValorDebe(consulta.GetDouble(6));
                        prestamo.setValorPago(consulta.GetDouble(7));
                        prestamo.setEstado(consulta.GetString(8));
                        prestamo.setCalificacion(consulta.GetString(11));
                        prestamo.setTipoPrestamo(consulta.GetString(12));
                        if (!consulta.IsDBNull(9))
                        {
                            prestamo.setFechaInicio(new DateTime(consulta.GetDate(9).Year, consulta.GetDate(9).Month, consulta.GetDate(9).Day));
                        }

                        if (!consulta.IsDBNull(10))
                        {
                            prestamo.setFechaPago(new DateTime(consulta.GetDate(10).Year, consulta.GetDate(10).Month, consulta.GetDate(10).Day));
                        }

                        Conexion.desconectar();

                        return prestamo;
                    }
                }                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Buscar ultimo prestamo cliente.");
            }

            return null;
        }        

        public Cobro crearNuevoPrestamo(Cobro cobro, Prestamo prestamo)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptPrestamo.create_new_prestamo(cobro, prestamo), Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();
                
                Prestamo p = buscarUltimoPrestamoCedulaCliente(prestamo.getCedulaCliente());
                Conexion.desconectar();

                command = new NpgsqlCommand(ScriptDomingo.create_pago_domingos_prestamo(p.getId(), prestamo), Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();
                Conexion.desconectar();

                repositoryCobro = new RepositoryCobro();

                return repositoryCobro.findByNombre(cobro.getNombre());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Crear nuevo prestamo");
            }

            return null;
        }

        public void calificarPrestamo(Prestamo prestamo)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptPrestamo.calificar_prestamo(prestamo), Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();
                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Calificar prestamo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Cobro enviarClavo(Cobro cobro, Prestamo prestamo, DateTime fecha)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptPrestamo.enviar_clavo(cobro, prestamo, fecha), Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();

                repositoryCobro = new RepositoryCobro();

                return repositoryCobro.findByNombre(cobro.getNombre());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Enviando a clavo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
    }
}
