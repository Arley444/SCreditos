using SCreditos.factory;
using SCreditos.models;
using System;

namespace SCreditos.repos.repogasto
{
    class ScriptGasto
    {
        public static String create_one_gasto(Gasto gasto)
        {
            if (!ObjectUtils.isNull(gasto.getDescripcion()))
            {
                return "SELECT CREAR_GASTO( '" + gasto.getNombreCobro() + "', '" + gasto.getNombreGasto() + "', '" + gasto.getDescripcion() + "', '" + gasto.getFecha().ToShortDateString() + "', " + gasto.getValor() + ");";
            }

            return "SELECT CREAR_GASTO( '" + gasto.getNombreCobro() + "', '" + gasto.getNombreGasto() + "', NULL, '" + gasto.getFecha().ToShortDateString() + "', " + gasto.getValor() + ");";
        }
    }
}
