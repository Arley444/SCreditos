using SCreditos.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.repos.repoabono
{
    class ScriptAbono
    {
        private static String script;

        public static String select_all_abonos_by_id_prestamo(int pIdPrestamo)
        {
            script = "SELECT * FROM ABONOS  WHERE ID_PRESTAMO= '" + pIdPrestamo + "';";

            Console.WriteLine("SQL: " + script);

            return script;
        }
        
        public static String select_cargar_abono(Cliente cliente, Abono abono)
        {
            script = "SELECT CARGAR_ABONO(" + abono.getIdPrestamo() + ", '" + abono.getFecha().ToShortDateString() + "', " + abono.getValor() + ", '" + cliente.getCobro() + "');";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String aumentar_valor_restante_abono(Abono abono, double valorAumentar)
        {
            script = "SELECT AUMENTAR_RESTANTE_ABONO(" + abono.getId() + ", " + valorAumentar + ");";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String eliminar_abono(Abono abono, Prestamo prestamo, Contabilidad contabilidad)
        {
            script = "SELECT ELIMINAR_ABONO(" + prestamo.getId() + ", " + abono.getId() + ", " + contabilidad.getId() + ");";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String eliminar_abonos(Prestamo prestamo)
        {
            script = "SELECT ELIMINAR_ABONOS(" + prestamo.getId() + ");";

            Console.WriteLine("SQL: " + script);

            return script;
        }
    }
}
