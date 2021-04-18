using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Npgsql;

namespace SCreditos.models
{
    class Prestamo
    {
        private const double PORCENTAJE_INTERES = 0.20;
        private const int PLAZO_BAJO = 30;
        private const int PLAZO_ALTO = 40;

        private int id, plazo;
        private double prestamo, valor, interes, cuota, cuotaCapital, cuotaInteres, valorDebe, valorPago;
        private DateTime fechaInicio, fechaPago;
        private String cedulaCliente, estado, calificacion, tipoPrestamo;
        private Domingo domingo;
        private List<Abono> abonos;


        private static Prestamo prestamoActual;

        public Prestamo()
        {

        }

        public Prestamo(String pCedula, double pPrestamo)
        {
            this.cedulaCliente = pCedula;

            // Valor que solicito el cliente.
            this.prestamo = pPrestamo * 1000;

            // Calculamos intereses        
            this.interes = this.prestamo * PORCENTAJE_INTERES;

            //Calculamos el plazo.
            if (this.prestamo < 500000)
            {
                this.plazo = PLAZO_BAJO;
            }
            else
            {
                this.plazo = PLAZO_ALTO;
            }

            // Calculamos el valor total del prestamo.
            this.valor = this.prestamo + this.interes;

            //Ajustamos el valor total.
            double divisor = this.valor % 1000;
            if (divisor > 500)
            {
                this.valor = this.valor + (1000 - divisor);
            }
            else
            {
                this.valor = this.valor - divisor;
            }

            //Calculamos cuotas.
            this.cuota = (this.valor / this.plazo);

            // Ajustamos el valor de la cuota.
            divisor = this.cuota % 100;
            if (divisor > 50)
            {
                this.cuota = this.cuota + (100 - divisor);
            }
            else
            {
                this.cuota = this.cuota - divisor;
            }

            //Calculamos el interes de la cuota.
            this.cuotaInteres = this.cuota * PORCENTAJE_INTERES;

            // Ajustamos el valor del interes de la cuota.
            divisor = this.cuotaInteres % 100;
            if (divisor < 100)
            {
                this.cuotaInteres = this.cuotaInteres - divisor;
            }

            //Calculamos el capital de la cuota.
            this.cuotaCapital = this.cuota - this.cuotaInteres;
        }

        public Prestamo(String pCedula, double pPrestamo, double pValor)
        {
            this.cedulaCliente = pCedula;

            // Valor que solicito el cliente.
            this.prestamo = pPrestamo * 1000;

            // Calculamos intereses        
            this.interes = pValor - this.prestamo;

            //Calculamos el plazo.
            if (this.prestamo < 500000)
            {
                this.plazo = PLAZO_BAJO;
            }
            else
            {
                this.plazo = PLAZO_ALTO;
            }

            // Calculamos el valor total del prestamo.
            this.valor = this.prestamo + this.interes;

            //Ajustamos el valor total.
            double divisor = this.valor % 1000;
            if (divisor > 500)
            {
                this.valor = this.valor + (1000 - divisor);
            }
            else
            {
                this.valor = this.valor - divisor;
            }

            //Calculamos cuotas.
            this.cuota = (this.valor / this.plazo);

            // Ajustamos el valor de la cuota.
            divisor = this.cuota % 100;
            if (divisor > 50)
            {
                this.cuota = this.cuota + (100 - divisor);
            }
            else
            {
                this.cuota = this.cuota - divisor;
            }

            //Calculamos el interes de la cuota.
            this.cuotaInteres = this.cuota * PORCENTAJE_INTERES;

            // Ajustamos el valor del interes de la cuota.
            divisor = this.cuotaInteres % 100;
            if (divisor < 100)
            {
                this.cuotaInteres = this.cuotaInteres - divisor;
            }

            //Calculamos el capital de la cuota.
            this.cuotaCapital = this.cuota - this.cuotaInteres;
        }

        public DateTime getFechaInicio()
        {
            return this.fechaInicio;
        }

        public DateTime getFechaPago()
        {
            return this.fechaPago;
        }

        public String getCedulaCliente()
        {
            return cedulaCliente;
        }

        public String getEstado()
        {
            return this.estado;
        }

        public void setCedulaCliente(String cedulaCliente)
        {
            this.cedulaCliente = cedulaCliente;
        }

        public void setEstado(String estado)
        {
            this.estado = estado;
        }

        public double getValorDebe()
        {
            return valorDebe;
        }

        public void setValorDebe(double valorDebe)
        {
            this.valorDebe = valorDebe;
        }

        public double getValorPago()
        {
            return valorPago;
        }

        public void setValorPago(double valorPago)
        {
            this.valorPago = valorPago;
        }

        public void setFechaInicio(DateTime fecha)
        {
            this.fechaInicio = fecha;
        }

        public void setFechaPago(DateTime fecha)
        {
            this.fechaPago = fecha;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getPlazo()
        {
            return plazo;
        }

        public void setPlazo(int plazo)
        {
            this.plazo = plazo;
        }

        public double getPrestamo()
        {
            return prestamo;
        }

        public void setPrestamo(double prestamo)
        {
            this.prestamo = prestamo;
        }

        public double getValor()
        {
            return valor;
        }

        public void setValor(double valor)
        {
            this.valor = valor;
        }

        public double getInteres()
        {
            return interes;
        }

        public void setInteres(double interes)
        {
            this.interes = interes;
        }

        public double getCuota()
        {
            return cuota;
        }

        public void setCuota(double cuota)
        {
            this.cuota = cuota;
        }

        public double getCuotaCapital()
        {
            return cuotaCapital;
        }

        public void setCuotaCapital(double cuotaCapital)
        {
            this.cuotaCapital = cuotaCapital;
        }

        public double getCuotaInteres()
        {
            return cuotaInteres;
        }

        public void setCuotaInteres(double cuotaInteres)
        {
            this.cuotaInteres = cuotaInteres;
        }

        public void setDomingo(Domingo pDomingo)
        {
            this.domingo = pDomingo;
        }

        public Domingo getDomingo()
        {
            return this.domingo;
        }

        public List<Abono> getAbonos()
        {
            return this.abonos;
        }

        public void setAbonos(List<Abono> lista)
        {
            this.abonos = lista;
        }

        public String getCalificacion()
        {
            return this.calificacion;
        }

        public void setCalificacion(String pCalificacion)
        {
            this.calificacion = pCalificacion;
        }

        public String getTipoPrestamo()
        {
            return this.tipoPrestamo;
        }

        public void setTipoPrestamo(String pTipoPrestamo)
        {
            this.tipoPrestamo = pTipoPrestamo;
        }
    }
}
