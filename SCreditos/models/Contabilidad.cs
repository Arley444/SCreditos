using Npgsql;
using System;
using System.Windows.Forms;

namespace SCreditos.models
{
    class Contabilidad
    {
        private const string GUARDADO = "SAVE";

        private const string NO_GUARDADO = "NOT SAVE";

        private NpgsqlCommand command;

        private NpgsqlDataReader consulta;

        private int id, tarjetas;

        private string nombreCobro, fecha, fechaFinal, estado, script;

        private Double cobro, presto, utilidad;

        public Contabilidad()
        {

        }

        public Contabilidad(int id, int tarjetas, string nombre_cobro, string fecha, string estado, double cobro, double presto, double utilidad)
        {
            this.id = id;
            this.tarjetas = tarjetas;
            this.nombreCobro = nombre_cobro;
            this.fecha = fecha;
            this.estado = estado;
            this.cobro = cobro;
            this.presto = presto;
            this.utilidad = utilidad;
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

        public void setFecha(string pFecha)
        {
            this.fecha = pFecha;
        }

        public string getFecha()
        {
            return this.fecha;
        }

        public void setFechaFinal(string pFecha)
        {
            this.fechaFinal = pFecha;
        }

        public string getFechaFinal()
        {
            return this.fechaFinal;
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

        public void cargarContabilidad()
        {
            try
            {
                Conexion.desconectar();
                script = "SELECT EXISTE_CONTABILIDAD('" + this.getNombreCobro() + "', '" + this.getFecha() +"');";
                command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();
                if (consulta.HasRows)
                {
                    consulta.Read();
                    if(consulta.GetInt32(0) == 1)
                    {
                        Conexion.desconectar();
                        script = "SELECT * FROM CONTABILIDADES WHERE FECHA= '" + this.getFecha() + "' AND NOMBRE_COBRO= '" + this.getNombreCobro() + "';";
                        command = new NpgsqlCommand(script, Conexion.conexion);
                        Conexion.conectar();
                        consulta = command.ExecuteReader();

                        if (consulta.HasRows)
                        {
                            consulta.Read();
                            this.setId(consulta.GetInt32(0));
                            this.setTarjetas(consulta.GetInt32(3));
                            this.setEstado(consulta.GetString(7));
                            this.setCobro(consulta.GetDouble(4));
                            this.setPresto(consulta.GetDouble(5));
                            this.setUtilidad(consulta.GetDouble(6));
                        }
                    }
                    else
                    {
                            this.setId(0);
                            this.setTarjetas(0);
                            this.setEstado(NO_GUARDADO);
                            this.setCobro(0);
                            this.setPresto(0);
                            this.setUtilidad(0);
                        
                    }
                }                
                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Cargar Contabillidad.");
            }
        }

        public void cargarContabilidadConLimites()
        {
            DateTime fechaInicio = Convert.ToDateTime(this.getFecha()).Date;
            DateTime fechaFinal = Convert.ToDateTime(this.getFechaFinal()).Date;

            Console.WriteLine(fechaInicio);

            int tarjetas = 0;
            double cobro = 0;
            double presto = 0;
            double utilidad = 0;

            while (fechaInicio <= fechaFinal)
            {
                try
                {
                    Conexion.desconectar();
                    script = "SELECT EXISTE_CONTABILIDAD('" + this.getNombreCobro() + "', '" + fechaInicio.ToShortDateString() + "');";
                    command = new NpgsqlCommand(script, Conexion.conexion);
                    Conexion.conectar();
                    consulta = command.ExecuteReader();
                    if (consulta.HasRows)
                    {
                        consulta.Read();
                        if (consulta.GetInt32(0) == 1)
                        {
                            Conexion.desconectar();
                            script = "SELECT * FROM CONTABILIDADES WHERE FECHA= '" + fechaInicio.ToShortDateString() + "' AND NOMBRE_COBRO= '" + this.getNombreCobro() + "';";
                            command = new NpgsqlCommand(script, Conexion.conexion);
                            Conexion.conectar();
                            consulta = command.ExecuteReader();

                            if (consulta.HasRows)
                            {
                                consulta.Read();
                                tarjetas = tarjetas + consulta.GetInt32(3);
                                cobro = cobro + consulta.GetDouble(4);
                                presto = presto + consulta.GetDouble(5);
                                utilidad = utilidad + consulta.GetDouble(6);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Consulta: Cargar Contabillidad Con Limites.");
                }
                fechaInicio = fechaInicio.AddDays(1);
            }

            this.setTarjetas(tarjetas);
            this.setCobro(cobro);
            this.setPresto(presto);
            this.setUtilidad(utilidad);

        }
    }
}
