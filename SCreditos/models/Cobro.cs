using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SCreditos.models
{
    class Cobro
    {
        private long id;

        private String nombre;

        private DateTime fechaInicio;

        private int capital;

        private List<Cliente> clientes;

        public Cobro()
        {

        }

        public Cobro(long id, String nombre, List<Cliente> clientes)
        {
            this.id = id;
            this.nombre = nombre;
            this.clientes = clientes;
        }

        public List<Cliente> getClientes()
        {
            return this.clientes;
        }

        public void setClientes(List<Cliente> clientes)
        {
            this.clientes = clientes;
        }

        public void setFechaInicio(DateTime dateTime)
        {
            this.fechaInicio = dateTime;
        }

        public DateTime getFechaInicio()
        {
            return this.fechaInicio;
        }

        public long getId()
        {
            return id;
        }

        public void setId(long id)
        {
            this.id = id;
        }

        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public int getCapital()
        {
            return this.capital;
        }

        public void setCapital(int capital)
        {
            this.capital = capital;
        }
    }
}
