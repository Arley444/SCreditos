using SCreditos.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.repos.repocartera
{
    class ScriptCartera
    {
        private static String script;

        public static String select_all(String pCobro)
        {
            script = "SELECT * FROM CARTERAS WHERE NOMBRE_COBRO='" + pCobro + "' ORDER BY FECHA_INICIO ASC;";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String select_ultima_cartera(String pCobro)
        {
            script = "SELECT * FROM CARTERAS WHERE ID = (SELECT MAX(ID) FROM CARTERAS WHERE NOMBRE_COBRO = '" + pCobro + "'); ";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String guardarCartera(Cartera cartera)
        {
            script = "INSERT INTO CARTERAS (NOMBRE_COBRO, FECHA_INICIO, FECHA_FINAL, TARJETAS, COBRO, PRESTO, UTILIDAD, BASE, EFECTIVO, GASTOS, CARTERA, CAJA) VALUES('" + cartera.getNombreCobro() + "', '" + cartera.getFechaInicio() + "', '" + cartera.getFechaFinal() + "', " + cartera.getTarjetas() + ", " + cartera.getCobro() + ", " + cartera.getPresto() + ", " + cartera.getUtilidad() + ", " + cartera.getBase() + ", " + cartera.getEfectivo() + ", " + cartera.getGastos() + ", " + cartera.getCartera() + ", " + cartera.getCaja() + ");";

            Console.WriteLine("SQL: " + script);

            return script;
        }
    }
}
