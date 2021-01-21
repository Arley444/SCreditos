using Npgsql;
using System;

namespace SCreditos.models
{
    class Contabilidad
    {
        private NpgsqlCommand command;

        private NpgsqlDataReader consulta;

        private int id;

        private string nombreCobro;

        private DateTime fecha;

        private int tarjetas;

        private Double cobro;

        private Double presto;

        private Double utilidad;

        private Double gastos;

        private Double otros_gastos;

        private string estado;

        private string script;

        public Contabilidad()
        {

        }

        public Contabilidad(int id, string nombre_cobro, DateTime fecha, int tarjetas, Double cobro, Double presto, Double utilidad, Double gastos, Double otros_gastos, string estado)
        {
            this.id = id;
            this.tarjetas = tarjetas;
            this.nombreCobro = nombre_cobro;
            this.fecha = fecha;
            this.estado = estado;
            this.cobro = cobro;
            this.presto = presto;
            this.utilidad = utilidad;
            this.gastos = gastos;
            this.otros_gastos = otros_gastos;
        }

        public void setId(int pId)
        {
            this.id = pId;
        }

        public int getId()
        {
            return this.id;
        }

        public void setTarjetas(int pTarjetas)
        {
            this.tarjetas = pTarjetas;
        }

        public int getTarjetas()
        {
            return this.tarjetas;
        }

        public void setNombreCobro(string pNombreCobro)
        {
            this.nombreCobro = pNombreCobro;
        }

        public string getNombreCobro()
        {
            return this.nombreCobro;
        }

        public void setFecha(DateTime pFecha)
        {
            this.fecha = pFecha;
        }

        public DateTime getFecha()
        {
            return this.fecha;
        }

        public void setEstado(string pEstado)
        {
            this.estado = pEstado;
        }

        public string getEstado()
        {
            return this.estado;
        }

        public void setCobro(Double pCobro)
        {
            this.cobro = pCobro;
        }

        public Double getCobro()
        {
            return this.cobro;
        }

        public void setPresto(Double pPresto)
        {
            this.presto = pPresto;
        }

        public Double getPresto()
        {
            return this.presto;
        }

        public void setUtilidad(Double pUtilidad)
        {
            this.utilidad = pUtilidad;
        }

        public Double getUtilidad()
        {
            return this.utilidad;
        }

        public void setGastos(Double pGastos)
        {
            this.gastos = pGastos;
        }

        public Double getGastos()
        {
            return this.gastos;
        }

        public void setOtrosGastos(Double pOtrosGastos)
        {
            this.otros_gastos = pOtrosGastos;
        }

        public Double getOtrosGastos()
        {
            return this.otros_gastos;
        }

        //public void cargarContabilidad()
        //{
        //    try
        //    {
        //        Conexion.desconectar();
        //        script = "SELECT EXISTE_CONTABILIDAD('" + this.getNombreCobro() + "', '" + this.getFecha() +"');";
        //        command = new NpgsqlCommand(script, Conexion.conexion);
        //        Conexion.conectar();
        //        consulta = command.ExecuteReader();
        //        if (consulta.HasRows)
        //        {
        //            consulta.Read();
        //            if(consulta.GetInt32(0) == 1)
        //            {
        //                Conexion.desconectar();
        //                script = "SELECT * FROM CONTABILIDADES WHERE FECHA= '" + this.getFecha() + "' AND NOMBRE_COBRO= '" + this.getNombreCobro() + "';";
        //                command = new NpgsqlCommand(script, Conexion.conexion);
        //                Conexion.conectar();
        //                consulta = command.ExecuteReader();

        //                if (consulta.HasRows)
        //                {
        //                    consulta.Read();
        //                    this.setId(consulta.GetInt32(0));
        //                    this.setTarjetas(consulta.GetInt32(3));
        //                    this.setEstado(consulta.GetString(7));
        //                    this.setCobro(consulta.GetDouble(4));
        //                    this.setPresto(consulta.GetDouble(5));
        //                    this.setUtilidad(consulta.GetDouble(6));
        //                }
        //            }
        //            else
        //            {
        //                    this.setId(0);
        //                    this.setTarjetas(0);
        //                    this.setEstado(NO_GUARDADO);
        //                    this.setCobro(0);
        //                    this.setPresto(0);
        //                    this.setUtilidad(0);

        //            }
        //        }                
        //        Conexion.desconectar();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "Consulta: Cargar Contabillidad.");
        //    }
        //}

        //public void cargarContabilidadConLimites()
        //{
        //    DateTime fechaInicio = Convert.ToDateTime(this.getFecha()).Date;
        //    DateTime fechaFinal = Convert.ToDateTime(this.getFechaFinal()).Date;

        //    Console.WriteLine(fechaInicio);

        //    int tarjetas = 0;
        //    double cobro = 0;
        //    double presto = 0;
        //    double utilidad = 0;

        //    while (fechaInicio <= fechaFinal)
        //    {
        //        try
        //        {
        //            Conexion.desconectar();
        //            script = "SELECT EXISTE_CONTABILIDAD('" + this.getNombreCobro() + "', '" + fechaInicio.ToShortDateString() + "');";
        //            command = new NpgsqlCommand(script, Conexion.conexion);
        //            Conexion.conectar();
        //            consulta = command.ExecuteReader();
        //            if (consulta.HasRows)
        //            {
        //                consulta.Read();
        //                if (consulta.GetInt32(0) == 1)
        //                {
        //                    Conexion.desconectar();
        //                    script = "SELECT * FROM CONTABILIDADES WHERE FECHA= '" + fechaInicio.ToShortDateString() + "' AND NOMBRE_COBRO= '" + this.getNombreCobro() + "';";
        //                    command = new NpgsqlCommand(script, Conexion.conexion);
        //                    Conexion.conectar();
        //                    consulta = command.ExecuteReader();

        //                    if (consulta.HasRows)
        //                    {
        //                        consulta.Read();
        //                        tarjetas = tarjetas + consulta.GetInt32(3);
        //                        cobro = cobro + consulta.GetDouble(4);
        //                        presto = presto + consulta.GetDouble(5);
        //                        utilidad = utilidad + consulta.GetDouble(6);
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.Message, "Consulta: Cargar Contabillidad Con Limites.");
        //        }
        //        fechaInicio = fechaInicio.AddDays(1);
        //    }

        //    this.setTarjetas(tarjetas);
        //    this.setCobro(cobro);
        //    this.setPresto(presto);
        //    this.setUtilidad(utilidad);

        //}
    }
}
