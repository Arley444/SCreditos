using SCreditos.models;
using SCreditos.views.dialogs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SCreditos.views
{
    public partial class Principal : Form
    {
        public String CLIENTE_PRIMERO = "PRIMERO";

        public String CLIENTE_ANTERIOR = "ANTES";

        public String CLIENTE_DESPUES = "DESPUES";


        // ---------------------------------------------------------------------------------------------------------------------------------
        //  ATRIBUTOS
        // ---------------------------------------------------------------------------------------------------------------------------------
        private Usuario usuario;

        private Cliente clienteActual;

        private Prestamo prestamoActual;

        private HashSet<Cobro> listaCobros;

        private List<Cliente> listaClientes;


        // ---------------------------------------------------------------------------------------------------------------------------------
        //  CONSTRUCTORES
        // ---------------------------------------------------------------------------------------------------------------------------------
        public Principal(Object usuario)
        {
            InitializeComponent();
            this.usuario = (Usuario)usuario;
            this.Text = "SCREDITOS - " + this.usuario.getNombreCompleto();
            this.cargarCobros(Cobro.cargarCobros());
            this.cargarListaClientes();
            this.cargarClienteInicial();
        }


        // ---------------------------------------------------------------------------------------------------------------------------------
        //  METODOS
        // ---------------------------------------------------------------------------------------------------------------------------------
        private Boolean cobroSelecionado()
        {
            Boolean valido = true;

            if (String.IsNullOrEmpty(cboCobro.Text.Trim()) | String.IsNullOrWhiteSpace(cboCobro.Text.Trim()))
            {
                valido = false;
                this.errorCobro.SetError(this.cboCobro, "Debeas seleccionar o crear un cobro.");
            }
            else
            {
                this.errorCobro.Dispose();
            }

            return valido;
        }

        private Boolean cedulaValida()
        {
            Boolean valido = true;

            if (String.IsNullOrEmpty(txtCedula.Text.Trim()) | String.IsNullOrWhiteSpace(txtCedula.Text.Trim()))
            {
                valido = false;
                this.errorCedula.SetError(this.txtCedula, "Debes ingresar un valor.");
            }
            else
            {
                this.errorCedula.Dispose();
            }

            return valido;
        }

        private Boolean nombreClienteValido()
        {
            Boolean valido = true;

            if (String.IsNullOrEmpty(txtNombre.Text.Trim()) | String.IsNullOrWhiteSpace(txtNombre.Text.Trim()))
            {
                valido = false;
                this.errorNombreCliente.SetError(this.txtNombre, "Debes ingresar un valor.");
            }
            else
            {
                this.errorNombreCliente.Dispose();
            }

            return valido;
        }

        private Boolean direccionValida()
        {
            Boolean valido = true;

            if (String.IsNullOrEmpty(txtDireccion.Text.Trim()) | String.IsNullOrWhiteSpace(txtDireccion.Text.Trim()))
            {
                valido = false;
                this.errorDireccion.SetError(this.txtDireccion, "Debes ingresar un valor.");
            }
            else
            {
                this.errorDireccion.Dispose();
            }

            return valido;
        }

        private Boolean prestamoValido()
        {
            Boolean valido = true;

            if (String.IsNullOrEmpty(txtPrestamo.Text.Trim()) | String.IsNullOrWhiteSpace(txtPrestamo.Text.Trim()))
            {
                valido = false;
                this.errorPrestamo.SetError(this.txtPrestamo, "Debes ingresar un valor.");
            }
            else
            {
                this.errorPrestamo
.Dispose();
            }

            return valido;
        }

        private Boolean telefonoValido()
        {
            Boolean valido = true;

            if (String.IsNullOrEmpty(txtTelefono.Text.Trim()) | String.IsNullOrWhiteSpace(txtTelefono.Text.Trim()))
            {
                valido = false;
                this.errorTelefono.SetError(this.txtTelefono, "Debes ingresar un valor.");
            }
            else
            {
                this.errorTelefono.Dispose();
            }

            return valido;
        }

        private Boolean validarFormularioCrearCliente()
        {
            if (!cobroSelecionado())
            {
                return false;
            }

            if (!cedulaValida())
            {
                return false;
            }

            if (nombreClienteValido())
            {
                return false;
            }

            if (direccionValida())
            {
                return false;
            }

            if (prestamoValido())
            {
                return false;
            }

            if (telefonoValido())
            {
                return false;
            }

            return true;
        }

        private void cargarListaClientes()
        {
            if (!String.IsNullOrEmpty(cboCobro.Text.Trim()) | !String.IsNullOrWhiteSpace(cboCobro.Text.Trim()))
            {
                listaClientes = Cliente.listarClientes(cboCobro.Text.Trim().ToUpper());
            }
        }

        private void cargarClienteInicial()
        {
            if (listaClientes == null)
            {
                clienteActual = null;
            }
            else
            {
                clienteActual = listaClientes.Find(x => x.getRuta() == 1);
                //prestamoActual = consulta.getPrestamoClienteActual(clienteActual.getCedula());
                //consulta.cerrar();

                txtCedula.Text = clienteActual.getCedula();
                txtNombre.Text = clienteActual.getNombre();
                txtDireccion.Text = clienteActual.getDireccion();
                txtTelefono.Text = clienteActual.getTelefono();

                //txtPrestamo.setText(String.valueOf((long)prestamoActual.getPrestamo() / 1000));
                //txtPlazo.setText(String.valueOf(prestamoActual.getPlazo()));
                //txtValor.setText(String.valueOf((long)prestamoActual.getValor()));

                //txtCuota.setText(String.valueOf((long)prestamoActual.getCuota()));
                //txtValor.setText(String.valueOf((long)prestamoActual.getValor()));
                //txtPlazo.setText(String.valueOf(prestamoActual.getPlazo()));

                //txtSaldoCapital.setText(String.valueOf((long)prestamoActual.getPrestamo()));
                //txtSaldoInteres.setText(String.valueOf((long)(prestamoActual.getValor() - prestamoActual.getPrestamo())));

                //txtCuotaCapital.setText(String.valueOf((long)prestamoActual.getCuotaCapital()));
                //txtCuotaInteres.setText(String.valueOf((long)prestamoActual.getCuotaInteres()));
                //cargarTablaDetalles();
            }
        }

        private void cargarCobros(HashSet<Cobro> pLista)
        {
            if (pLista != null)
            {
                cboCobro.Items.Clear();
                foreach (Cobro cobro in pLista)
                {
                    cboCobro.Items.Add(cobro.getNombre());
                }
            }
        }

        private void buscarCliente()
        {
            clienteActual = new Cliente();
            clienteActual.setCedula(txtCedula.Text.Trim());
            clienteActual.setCobro(cboCobro.Text.Trim().ToUpper());
            if (clienteActual.buscarCliente() != null)
            {
                cargarClienteBuscado();
            }
        }

        private void crearNuevoCliente()
        {
            if (validarFormularioCrearCliente())
            {
                Cliente nuevoCliente = new Cliente();
                nuevoCliente.setCedula(txtCedula.Text.Trim().ToUpper());
                nuevoCliente.setNombre(txtNombre.Text.Trim().ToUpper());
                nuevoCliente.setCobro(cboCobro.Text.Trim().ToUpper());
                nuevoCliente.setDireccion(txtDireccion.Text.Trim().ToUpper());
                nuevoCliente.setTelefono(txtTelefono.Text.Trim().ToUpper());

                Prestamo prestamoNuevo = new Prestamo(nuevoCliente.getCedula(), Double.Parse(txtPrestamo.Text));
                prestamoNuevo.setFecha(dpkFecha.Value.ToShortDateString());

                if (this.clienteActual != null)
                {
                    if (rdbAntes.Checked)
                    {
                        nuevoCliente.crearCliente(this.CLIENTE_ANTERIOR, clienteActual, prestamoNuevo);
                    }
                    else
                    {
                        nuevoCliente.crearCliente(this.CLIENTE_DESPUES, clienteActual, prestamoNuevo);
                    }
                }
                else
                {
                    nuevoCliente.crearCliente(this.CLIENTE_PRIMERO, clienteActual, prestamoNuevo);
                }

                clienteActual = nuevoCliente;
                prestamoActual = Prestamo.getPrestamoClienteActual(clienteActual.getCedula());
                cargarListaClientes();
                //cargarClienteActual();
                //cargarInformacionActual();
                //JOptionPane.showMessageDialog(null, "Se ha creado el cliente.", "Exitoso.", JOptionPane.INFORMATION_MESSAGE, null);
                //// Cargar domingos
                //cargarPagoDomingos();
                //cargarInformacionActual();
            }
        }
        

        /*
         * TODO: terminar
         */
        private void cargarClienteBuscado()
        {
            this.txtNombre.Text = clienteActual.getNombre();
            this.txtDireccion.Text = clienteActual.getDireccion();
        }

        // ---------------------------------------------------------------------------------------------------------------------------------
        //  EVENTOS
        // ---------------------------------------------------------------------------------------------------------------------------------
        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuNuevoCobro_Click(object sender, EventArgs e)
        {
            CrearNuevoCobro crearNuevoCobro = new CrearNuevoCobro();
            crearNuevoCobro.ShowDialog();

            if (crearNuevoCobro.getSeCreo())
            {
                cargarCobros(Cobro.cargarCobros());
            }
        }

        private void rdbAntes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAntes.Checked)
            {
                rdbDespues.Checked = false;
            }
        }

        private void rdbDespues_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDespues.Checked)
            {
                rdbAntes.Checked = false;
            }
        }

        private void ckbFechaSistema_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckbFechaSistema.Checked)
            {
                dpkFecha.Value = DateTime.Now;
                dpkFecha.Enabled = false;
            }
            else
            {
                dpkFecha.Enabled = true;
            }
        }

        private void txtCedula_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cobroSelecionado() && cedulaValida())
                {
                    buscarCliente();
                }               
            }
        }


    }
}
