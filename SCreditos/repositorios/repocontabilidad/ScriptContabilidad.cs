using System;

namespace SCreditos.repos.repocontabilidad
{
    class ScriptContabilidad
    {
        private static String script;

        public static String select_all()
        {
            script = "SELECT * FROM CONTABILIDADES";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String select_all_by_nombre_cobro(String pNombreCobro)
        {
            script = "SELECT * FROM CONTABILIDADES WHERE NOMBRE_COBRO= '" + pNombreCobro +"';";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String select_all_by_nombre_cobro_and_fecha_mayor_que(String pNombreCobro, String pFecha)
        {
            script = "SELECT * FROM CONTABILIDADES WHERE NOMBRE_COBRO= '" + pNombreCobro + "' AND FECHA >= '" + pFecha + "';";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String select_all_by_nombre_cobro_and_fecha(String pNombreCobro, String pFecha)
        {
            script = "SELECT * FROM CONTABILIDADES WHERE NOMBRE_COBRO= '" + pNombreCobro + "' AND FECHA= '"+ pFecha +"';";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String select_by_Id(int pId)
        {
            script = "SELECT * FROM CONTABILIDADES WHERE ID= " + pId + ";";

            Console.WriteLine("SQL: " + script);

            return script;
        }
    }
}
