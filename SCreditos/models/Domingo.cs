using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.models
{
    class Domingo
    {
        private int id, idPrestamo, domingos;

        private Double valorPago, valorPorDomingo, valorRestante;

        public Domingo(int pId, int pIdPrestamo, int pDomingos, Double pValorPago, Double pValorPorDomingo, Double pValorRestante)
        {
            this.id = pId;
            this.idPrestamo = pIdPrestamo;
            this.domingos = pDomingos;
            this.valorPago = pValorPago;
            this.valorPorDomingo = pValorPorDomingo;
            this.valorRestante = pValorRestante;
        }

        public void setId(int pId)
        {
            this.id = pId;
        }

        public int getId()
        {
            return this.id;
        }

        public void setIdPrestamo(int pIdPrestamo)
        {
            this.idPrestamo = pIdPrestamo;
        }

        public int getIdPrestamo()
        {
            return this.idPrestamo;
        }

        public void setDomingos(int pDomingos)
        {
            this.domingos = pDomingos;
        }

        public int getDomingos()
        {
            return this.domingos;
        }

        public void setValorPago(Double pValorPago)
        {
            this.valorPago = pValorPago;
        }

        public Double getValorPago()
        {
            return this.valorPago;
        }

        public void setValorPorDomingo(Double pValorPorDomingo)
        {
            this.valorPorDomingo = pValorPorDomingo;
        }

        public Double getValorPorDomingo()
        {
            return this.valorPorDomingo;
        }

        public void setValorRestante(Double pValorRestante)
        {
            this.valorRestante = pValorRestante;
        }

        public Double getValorRestante()
        {
            return this.valorRestante;
        }
    }
}
