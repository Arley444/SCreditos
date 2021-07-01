using Npgsql;
using SCreditos.models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SCreditos.repos.repocontabilidad
{
    class RepositoryContabilidad
    {
        private Conexion conexion;
        
        private NpgsqlCommand command;

        private Contabilidad contabilidad;

        private NpgsqlDataReader consulta;


        public List<Contabilidad> findAll()
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptContabilidad.select_all(), Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    List<Contabilidad> l = new List<Contabilidad>();
                    while (consulta.Read())
                    {
                        contabilidad = new Contabilidad(consulta.GetInt32(0), consulta.GetString(1), new DateTime(consulta.GetDate(2).Year, consulta.GetDate(2).Month, consulta.GetDate(2).Day), consulta.GetInt32(3), consulta.GetDouble(4), consulta.GetDouble(5), consulta.GetDouble(6), consulta.GetDouble(7), consulta.GetDouble(8), consulta.GetString(9));
                        l.Add(contabilidad);
                    }

                    return l;
                }

                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Cargando todas las contabilidades.");
            }

            return null;
        }

        public Boolean contabilidadesDespues(String pCobro, String pFecha)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptContabilidad.select_all_by_nombre_cobro_and_fecha_mayor_que(pCobro, pFecha), Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    Conexion.desconectar();
                    return true;
                }

                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Cargando todas las contabilidades por cobro.");
            }

            return false;
        }

        public List<Contabilidad> findAllByCobro(String pCobro)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptContabilidad.select_all_by_nombre_cobro(pCobro), Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    List<Contabilidad> l = new List<Contabilidad>();
                    while (consulta.Read())
                    {
                        contabilidad = new Contabilidad(consulta.GetInt32(0), consulta.GetString(1), new DateTime(consulta.GetDate(2).Year, consulta.GetDate(2).Month, consulta.GetDate(2).Day), consulta.GetInt32(3), consulta.GetDouble(4), consulta.GetDouble(5), consulta.GetDouble(6), consulta.GetDouble(7), consulta.GetDouble(8), consulta.GetString(9));
                        l.Add(contabilidad);
                    }

                    return l;
                }

                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Cargando todas las contabilidades por cobro.");
            }

            return null;
        }

        public List<Contabilidad> findByCobroAndDate(String pCobro, String pFecha)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptContabilidad.select_all_by_nombre_cobro_and_fecha(pCobro, pFecha), Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    List<Contabilidad> l = new List<Contabilidad>();
                    while (consulta.Read())
                    {
                        contabilidad = new Contabilidad(consulta.GetInt32(0), consulta.GetString(1), new DateTime(consulta.GetDate(2).Year, consulta.GetDate(2).Month, consulta.GetDate(2).Day), consulta.GetInt32(3), consulta.GetDouble(4), consulta.GetDouble(5), consulta.GetDouble(6), consulta.GetDouble(7), consulta.GetDouble(8), consulta.GetString(9));
                        l.Add(contabilidad);
                    }

                    return l;
                }

                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Cargando todas las contabilidades por cobro y fecha.");
            }

            return null;
        }

        public Contabilidad findById(int pId)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptContabilidad.select_by_Id(pId), Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    while (consulta.Read())
                    {
                        return new Contabilidad(consulta.GetInt32(0), consulta.GetString(1), new DateTime(consulta.GetDate(2).Year, consulta.GetDate(2).Month, consulta.GetDate(2).Day), consulta.GetInt32(3), consulta.GetDouble(4), consulta.GetDouble(5), consulta.GetDouble(6), consulta.GetDouble(7), consulta.GetDouble(8), consulta.GetString(9));
                    }
                }

                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Cargando contabilidad por ID.");
            }

            return null;
        }

        public List<Contabilidad> restarAbonoContabilidad(List<Abono> abonos, List<Contabilidad> contabilidades)
        {
            try
            {
                abonos.ForEach(abono =>
                {
                    Contabilidad contabilidad = contabilidades.Find(contabilid =>
                            contabilid.getFecha().Year.Equals(abono.getFecha().Year)
                            && contabilid.getFecha().Month.Equals(abono.getFecha().Month)
                            && contabilid.getFecha().Day.Equals(abono.getFecha().Day));

                    Conexion.desconectar();
                    command = new NpgsqlCommand(ScriptContabilidad.restar_abono_a_contabilidad(abono, contabilidad), Conexion.conexion);
                    Conexion.conectar();
                    command.ExecuteReader();
                });

                return findAllByCobro(contabilidades[0].getNombreCobro());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Restando Abonos a contabilidad.");
            }

            return null;
        }

        public List<Contabilidad> restarCobroUtilidadContabilidad(Contabilidad contabilidad, Prestamo prestamo)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptContabilidad.restar_cobro_utilidad_a_contabilidad(contabilidad, prestamo), Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();

                return findAllByCobro(contabilidad.getNombreCobro());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Restando Cobro Utilidad a contabilidad.");
            }

            return null;
        }
    }
}
