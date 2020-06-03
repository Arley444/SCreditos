using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCreditos.models
{
    class Abono
    {
        private int id, idPrestamo;
        private string fecha;
        private double valor, restante;
        private String tipo;

        public Abono(int id, string fecha, double valor, String tipo, double restante)
        {
            this.id = id;
            this.fecha = fecha;
            this.valor = valor;
            this.tipo = tipo;
            this.restante = restante;
        }

        public Abono(int id, string fecha, double valor, String tipo, double restante, int idPrestamo)
        {
            this.id = id;
            this.fecha = fecha;
            this.valor = valor;
            this.tipo = tipo;
            this.restante = restante;
            this.idPrestamo = idPrestamo;
        }

        public int getIdPrestamo()
        {
            return idPrestamo;
        }

        public void setIdPrestamo(int idPrestamo)
        {
            this.idPrestamo = idPrestamo;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getFecha()
        {
            return fecha;
        }

        public double getRestante()
        {
            return restante;
        }

        public void setRestante(double restante)
        {
            this.restante = restante;
        }

        public void setFecha(string fecha)
        {
            this.fecha = fecha;
        }

        public double getValor()
        {
            return valor;
        }

        public void setValor(double valor)
        {
            this.valor = valor;
        }

        public String getTipo()
        {
            return tipo;
        }

        public void setTipo(String tipo)
        {
            this.tipo = tipo;
        }

        public static void pagarDomingos(int pIdPrestamo, int pDomingos, double pValorPagar, double pValorPorDomingo)
        {
            try
            {
                Conexion.desconectar();
                string script = "SELECT PAGO_DOMINGOS(" + pIdPrestamo + ", " + pDomingos + ", " + pValorPagar + ", " + pValorPorDomingo + ")";
                NpgsqlCommand command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();
                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Pagar Domingos.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void pagarAbono(int pIdPrestamo, string pFecha, double pValor, string pCobro)
        {
            try
            {
                Conexion.desconectar();
                string script = "SELECT CARGAR_ABONO(" + pIdPrestamo + ", '" + pFecha + "', " + pValor + ", '" + pCobro + "');";
                NpgsqlCommand command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();
                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Pagar Abono.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static List<Abono> listaAbonosCliente(string pCedula)
        {           
            List<Abono> listaAbonosCliente = null;
            string script = null;
            NpgsqlCommand command = null;
            NpgsqlDataReader consulta = null;
            try
            {
                Conexion.desconectar();
                script = "SELECT ID, FECHA_INICIO FROM PRESTAMOS WHERE CEDULA_CLIENTE= '" + pCedula + "' AND ESTADO= 'ACTIVO';";
                command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();
                if (consulta.HasRows)
                {
                    consulta.Read();
                    int idPrestamo = consulta.GetInt32(0);
                    string fechaInicio = consulta.GetDate(1).ToString();
                    Conexion.desconectar();

                    script = "SELECT * FROM DOMINGOS WHERE ID_PRESTAMO= " + idPrestamo + ";";
                    command = new NpgsqlCommand(script, Conexion.conexion);
                    Conexion.conectar();
                    consulta = command.ExecuteReader();

                    if (consulta.HasRows)
                    {
                        listaAbonosCliente = new List<Abono>();
                        while (consulta.Read())
                        {
                            listaAbonosCliente.Add(new Abono(consulta.GetInt32(0), fechaInicio, consulta.GetDouble(3), "DOMINGOS", consulta.GetDouble(5)));
                        }
                        Conexion.desconectar();

                        script = "SELECT * FROM ABONOS WHERE ID_PRESTAMO= " + idPrestamo + ";";
                        command = new NpgsqlCommand(script, Conexion.conexion);
                        Conexion.conectar();
                        consulta = command.ExecuteReader();

                        if (consulta.HasRows)
                        {
                            while (consulta.Read())
                            {
                                listaAbonosCliente.Add(new Abono(consulta.GetInt32(0), consulta.GetDate(2).ToString(), consulta.GetDouble(3), "ABONO", consulta.GetDouble(4)));
                            }
                        }
                    }
                }
                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Listar Abonos Del Cliente");
            }

            return listaAbonosCliente;
        }
    }
}
