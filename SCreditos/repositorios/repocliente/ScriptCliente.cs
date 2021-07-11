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
            Console.WriteLine("SELECT CREAR_CLIENTE('" + pCliente.getCedula() + "', '" + pCliente.getNombre() + "', '" + pCliente.getDireccion() + "', '" + pCliente.getCobro() + "', '" + pCliente.getTelefono() + "', '" + pDespuesDe + "', " + ruta + ", " + (long)pCliente.getPrestamos()[0].getPrestamo() + ", " + (long)pCliente.getPrestamos()[0].getValor() + ", " + (long)(pCliente.getPrestamos()[0].getValor() - pCliente.getPrestamos()[0].getPrestamo()) + ", " + pCliente.getPrestamos()[0].getPlazo() + ", '" + pCliente.getPrestamos()[0].getFechaInicio().ToShortDateString() + "');");

            script = "SELECT CREAR_CLIENTE('" + pCliente.getCedula() + "', '" + pCliente.getNombre() + "', '" + pCliente.getDireccion() + "', '" + pCliente.getCobro() + "', '" + pCliente.getTelefono() + "', '" + pDespuesDe + "', "+ ruta +", " + (long)pCliente.getPrestamos()[0].getPrestamo() + ", " + (long)pCliente.getPrestamos()[0].getValor() + ", " + (long)(pCliente.getPrestamos()[0].getValor() - pCliente.getPrestamos()[0].getPrestamo()) + ", " + pCliente.getPrestamos()[0].getPlazo() + ", '" + pCliente.getPrestamos()[0].getFechaInicio().ToShortDateString() + "');";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String editar_ruta_cliente(String pCedulaClienteActual, String pCobro, String pAccion, int pRutaClienteProximo)
        {
            Console.WriteLine("SELECT EDITAR_RUTA_CLIENTE('" + pCedulaClienteActual + "', '" + pCobro + "', '" + pAccion + "', " + pRutaClienteProximo + ");");

            script = "SELECT EDITAR_RUTA_CLIENTE('" + pCedulaClienteActual + "', '" + pCobro + "', '" + pAccion + "', " + pRutaClienteProximo + ");";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String editar_nombre_cliente(String pNombreCliente, int pIdCliente)
        {
            Console.WriteLine("UPDATE CLIENTES SET NOMBRE = '" + pNombreCliente + "' WHERE ID = " + pIdCliente + ";");

            script = "UPDATE CLIENTES SET NOMBRE = '" + pNombreCliente + "' WHERE ID = " + pIdCliente + ";";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String editar_direccion_cliente(String pDireccion, int pIdCliente)
        {
            Console.WriteLine("UPDATE CLIENTES SET DIRECCION = '" + pDireccion + "' WHERE ID = " + pIdCliente + ";");

            script = "UPDATE CLIENTES SET DIRECCION = '" + pDireccion + "' WHERE ID = " + pIdCliente + ";";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String editar_telefono_cliente(String pTelefono, int pIdCliente)
        {
            Console.WriteLine("UPDATE CLIENTES SET TELEFONO = " + pTelefono + " WHERE ID = " + pIdCliente + ";");

            script = "UPDATE CLIENTES SET TELEFONO = " + pTelefono + " WHERE ID = " + pIdCliente + ";";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String editar_cedula_cliente(String pCedula, int pIdCliente)
        {
            Console.WriteLine("UPDATE CLIENTES SET CEDULA = " + pCedula + " WHERE ID = " + pIdCliente + ";");

            script = "UPDATE CLIENTES SET CEDULA = '" + pCedula + "' WHERE ID = " + pIdCliente + ";";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String editar_cedula_cliente_prestamos(String pCedula, String pCedulaAnterior)
        {
            Console.WriteLine("UPDATE PRESTAMOS SET CEDULA_CLIENTE = '" + pCedula + "' WHERE CEDULA_CLIENTE = '" + pCedulaAnterior + "';");

            script = "UPDATE PRESTAMOS SET CEDULA_CLIENTE = '" + pCedula + "' WHERE CEDULA_CLIENTE = '" + pCedulaAnterior + "';";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String existe_cliente(String pCedula)
        {
            Console.WriteLine("SELECT * FROM CLIENTES WHERE CEDULA = '" + pCedula + "';");

            script = "SELECT * FROM CLIENTES WHERE CEDULA = '" + pCedula + "';";

            Console.WriteLine("SQL: " + script);

            return script;
        }

        public static String eliminar_cliente(Cliente pCliente)
        {
            Console.WriteLine("SELECT ELIMINAR_CLIENTE('" + pCliente.getCedula() + "');");

            script = "SELECT ELIMINAR_CLIENTE('" + pCliente.getCedula() + "');";

            Console.WriteLine("SQL: " + script);

            return script;
        }
    }
}
