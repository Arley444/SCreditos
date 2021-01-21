using Npgsql;
using SCreditos.models;
using SCreditos.repos.repocliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SCreditos.repos.repocobro
{
    class RepositoryCobro
    {
        private Conexion conexion;

        private Cobro cobro;

        private NpgsqlCommand command;

        private NpgsqlDataReader consulta;

        private RepositoryCliente repositoryCliente;

        public List<Cobro> findAll()
        {
            try
            {
                Conexion.desconectar();
                NpgsqlCommand command = new NpgsqlCommand(ScriptCobro.select_all(), Conexion.conexion);
                Conexion.conectar();
                NpgsqlDataReader consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    List<Cobro> l = new List<Cobro>();
                    while (consulta.Read())
                    {
                        cobro = new Cobro();
                        cobro.setId(consulta.GetInt32(0));
                        cobro.setNombre(consulta.GetString(1));
                        l.Add(cobro);
                    }

                    repositoryCliente = new RepositoryCliente();
                    l.ForEach(c => c.setClientes(repositoryCliente.findAllClientesByCobro(c.getNombre())));

                    return l;
                }

                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Cargando todos los cobros.");
            }

            return new List<Cobro>();
        }

        public Cobro createNuevoCobro(Cobro cobro)
        {
            try
            {
                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptCobro.create_new_cobro(cobro), Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();
                Conexion.desconectar();

                return findByNombre(cobro.getNombre());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Creando nuevo cobro.");
            }

            return null;
        }

        public Cobro findByNombre(String pCobro)
        {
            try
            {
                Conexion.desconectar();
                NpgsqlCommand command = new NpgsqlCommand(ScriptCobro.select_by_nombre(pCobro), Conexion.conexion);
                Conexion.conectar();
                NpgsqlDataReader consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    consulta.Read();
                    cobro = new Cobro();
                    cobro.setId(consulta.GetInt32(0));
                    cobro.setNombre(consulta.GetString(1));
                    repositoryCliente = new RepositoryCliente();
                    cobro.setClientes(repositoryCliente.findAllClientesByCobro(cobro.getNombre()));

                    return cobro;
                }

                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Buscando cobro por nombre.");
            }

            return null;
        }
    }    
}
