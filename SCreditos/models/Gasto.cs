using System;

namespace SCreditos.models
{
    class Gasto
    {
        private int id;
        private String nombreCobro;
        private String nombreGasto;
        private String descripcion;
        private DateTime fecha;
        private Double valor;

        public Gasto()
        {

        }

        public Gasto(String pNombreCobro, String pNombreGasto, String pDescripcion, DateTime pFecha, Double pValor)
        {
            this.nombreCobro = pNombreCobro;
            this.nombreGasto = pNombreGasto;
            this.descripcion = pDescripcion;
            this.fecha = pFecha;
            this.valor = pValor;
        }

        public Gasto(int pId, String pNombreCobro, String pNombreGasto, String pDescripcion, DateTime pFecha, Double pValor)
        {
            this.id = pId;
            this.nombreCobro = pNombreCobro;
            this.nombreGasto = pNombreGasto;
            this.descripcion = pDescripcion;
            this.fecha = pFecha;
            this.valor = pValor;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int pid)
        {
            this.id = pid;
        }

        public String getNombreCobro()
        {
            return this.nombreCobro;
        }

        public void setNombreCobro(String pNombreCobro)
        {
            this.nombreCobro = pNombreCobro;
        }

        public String getNombreGasto()
        {
            return this.nombreGasto;
        }

        public void setNombreGasto(String pNombreGasto)
        {
            this.nombreGasto = pNombreGasto;
        }

        public String getDescripcion()
        {
            return this.descripcion;
        }

        public void setDescripcion(String pDescripcion)
        {
            this.descripcion = pDescripcion;
        }

        public DateTime getFecha()
        {
            return this.fecha;
        }

        public void setFecha(DateTime pFecha)
        {
            this.fecha = pFecha;
        }

        public Double getValor()
        {
            return this.valor;
        }

        public void setValor(Double pValor)
        {
            this.valor = pValor;
        }

    }
}
