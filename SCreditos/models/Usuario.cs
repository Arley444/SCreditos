using System;
using Npgsql;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCreditos.models
{
    class Usuario
    {
        private long id;

        private String usuario, nombreCompleto, contrasenna;

        public Usuario(long id, string usuario, string nombreCompleto, string contrasenna)
        {
            this.id = id;
            this.usuario = usuario;
            this.nombreCompleto = nombreCompleto;
            this.contrasenna = contrasenna;
        }

        public Usuario()
        {
        }

        public void setId(long pId)
        {
            this.id = pId;
        }

        public void setUsuario(String pUsuario)
        {
            this.usuario = pUsuario;
        }

        public void setNombreCompleto(String pNombreCompleto)
        {
            this.nombreCompleto = pNombreCompleto;
        }

        public void setContrasenna(String pContrasenna)
        {
            this.contrasenna = pContrasenna;
        }

        public long getId()
        {
            return this.id;
        }

        public String getUsuario()
        {
            return this.usuario;
        }

        public String getNombreCompleto()
        {
            return this.nombreCompleto;
        }

        public String getContrasenna()
        {
            return this.contrasenna;
        }


        public String validarUsuario()
        {
            String mensaje = null; 

            try
            {
                Conexion.desconectar();
                string script = "SELECT * FROM USUARIOS WHERE USUARIO= '" + this.usuario + "'";
                NpgsqlCommand command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                NpgsqlDataReader consulta = command.ExecuteReader();                

                if (consulta.HasRows)
                {
                    consulta.Read();
                    if (this.contrasenna == consulta.GetString(3))
                    {
                        this.setNombreCompleto(consulta.GetString(1));
                        Conexion.desconectar();
                    }
                    else
                    {
                        Conexion.desconectar();
                        mensaje = "La contraseña no es valida.";
                        return mensaje;
                    }
                }
                else
                {
                    Conexion.desconectar();
                    mensaje = "El usuario no es valido.";
                    return mensaje;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: validar Usuario.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return mensaje;
        }
    }
}
