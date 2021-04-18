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
        private DateTime fecha;
        private double valor, restante;
        private String tipoAbono;

        public Abono(int id, int idPrestamo, DateTime fecha, double valor, double restante, String pTipoAbono)
        {
            this.id = id;
            this.fecha = fecha;
            this.valor = valor;
            this.restante = restante;
            this.idPrestamo = idPrestamo;
            this.tipoAbono = pTipoAbono;
        }

        public Abono(int id, int idPrestamo, DateTime fecha, double valor, double restante)
        {
            this.id = id;
            this.fecha = fecha;
            this.valor = valor;
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

        public DateTime getFecha()
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

        public void setFecha(DateTime fecha)
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

        public String getTipoAbono()
        {
            return tipoAbono;
        }

        public void setTipoAbono(String pTipoAbono)
        {
            this.tipoAbono = pTipoAbono;
        }

        //public static List<Abono> allByDateAndPayments(string pDate)
        //{
        //    List<Abono> listaAbonosCliente = null;
        //    script = null;
        //    NpgsqlCommand command = null;
        //    NpgsqlDataReader consulta = null;
        //    try
        //    {
        //        Conexion.desconectar();
        //        script = "SELECT * FROM ABONOS WHERE FECHA_INICIO= '" + pDate + "'  AND VALOR > 0;";
        //        command = new NpgsqlCommand(script, Conexion.conexion);
        //        Conexion.conectar();
        //        consulta = command.ExecuteReader();

        //        if (consulta.HasRows)
        //        {
        //            listaAbonosCliente = new List<Abono>();
        //            while (consulta.Read())
        //            {
        //                listaAbonosCliente.Add(new Abono(consulta.GetInt32(0), consulta.GetInt32(1), consulta.GetDate(2).ToString(), consulta.GetDouble(3), consulta.GetDouble(4)));
        //            }
        //            Conexion.desconectar();
        //        }

        //        Conexion.desconectar();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "Consulta: Listar Abonos Del Cliente: 'allByDateAndPayments'");
        //    }

        //    return listaAbonosCliente;
        //}

        //public static List<Abono> allByDateAndNotPayments(string pFecha)
        //{
        //    List<Abono> list = null;
        //    script = null;
        //    NpgsqlCommand command = null;
        //    NpgsqlDataReader consulta = null;

        //    try
        //    {
        //        Conexion.desconectar();
        //        script = "SELECT * FROM ABONOS WHERE FECHA_INICIO= '" + pFecha + "'  AND VALOR= 0;;";
        //        command = new NpgsqlCommand(script, Conexion.conexion);
        //        Conexion.conectar();
        //        consulta = command.ExecuteReader();

        //        if (consulta.HasRows)
        //        {
        //            list = new List<Abono>();
        //            while (consulta.Read())
        //            {
        //                list.Add(new Abono(consulta.GetInt32(0), consulta.GetInt32(1), consulta.GetDate(2).ToString(), consulta.GetDouble(3), consulta.GetDouble(4)));
        //            }
        //        }
        //        Conexion.desconectar();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "Consulta: Lista Abonos No Pagos. 'allByDateAndNotPayments'");
        //    }

        //    return list;
        //}

        //public static List<Abono> listaAbonosCliente(string pFechaInicio, int pIdPrestamo)
        //{           
        //    List<Abono> listaAbonosCliente = null;
        //    script = null;
        //    NpgsqlCommand command = null;
        //    NpgsqlDataReader consulta = null;
        //    try
        //    {
        //        Conexion.desconectar();
        //        script = "SELECT * FROM DOMINGOS WHERE ID_PRESTAMO= " + pIdPrestamo + ";";
        //            command = new NpgsqlCommand(script, Conexion.conexion);
        //            Conexion.conectar();
        //            consulta = command.ExecuteReader();

        //            if (consulta.HasRows)
        //            {
        //                listaAbonosCliente = new List<Abono>();
        //                while (consulta.Read())
        //                {
        //                    listaAbonosCliente.Add(new Abono(consulta.GetInt32(0), pFechaInicio, consulta.GetDouble(3), "DOMINGOS", consulta.GetDouble(5)));
        //                }
        //                Conexion.desconectar();

        //                script = "SELECT * FROM ABONOS WHERE ID_PRESTAMO= " + pIdPrestamo + ";";
        //                command = new NpgsqlCommand(script, Conexion.conexion);
        //                Conexion.conectar();
        //                consulta = command.ExecuteReader();

        //                if (consulta.HasRows)
        //                {
        //                    while (consulta.Read())
        //                    {
        //                        listaAbonosCliente.Add(new Abono(consulta.GetInt32(0), consulta.GetDate(2).ToString(), consulta.GetDouble(3), "ABONO", consulta.GetDouble(4)));
        //                    }
        //                }
        //            }

        //        Conexion.desconectar();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "Consulta: Listar Abonos Del Cliente");
        //    }

        //    return listaAbonosCliente;
        //}
    }
}
