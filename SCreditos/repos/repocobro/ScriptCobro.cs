using SCreditos.models;
using System;

namespace SCreditos.repos.repocobro
{
    class ScriptCobro
    {
        private static String script;

        public static String select_all()
        {
            script = "SELECT * FROM COBROS";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String select_by_nombre(String nombre)
        {
            script = "SELECT * FROM COBROS WHERE NOMBRE= '" + nombre +"';";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String create_new_cobro(Cobro cobro)
        {
            script = "SELECT CREAR_COBROS('" + cobro.getNombre() + "', " + cobro.getCapital() + ", '" + cobro.getFechaInicio().ToShortDateString() + "');";

            Console.WriteLine("SQL: " + script);

            return script;
        }
    }
}
