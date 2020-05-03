using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCreditos.models
{
    class Cliente
    {
        private int id, ruta, idPrestamo;

        private string cedula = null;

        private string cobro = null;

        private string nombre, direccion, telefono, calificacion;

        public Cliente()
        {

        }

        public Cliente(int id, int ruta, string cedula, string nombre, string direccion, string cobro, string telefono, string calificacion)
        {
            this.id = id;
            this.ruta = ruta;
            this.idPrestamo = idPrestamo;
            this.cedula = cedula;
            this.cobro = cobro;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.calificacion = calificacion;
        }
        
        public static List<Cliente> listarClientes(String pCobro)
        {
            List<Cliente> lista = null;

            try
            {
                string script = "SELECT * FROM CLIENTES WHERE COBRO='" + pCobro + "' ORDER BY RUTA ASC;";
                NpgsqlCommand command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                NpgsqlDataReader consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    lista = new List<Cliente>();
                    while (consulta.Read())
                    {
                        lista.Add(new Cliente(consulta.GetInt32(0), consulta.GetInt32(7), consulta.GetString(1), consulta.GetString(2), consulta.GetString(3), consulta.GetString(4), consulta.GetString(5), consulta.GetString(6)));
                    }
                }
                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Listar Clientes.");
            }

            return lista;
        }
        
        public string buscarCliente()
        {
            string mensaje = null;

            try
            {
                if (this.getCedula() == null && this.getCobro() == null)
                {
                    string script = "SELECT* FROM CLIENTES WHERE CEDULA LIKE '" + this.getCedula() + "%' AND COBRO = '" + this.getCobro() + "'";
                    NpgsqlCommand command = new NpgsqlCommand(script, Conexion.conexion);
                    Conexion.conectar();
                    NpgsqlDataReader consulta = command.ExecuteReader();

                    if (consulta.HasRows)
                    {
                        consulta.Read();
                        this.setId(consulta.GetInt32(0));
                        this.setNombre(consulta.GetString(2));
                        this.setDireccion(consulta.GetString(3));
                        this.setTelefono(consulta.GetString(5));
                        this.setCalificacion(consulta.GetString(6));
                        this.setRuta(consulta.GetInt32(7));
                        mensaje = "Encontrado";
                    }

                    Conexion.desconectar();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Consulta: Buscar Cliente");
            }

            return mensaje;
        }

        public string crearCliente(String pDespuesDe, Cliente pClienteActual, Prestamo pPrestamo)
        {
            string mensaje = null;

        //    try
        //    {
        //        CREAR_CLIENTE(P_CEDULA CHARACTER(15), P_NOMBRE CHARACTER(100), P_DIRECCION CHARACTER(100), P_COBRO CHARACTER(100), P_TELEFONO CHARACTER(15), P_DESPUES_DE CHARACTER(20), P_RUTA_DEL_OTRO_CLIENTE INTEGER, P_PRESTAMO_PRESTAMO DECIMAL, P_PRESTAMO_VALOR DECIMAL, P_PRESTAMO_INTERES DECIMAL, P_PRESTAMO_PLAZO INTEGER, P_FECHA_INICIO DATE)


        //        st = BaseDatos.createStatement();



        //        if (pDespuesDe.equals(CLIENTE_PRIMERO))
        //        {
        //            rs = st.executeQuery("SELECT CREAR_CLIENTE('" + pClienteNuevo.getCedula() + "', '" + pClienteNuevo.getNombre() + "', '" + pClienteNuevo.getDireccion() + "', '" + pClienteNuevo.getCobro() + "', '" + pClienteNuevo.getTelefono() + "', '" + pDespuesDe + "', 0, " + (long)pPrestamo.getPrestamo() + ", " + (long)pPrestamo.getValor() + ", " + (long)(pPrestamo.getValor() - pPrestamo.getPrestamo()) + ", " + pPrestamo.getPlazo() + ", '" + pPrestamo.getFecha() + "');");
        //        }
        //        else
        //        {
        //            rs = st.executeQuery("SELECT CREAR_CLIENTE('" + pClienteNuevo.getCedula() + "', '" + pClienteNuevo.getNombre() + "', '" + pClienteNuevo.getDireccion() + "', '" + pClienteNuevo.getCobro() + "', '" + pClienteNuevo.getTelefono() + "', '" + pDespuesDe + "', " + pClienteActual.getRuta() + ", " + (long)pPrestamo.getPrestamo() + ", " + (long)pPrestamo.getValor() + ", " + (long)(pPrestamo.getValor() - pPrestamo.getPrestamo()) + ", " + pPrestamo.getPlazo() + ", '" + pPrestamo.getFecha() + "');");
        //        }
        //        st = BaseDatos.createStatement();
        //        rs = st.executeQuery("SELECT * FROM CLIENTES WHERE CEDULA= '" + pClienteNuevo.getCedula() + "';");
        //        if (rs.next())
        //        {
        //            cliente = new Cliente(rs.getInt("ID"), rs.getInt("RUTA"), rs.getString("CEDULA"), rs.getString("NOMBRE"), rs.getString("DIRECCION"), rs.getString("COBRO"), rs.getString("TELEFONO"), rs.getString("CALIFICACION"));
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        JOptionPane.showMessageDialog(null, e.getStackTrace(), "Consulta: Crear Cliente.", JOptionPane.INFORMATION_MESSAGE, null);
        //    }

            return mensaje;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getRuta()
        {
            return ruta;
        }

        public void setRuta(int ruta)
        {
            this.ruta = ruta;
        }

        public string getCedula()
        {
            return cedula;
        }

        public void setCedula(string cedula)
        {
            this.cedula = cedula;
        }

        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public String getDireccion()
        {
            return direccion;
        }

        public void setDireccion(String direccion)
        {
            this.direccion = direccion;
        }

        public String getCobro()
        {
            return cobro;
        }

        public void setCobro(String cobro)
        {
            this.cobro = cobro;
        }

        public String getTelefono()
        {
            return telefono;
        }

        public void setTelefono(String telefono)
        {
            this.telefono = telefono;
        }

        public String getCalificacion()
        {
            return calificacion;
        }

        public void setCalificacion(String calificacion)
        {
            this.calificacion = calificacion;
        }
        
    }
}
