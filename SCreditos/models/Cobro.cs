using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SCreditos.models
{
    class Cobro
    {
        private long id;

        private string nombre, fechaInicio;

        private int capital;

        private static string script;

        private static HashSet<Cobro> lista = null;

        public Cobro(long id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public Cobro()
        {

        }



        public String validarCobro()
        {
            String mensaje = null;

            try
            {
                Conexion.desconectar();
                script = "SELECT * FROM COBROS WHERE NOMBRE= '" + this.nombre + "';";
                NpgsqlCommand command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                NpgsqlDataReader consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    Conexion.desconectar();
                    mensaje = "El cobro ya existe.";
                    return mensaje;
                }
                else
                {
                    if (MessageBox.Show("¿ Realmente desea crear el cobro ?", "Crear Cobro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Conexion.desconectar();
                        script = "SELECT CREAR_COBROS('" + this.nombre + "', " + this.capital + ", '"+ this.fechaInicio +"');";
                        command = new NpgsqlCommand(script, Conexion.conexion);
                        Conexion.conectar();
                        command.ExecuteReader();
                        Conexion.desconectar();
                    }
                    else
                    {
                        Conexion.desconectar();
                        mensaje = "Se cancelo la creacion del cobro.";
                        return mensaje;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Validar Cobro.");
            }

            return mensaje;
        }
        

        public static HashSet<Cobro> cargarCobros()
        {
            try
            {
                Conexion.desconectar();
                script = "SELECT * FROM COBROS;";
                NpgsqlCommand command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                NpgsqlDataReader consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    lista = new HashSet<Cobro>();
                    while (consulta.Read())
                    {
                        lista.Add(new Cobro(consulta.GetInt32(0), consulta.GetString(1)));
                    }
                }
                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Cargar Cobros.");
            }

            return lista;
        }




        public long getId()
        {
            return id;
        }

        public void setId(long id)
        {
            this.id = id;
        }

        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getFechaInicio()
        {
            return this.fechaInicio;
        }

        public void setFechaInicio(string fechaInicio)
        {
            this.fechaInicio = fechaInicio;
        }

        public int getCapital()
        {
            return this.capital;
        }

        public void setCapital(int capital)
        {
            this.capital = capital;
        }
    }
}
