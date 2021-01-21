using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCreditos.models
{
    class Cliente
    {
        private int id, ruta;

        private string cedula = null;

        private string cobro = null;

        private string nombre, direccion, telefono, calificacion;

        private List<Prestamo> prestamos;

        public Cliente()
        {

        }

        public Cliente(int id, string cedula, string nombre, string direccion, string cobro, string telefono, string calificacion, int ruta)
        {
            this.id = id;
            this.ruta = ruta;
            this.cedula = cedula;
            this.cobro = cobro;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.calificacion = calificacion;
        }

        public void setPrestamos(List<Prestamo> lista)
        {
            this.prestamos = lista;
        }

        public List<Prestamo> getPrestamos()
        {
            return this.prestamos;
        }
        
        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getRuta()
        {
            return ruta;
        }

        public void setRuta(int ruta)
        {
            this.ruta = ruta;
        }

        public string getCedula()
        {
            return cedula;
        }

        public void setCedula(string cedula)
        {
            this.cedula = cedula;
        }

        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public String getDireccion()
        {
            return direccion;
        }

        public void setDireccion(String direccion)
        {
            this.direccion = direccion;
        }

        public String getCobro()
        {
            return cobro;
        }

        public void setCobro(String cobro)
        {
            this.cobro = cobro;
        }

        public String getTelefono()
        {
            return telefono;
        }

        public void setTelefono(String telefono)
        {
            this.telefono = telefono;
        }

        public String getCalificacion()
        {
            return calificacion;
        }

        public void setCalificacion(String calificacion)
        {
            this.calificacion = calificacion;
        }
        
    }
}
