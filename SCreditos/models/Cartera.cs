using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCreditos.models
{
    class Cartera
    {
        private static NpgsqlCommand command;

        private static NpgsqlDataReader consulta;

        private List<Object> listaCarteras;

        private Cartera unaCartera;

        private int id, tarjetas;

        private static string script;

        private string nombreCobro, fechaInicio, fechaFinal, estado;

        private Double cobro, presto, utilidad, baseCobrador, efectivo, gastos, cartera, caja;

        public Cartera()
        {

        }

        public Cartera(int id, int tarjetas, string nombreCobro, string fechaInicio, string fechaFinal, string estado, double cobro, double presto, double utilidad, double baseCobrador, double efectivo, double gastos, double cartera, double caja)
        {
            this.id = id;
            this.tarjetas = tarjetas;
            this.nombreCobro = nombreCobro;
            this.fechaInicio = fechaInicio;
            this.fechaFinal = fechaFinal;
            this.estado = estado;
            this.cobro = cobro;
            this.presto = presto;
            this.utilidad = utilidad;
            this.baseCobrador = baseCobrador;
            this.efectivo = efectivo;
            this.gastos = gastos;
            this.cartera = cartera;
            this.caja = caja;
        }

        public static string agregarTotales(string pNombreCobro)
        {
            double totalCapital = 0;
            double totalInteres = 0;

            try
            {
                Conexion.desconectar();
                script = "SELECT MAX(CARTERA) FROM CARTERAS WHERE NOMBRE_COBRO='" + pNombreCobro + "';";
                command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();
                if (consulta.HasRows)
                {
                    consulta.Read();
                    totalInteres = consulta.GetDouble(0) * 0.2;
                    totalCapital = consulta.GetDouble(0) - totalInteres;
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Agregar Totales.");
            }

            return "CAP_TOTAL = "+ totalCapital + "     INT_TOTAL = "+ totalInteres;
        }

        public List<Object> listarCarteras()
        {
            listaCarteras = null;

            try
            {
                Conexion.desconectar();
                script = "SELECT * FROM CARTERAS WHERE NOMBRE_COBRO='" + this.getNombreCobro() + "' ORDER BY FECHA_INICIO ASC;";
                command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();
                if (consulta.HasRows)
                {
                    listaCarteras = new List<Object>();
                    while (consulta.Read())
                    {          
                        //this.setEstado(consulta.GetString(13));
                        listaCarteras.Add(new Cartera(
                            consulta.GetInt32(0),
                            consulta.GetInt32(4),
                            this.getNombreCobro(),
                            consulta.GetDate(2).ToString(),
                            consulta.GetDate(3).ToString(),
                            "SAVE",
                            consulta.GetDouble(5),
                            consulta.GetDouble(6),
                            consulta.GetDouble(7),
                            consulta.GetDouble(8),
                            consulta.GetDouble(9),
                            consulta.GetDouble(10),
                            consulta.GetDouble(11),
                            consulta.GetDouble(12)
                            ));
                    }                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Listar Carteras");
            }

            return listaCarteras;
        }


        public void setId(int pId)
        {
            this.id = pId ;
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

        public void setFechaInicio(string pFechaInicio)
        {
            this.fechaInicio = pFechaInicio;
        }

        public string getFechaInicio()
        {
            return this.fechaInicio;
        }

        public void setFechaFinal(string pFechaFinal)
        {
            this.fechaFinal = pFechaFinal;
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

        public void setBase(Double pBase)
        {
            this.baseCobrador = pBase;
        }

        public Double getBase()
        {
            return this.baseCobrador;
        }

        public void setEfectivo(Double pEfectivo)
        {
            this.efectivo = pEfectivo;
        }

        public Double getEfectivo()
        {
            return this.efectivo;
        }

        public void setGastos(Double pGastos)
        {
            this.gastos = pGastos;
        }

        public Double getGastos()
        {
            return this.gastos;
        }

        public void setCartera(Double pCartera)
        {
            this.cartera = pCartera;
        }

        public Double getCartera()
        {
            return this.cartera;
        }

        public void setCaja(Double pCaja)
        {
            this.caja = pCaja;
        }

        public Double getCaja()
        {
            return this.caja;
        }

    }
}
