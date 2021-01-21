using SCreditos.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.repos.repodomingo
{
    class ScriptDomingo
    {
        public static String select_one_domingo_by_id_prestamo(int pIdPrestamo)
        {
            return "SELECT * FROM DOMINGOS WHERE ID_PRESTAMO= '" + pIdPrestamo + "';";
        }

        public static String create_pago_domingos_cliente(Prestamo prestamo, Cliente cliente)
        {
            return "SELECT PAGO_DOMINGOS(" + prestamo.getId() + ", " + cliente.getPrestamos()[0].getDomingo().getDomingos() + ", " + cliente.getPrestamos()[0].getDomingo().getValorPago() + ", " + cliente.getPrestamos()[0].getDomingo().getValorPorDomingo() + ");";
        }

        public static String create_pago_domingos_prestamo(int idPrestamo, Prestamo prestamo)
        {
            return "SELECT PAGO_DOMINGOS(" + idPrestamo + ", " + prestamo.getDomingo().getDomingos() + ", " + prestamo.getDomingo().getValorPago() + ", " + prestamo.getDomingo().getValorPorDomingo() + ");";
        }
    }
}
