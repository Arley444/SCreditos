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
        private String fecha, cedulaCliente;

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
            this.cuotaInteres = this.interes / this.plazo;

            // Ajustamos el valor del interes de la cuota.
            divisor = this.cuotaInteres % 100;
            if (divisor < 100)
            {
                this.cuotaInteres = this.cuotaInteres - divisor;
            }

            //Calculamos el capital de la cuota.
            this.cuotaCapital = this.cuota - this.cuotaInteres;
        }

        public String getFecha()
        {
            return fecha;
        }

        public String getCedulaCliente()
        {
            return cedulaCliente;
        }

        public void setCedulaCliente(String cedulaCliente)
        {
            this.cedulaCliente = cedulaCliente;
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

        public void setFecha(String fecha)
        {
            this.fecha = fecha;
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

        public static int getDomingosPrestamo(String pCedula)
        {
            int domingos = 0;

            try
            {
                Conexion.desconectar();
                string script = "SELECT * FROM PRESTAMOS WHERE CEDULA_CLIENTE = '" + pCedula + "' AND ESTADO = 'ACTIVO'";
                NpgsqlCommand command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                NpgsqlDataReader consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    consulta.Read();
                    script = "SELECT OBTENER_DOMINGOS_PRESTAMO(" + consulta.GetInt32(0) + ");";
                    Conexion.desconectar();
                    command = new NpgsqlCommand(script, Conexion.conexion);
                    Conexion.conectar();
                    consulta = command.ExecuteReader();

                    if (consulta.HasRows)
                    {
                        consulta.Read();
                        domingos = consulta.GetInt32(0);
                    }
                }

                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Domingos prestamo.");
            }

            return domingos;
        }

        public static Prestamo getPrestamoClienteActual(String pCedula)
        {
            prestamoActual = null;
            try
            {
                Conexion.desconectar();
                string scrip = "SELECT * FROM PRESTAMOS WHERE CEDULA_CLIENTE = '" + pCedula + "' ORDER BY ID DESC;";
                NpgsqlCommand command = new NpgsqlCommand(scrip, Conexion.conexion);
                Conexion.conectar();
                NpgsqlDataReader consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    consulta.Read();
                    prestamoActual = new Prestamo(pCedula, consulta.GetDouble(2) / 1000);
                    prestamoActual.setId(consulta.GetInt32(0));
                    prestamoActual.setFecha(consulta.GetDate(9).ToString());
                    prestamoActual.setValorDebe(consulta.GetDouble(6));
                    prestamoActual.setValorPago(consulta.GetDouble(7));
                }

                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: get prestamo actual");
            }

            return prestamoActual;
        }

        public static List<Cliente> listaPrestamosCanselados(string pFecha)
        {
            List<Cliente> listaClientes = null;
            string script = null;
            NpgsqlCommand command = null;
            NpgsqlDataReader consulta = null;
            try
            {
                Conexion.desconectar();
                script = "SELECT * FROM PRESTAMOS WHERE FECHA_PAGO= '" + pFecha + "';";
                command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                consulta = command.ExecuteReader();
                if (consulta.HasRows)
                {
                    List<Prestamo> listaPrestamos = new List<Prestamo>();
                    while (consulta.Read())
                    {
                        listaPrestamos.Add(new Prestamo(consulta.GetString(1), consulta.GetDouble(2)));
                    }
                    Conexion.desconectar();

                    listaClientes = new List<Cliente>();
                    listaPrestamos.ForEach(prestamo => {
                        script = "SELECT * FROM CLIENTES WHERE CEDULA='" + prestamo.getCedulaCliente() + "';";
                        command = new NpgsqlCommand(script, Conexion.conexion);
                        Conexion.conectar();
                        consulta = command.ExecuteReader();
                        if (consulta.HasRows)
                        {
                            while (consulta.Read())
                            {
                                listaClientes.Add(new Cliente(consulta.GetInt32(0), consulta.GetInt32(7), consulta.GetString(1), consulta.GetString(2), consulta.GetString(3), consulta.GetString(4), consulta.GetString(5), consulta.GetString(6)));
                            }
                        }
                        Conexion.desconectar();

                    });
                }
                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Lista Prestamos Cancelados");
            }

            return listaClientes;
        }

        public static List<Cliente> listaPrestamosIngresados(string pFecha)
        {
            List<Cliente> listaClientes = null;
            string script = null;
            NpgsqlCommand command = null;
            NpgsqlDataReader consulta = null;

            try
            {
                Conexion.desconectar();
                script = "SELECT ID_PRESTAMO FROM ABONOS WHERE FECHA_INICIO= '"+ pFecha + "'  AND VALOR > 0;";
                command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                //LOS ID DE LOS PRESTAMOS.
                consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    List<int> listaIdPrestamos = new List<int>();
                    while (consulta.Read())
                    {
                        listaIdPrestamos.Add(consulta.GetInt32(0));
                    }

                    List<string> listaCedulasClientes = new List<string>();
                    listaIdPrestamos.ForEach(idPrestamo => {
                        Conexion.desconectar();
                        script = "SELECT CEDULA_CLIENTE FROM PRESTAMOS WHERE ID= "+ idPrestamo +";";
                        command = new NpgsqlCommand(script, Conexion.conexion);
                        Conexion.conectar();
                        //LAS CEDULAS DE LOS CLIENTES.
                        consulta = command.ExecuteReader();
                        consulta.Read();
                        listaCedulasClientes.Add(consulta.GetString(0));
                    });

                    listaClientes = new List<Cliente>();
                    listaCedulasClientes.ForEach(cedulaCliente =>
                    {
                        Conexion.desconectar();
                        script = "SELECT * FROM CLIENTES WHERE CEDULA= '"+ cedulaCliente +"';";
                        command = new NpgsqlCommand(script, Conexion.conexion);
                        Conexion.conectar();
                        //LAS CEDULAS DE LOS CLIENTES.
                        consulta = command.ExecuteReader();
                        consulta.Read();
                        listaClientes.Add(new Cliente(consulta.GetInt32(0), consulta.GetInt32(7), consulta.GetString(1), consulta.GetString(2), consulta.GetString(3), consulta.GetString(4), consulta.GetString(5), consulta.GetString(6)));
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Lista Prestamos Ingresados.");
            }

            return listaClientes;
        }

        public static List<Cliente> listaPrestamosNuevos(string pFecha)
        {
            List<Cliente> listaClientes = null;
            string script = null;
            NpgsqlCommand command = null;
            NpgsqlDataReader consulta = null;

            try
            {
                Conexion.desconectar();
                script = "SELECT CEDULA_CLIENTE FROM PRESTAMOS WHERE FECHA_INICIO= '"+ pFecha +"';";
                command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                //LOAS CEDULAS DE LOS CLIENTES.
                consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    List<string> listaCedulasClientes = new List<string>();
                    while (consulta.Read())
                    {
                        listaCedulasClientes.Add(consulta.GetString(0));
                    }

                    listaClientes = new List<Cliente>();
                    listaCedulasClientes.ForEach(cedulaCliente =>
                    {
                        Conexion.desconectar();
                        script = "SELECT * FROM CLIENTES WHERE CEDULA= '" + cedulaCliente + "';";
                        command = new NpgsqlCommand(script, Conexion.conexion);
                        Conexion.conectar();
                        //LAS CEDULAS DE LOS CLIENTES.
                        consulta = command.ExecuteReader();
                        consulta.Read();
                        listaClientes.Add(new Cliente(consulta.GetInt32(0), consulta.GetInt32(7), consulta.GetString(1), consulta.GetString(2), consulta.GetString(3), consulta.GetString(4), consulta.GetString(5), consulta.GetString(6)));
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Lista Prestamos Nuevos.");
            }

            return listaClientes;
        }

        public static List<Cliente> listaClientesNoCuota(string pFecha)
        {
            List<Cliente> listaClientes = null;
            string script = null;
            NpgsqlCommand command = null;
            NpgsqlDataReader consulta = null;

            try
            {
                Conexion.desconectar();
                script = "SELECT ID_PRESTAMO FROM ABONOS WHERE FECHA_INICIO= '" + pFecha + "'  AND VALOR= 0;";
                command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                //LOS ID DE LOS PRESTAMOS.
                consulta = command.ExecuteReader();

                if (consulta.HasRows)
                {
                    List<int> listaIdPrestamos = new List<int>();
                    while (consulta.Read())
                    {
                        listaIdPrestamos.Add(consulta.GetInt32(0));
                    }

                    List<string> listaCedulasClientes = new List<string>();
                    listaIdPrestamos.ForEach(idPrestamo => {
                        Conexion.desconectar();
                        script = "SELECT CEDULA_CLIENTE FROM PRESTAMOS WHERE ID= " + idPrestamo + ";";
                        command = new NpgsqlCommand(script, Conexion.conexion);
                        Conexion.conectar();
                        //LAS CEDULAS DE LOS CLIENTES.
                        consulta = command.ExecuteReader();
                        consulta.Read();
                        listaCedulasClientes.Add(consulta.GetString(0));
                    });

                    listaClientes = new List<Cliente>();
                    listaCedulasClientes.ForEach(cedulaCliente =>
                    {
                        Conexion.desconectar();
                        script = "SELECT * FROM CLIENTES WHERE CEDULA= '" + cedulaCliente + "';";
                        command = new NpgsqlCommand(script, Conexion.conexion);
                        Conexion.conectar();
                        //LAS CEDULAS DE LOS CLIENTES.
                        consulta = command.ExecuteReader();
                        consulta.Read();
                        listaClientes.Add(new Cliente(consulta.GetInt32(0), consulta.GetInt32(7), consulta.GetString(1), consulta.GetString(2), consulta.GetString(3), consulta.GetString(4), consulta.GetString(5), consulta.GetString(6)));
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Lista Prestamos Ingresados.");
            }

            return listaClientes;
        }

        public void calificarCliente()
        {
            try
            {
                Conexion.desconectar();
                string script = "SELECT CALIFICAR_CLIENTE('" + this.getCedulaCliente() + "');";
                NpgsqlCommand command = new NpgsqlCommand(script, Conexion.conexion);
                Conexion.conectar();
                command.ExecuteReader();
                Conexion.desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consulta: Calificar Cliente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
