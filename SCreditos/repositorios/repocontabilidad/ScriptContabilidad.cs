using SCreditos.models;
using SCreditos.models.common;
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

        public static String restar_abono_a_contabilidad(Abono abono, Contabilidad contabilidad)
        {
            script = "SELECT RESTAR_ABONO_A_CONTABILIDAD(" + contabilidad.getId()  + ", " + abono.getValor() + ");";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String restar_cobro_utilidad_a_contabilidad(Contabilidad contabilidad, Prestamo prestamo)
        {
            script = "SELECT RESTAR_COBRO_UTILIDAD_Y_TARJETA_DE_CONTABILIDAD(" + contabilidad.getId() + ", " + prestamo.getPrestamo() + ", " + prestamo.getInteres() + ", " + prestamo.getDomingo().getValorPago() + ");";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String cambiar_estado_contabilidad(Contabilidad contabilidad)
        {
            script = "UPDATE CONTABILIDADES SET ESTADO = '" + TipoEstados.GUARDADO + "' WHERE ID = " + contabilidad.getId() + ";";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String corregir_error_contabilidad(String pFecha, String pCobro, Double pValorDomingo)
        {
            script = "UPDATE CONTABILIDADES SET COBRO = ((SELECT COBRO FROM CONTABILIDADES WHERE FECHA = '" + pFecha + "' AND NOMBRE_COBRO = '" + pCobro + "') + " + pValorDomingo + ") WHERE FECHA = '" + pFecha + "' AND NOMBRE_COBRO = '" + pCobro + "';";

            Console.WriteLine("SQL: " + script);

            return script;
        }
    }
}
