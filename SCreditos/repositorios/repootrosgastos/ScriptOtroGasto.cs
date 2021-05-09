using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.repositorios.repootrosgastos
{
    class ScriptOtroGasto
    {
        public static String create_one_gasto(int pIdContabilidad, String pNombreCobro, String pDescripcion, DateTime pFecha, Double pValor)
        {
            String script = "SELECT CREAR_OTRO_GASTO( " + pIdContabilidad + ", '" + pNombreCobro + "', '" + pDescripcion + "', '" + pFecha.ToShortDateString() + "', " + pValor + ");";

            Console.WriteLine("SQL: " + script);

            return script;
        }
    }
}
