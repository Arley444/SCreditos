using SCreditos.factory;
using SCreditos.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCreditos.views.dialogs
{
    public partial class EditarRutaCliente : Form
    {
        private Cliente clienteActual;

        private Cliente clienteProximo;

        private String accion;

        private Cobro cobro;

        public EditarRutaCliente(Object pCobro, Object pCliente)
        {
            InitializeComponent();

            this.clienteActual = pCliente as Cliente;
            this.cobro = pCobro as Cobro;

            cargarClienteInterfaz();
            cargarClientesEnTabla(this.cobro.getClientes());
        }


        // ---------------------------------------------------------------------------------------------
        // METODOS
        // ---------------------------------------------------------------------------------------------
        private void cargarClienteInterfaz()
        {
            this.txtCedula.Text = this.clienteActual.getCedula();
            this.txtDireccion.Text = this.clienteActual.getDireccion();
            this.txtNombre.Text = this.clienteActual.getNombre();
            this.txtTelefono.Text = this.clienteActual.getTelefono();


        }

        private void cargarClientesEnTabla(List<Cliente> pClientes)
        {
            limpiarTablaClientes();

            tablaClientes.ColumnCount = 4;
            tablaClientes.Columns[0].Name = "CEDULA";
            tablaClientes.Columns[1].Name = "NOMBRE";
            tablaClientes.Columns[2].Name = "DIRECCION";
            tablaClientes.Columns[3].Name = "TELEFONO";

            if (!ListValidators.validarListaVaciaONula(pClientes))
            {
                pClientes.ForEach(abono => tablaClientes.Rows.Add(new string[] { abono.getCedula(), abono.getNombre(), abono.getDireccion().ToString(), abono.getTelefono() }));
            }
        }

        private void limpiarTablaClientes()
        {
            tablaClientes.Columns.Clear();
            tablaClientes.Rows.Clear();
        }

        private void cambiarRutaCliente()
        {
            if (!ObjectUtils.isNull(tablaClientes.CurrentRow.Cells[0].Value))
            {
                clienteProximo = cobro.getClientes().Find(c => c.getCedula().Equals(tablaClientes.CurrentRow.Cells[0].Value.ToString()));

                if(rdbPrimero.Checked == true)
                {
                    if (MessageBox.Show("¿Realmente desean poner el cliente: " + this.clienteActual.getNombre() + " primero en la ruta.", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        accion = "PRIMERO";
                        this.Dispose();
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Realmente desean cambiar de ruta el cliente: " + this.clienteActual.getNombre() + ". Despues del cliente: " + clienteProximo.getNombre(), "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        accion = "DESPUES";
                        this.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione algún cliente valido.");
            }
        }

        public String getAccion()
        {
            return this.accion;
        }

        public Object getClienteActual()
        {
            return this.clienteActual;
        }

        public Object getClienteProximo()
        {
            return this.clienteProximo;
        }


        // ---------------------------------------------------------------------------------------------
        // EVENTOS
        // ---------------------------------------------------------------------------------------------
        private void btnCambiarRutaCliente_Click(object sender, EventArgs e)
        {
            cambiarRutaCliente();
        }
    }
}
