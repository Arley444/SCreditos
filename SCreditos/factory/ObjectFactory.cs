using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.factory
{
    class ObjectUtils
    {
        public static Boolean isNull(Object o)
        {
            return o == null;
        }

        public static Boolean isNullOVacio(String o)
        {
            return o == null || o.Equals("");
        }
    }
}
