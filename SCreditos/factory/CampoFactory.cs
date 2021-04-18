using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.factory
{
    class CampoFactory
    {
        public static Boolean isNull(String pCampo)
        {
            return pCampo == null || String.IsNullOrEmpty(pCampo) || String.IsNullOrWhiteSpace(pCampo);
        }

        public static Boolean isNumeric(String pCampo)
        {
            try
            {
                long i = Convert.ToInt64(pCampo);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
