using SCreditos.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.factory
{
    class ListValidators
    {
        public static Boolean validarListaVaciaONula(List<Cobro> l)
        {
            return l == null || isEmpty(l);
        }

        private static Boolean isEmpty(List<Cobro> l)
        {
            return l.Count == 0;
        }

        public static Boolean validarListaVaciaONula(List<Cliente> l)
        {
            return l == null || isEmpty(l);
        }

        private static Boolean isEmpty(List<Cliente> l)
        {
            return l.Count == 0;
        }

        public static Boolean validarListaVaciaONula(List<Gasto> l)
        {
            return l == null || isEmpty(l);
        }

        private static Boolean isEmpty(List<Gasto> l)
        {
            return l.Count == 0;
        }

        public static Boolean validarListaVaciaONula(List<Abono> l)
        {
            return l == null || isEmpty(l);
        }

        private static Boolean isEmpty(List<Abono> l)
        {
            return l.Count == 0;
        }

        public static Boolean validarListaVaciaONula(List<Prestamo> l)
        {
            return l == null || isEmpty(l);
        }

        private static Boolean isEmpty(List<Prestamo> l)
        {
            return l.Count == 0;
        }

        public static Boolean validarListaVaciaONula(List<Contabilidad> l)
        {
            return l == null || isEmpty(l);
        }

        private static Boolean isEmpty(List<Contabilidad> l)
        {
            return l.Count == 0;
        }

        public static Boolean validarListaVaciaONula(List<Cartera> l)
        {
            return l == null || isEmpty(l);
        }

        private static Boolean isEmpty(List<Cartera> l)
        {
            return l.Count == 0;
        }
    }
}
