using SCreditos.models;
using System;

namespace SCreditos.repos.repoprestamo
{
    class ScriptPrestamo
    {
        private static String script;

        public static String select_one_prestamo_by_cedula_cliente(String pCedula)
        {
            return "SELECT * FROM PRESTAMOS WHERE CEDULA_CLIENTE= '" + pCedula + "';";
        }

        public static String cancelar_one_prestamo(Prestamo pIdPrestamo, DateTime pFecha, Cobro pCobro)
        {
            script = "SELECT CANCELAR_PRESTAMO(" + pIdPrestamo.getId() + ", '" + pFecha.ToShortDateString() + "', '" + pCobro.getNombre() + "');";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String select_one_prestamo_by_id(int pId)
        {
            return "SELECT * FROM PRESTAMOS WHERE ID= " + pId + ";";
        }

        public static String create_new_prestamo(Cobro cobro, Prestamo prestamo)
        {
            return "SELECT CREAR_NUEVO_PRESTAMO('" + prestamo.getCedulaCliente() + "', " + prestamo.getPrestamo() + ", " + prestamo.getValor() + ", " + prestamo.getInteres() + ", " + prestamo.getPlazo() + ", '" + prestamo.getFechaInicio().ToShortDateString() + "', '" + cobro.getNombre() + "');";
        }
        
        public static String select_one_prestamo_last_by_cedula_cliente(String pCedula)
        {
            return "SELECT * FROM PRESTAMOS WHERE CEDULA_CLIENTE= '" + pCedula + "' ORDER BY ID DESC;";
        }

        public static String calificar_prestamo(Prestamo pPrestamo)
        {
            return "SELECT CALIFICAR_PRESTAMO('" + pPrestamo.getId() + "');";
        }

        public static String enviar_clavo(Cobro cobro, Prestamo prestamo, DateTime fecha)
        {
            return "SELECT ENVIAR_CLAVO("+ prestamo.getId() +", '"+ cobro.getNombre() +"'" + ", '" + fecha.ToShortDateString() + "');";
        }
    }
}
