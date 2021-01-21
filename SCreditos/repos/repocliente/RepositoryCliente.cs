using Npgsql;
using SCreditos.models;
using SCreditos.repos.repocobro;
using SCreditos.repos.repodomingo;
using SCreditos.repos.repoprestamo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SCreditos.repos.repocliente
{
    class RepositoryCliente
    {
        private String CLIENTE_PRIMERO = "PRIMERO";

        private Conexion conexion;

        private NpgsqlCommand command;

        private NpgsqlDataReader consulta;

        private RepositoryPrestamo repositoryPrestamo;

        private RepositoryCobro repositoryCobro;

        private List<Cliente> clientes;

        public Cobro createCliente(String pDespuesDe, int ruta, Cliente cliente)
        {
            try
            {
                Conexion.desconectar();
                if (pDespuesDe.Equals(CLIENTE_PRIMERO))
                {
                    command = new NpgsqlCommand(ScriptCliente.create_one_cliente_primero(pDespuesDe, cliente), Conexion.conexion);
                    Conexion.conectar();
                    command.ExecuteReader();
                }
                else
                {
                    command = new NpgsqlCommand(ScriptCliente.create_one_cliente_despues(pDespuesDe, ruta, cliente), Conexion.conexion);
                    Conexion.conectar();
                    command.ExecuteReader();
                }

                Conexion.desconectar();
                repositoryPrestamo = new RepositoryPrestamo();
                Prestamo prestamo = repositoryPrestamo.findByCedulaCliente(cliente.getCedula())[0];

                Conexion.desconectar();
                command = new NpgsqlCommand(ScriptDomingo.create_pago_domingos_cliente(prestamo, cliente), Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();
                Conexion.desconectar();

                repositoryCobro = new RepositoryCobro();
                return repositoryCobro.findByNombre(cliente.getCobro());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Crear nuevo cliente");
            }
            return null;
        }
        
        public List<Cliente> findAllClientesByCobro(String pCobro)
        {
            try
            {
                Conexion.desconectar();
                NpgsqlCommand command = new NpgsqlCommand(ScriptCliente.select_all_cliente_by_cobro(pCobro), Conexion.conexion);
                Conexion.conectar();
                NpgsqlDataReader consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    clientes = new List<Cliente>();
                    repositoryPrestamo = new RepositoryPrestamo();
                    while (consulta.Read())
                    {
                        Cliente c = new Cliente(consulta.GetInt32(0), consulta.GetString(1), consulta.GetString(2), consulta.GetString(3), pCobro, consulta.GetString(5), consulta.GetString(6), consulta.GetInt32(7));
                        clientes.Add(c);
                    }

                    clientes.ForEach(c => c.setPrestamos(repositoryPrestamo.findByCedulaCliente(c.getCedula())));

                    return clientes;
                }

                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Buscar todos los clientes por cobro");
            }

            return null;
        }

    }
}
