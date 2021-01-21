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
    }
}
