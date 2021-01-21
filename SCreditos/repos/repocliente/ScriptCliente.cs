using SCreditos.models;
using System;

namespace SCreditos.repos.repocliente
{
    class ScriptCliente
    {
        private static String script;

        public static String select_one_cliente(String pCedula, String pCobro)
        {
            script = "SELECT * FROM CLIENTES WHERE CEDULA LIKE '" + pCedula + "%' AND COBRO = '" + pCobro + "'";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String select_all_cliente_by_cobro(String pCobro)
        {

            script = "SELECT * FROM CLIENTES WHERE COBRO = '" + pCobro + "' ORDER BY RUTA ASC";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String create_one_cliente_primero(String pDespuesDe, Cliente pCliente)
        {

            script = "SELECT CREAR_CLIENTE('" + pCliente.getCedula() + "', '" + pCliente.getNombre() + "', '" + pCliente.getDireccion() + "', '" + pCliente.getCobro() + "', '" + pCliente.getTelefono() + "', '" + pDespuesDe + "', 0, " + (long)pCliente.getPrestamos()[0].getPrestamo() + ", " + (long)pCliente.getPrestamos()[0].getValor() + ", " + (long)(pCliente.getPrestamos()[0].getValor() - pCliente.getPrestamos()[0].getPrestamo()) + ", " + pCliente.getPrestamos()[0].getPlazo() + ", '" + pCliente.getPrestamos()[0].getFechaInicio().ToShortDateString() + "');";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String create_one_cliente_despues(String pDespuesDe, int ruta, Cliente pCliente)
        {
            script = "SELECT CREAR_CLIENTE('" + pCliente.getCedula() + "', '" + pCliente.getNombre() + "', '" + pCliente.getDireccion() + "', '" + pCliente.getCobro() + "', '" + pCliente.getTelefono() + "', '" + pDespuesDe + "', "+ ruta +", " + (long)pCliente.getPrestamos()[0].getPrestamo() + ", " + (long)pCliente.getPrestamos()[0].getValor() + ", " + (long)(pCliente.getPrestamos()[0].getValor() - pCliente.getPrestamos()[0].getPrestamo()) + ", " + pCliente.getPrestamos()[0].getPlazo() + ", '" + pCliente.getPrestamos()[0].getFechaInicio().ToShortDateString() + "');";

            Console.WriteLine("SQL: " + script);

            return script;
        }        
    }
}
