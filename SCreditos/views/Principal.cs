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

        private Cartera carteraActual;

        private Contabilidad contabilidad;
        
        private List<Cliente> listaClientes;

        private HashSet<Cobro> listaCobros;

        private List<Object> listaCarteras;


        // ---------------------------------------------------------------------------------------------------------------------------------
        //  CONSTRUCTORES
        // ---------------------------------------------------------------------------------------------------------------------------------
        public Principal(Object usuario)
        {
            InitializeComponent();
            this.usuario = (Usuario)usuario;
            this.Text = "SCREDITOS - " + this.usuario.getNombreCompleto();           
            this.cargarCobros();
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

            if (!nombreClienteValido())
            {
                return false;
            }

            if (!direccionValida())
            {
                return false;
            }

            if (!prestamoValido())
            {
                return false;
            }

            if (!telefonoValido())
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
                prestamoActual = Prestamo.getPrestamoClienteActual(clienteActual.getCedula());
                this.cargarInformacionActual();
            }
        }

        private void cargarInformacionActual()
        {
            limpiarInformacionActual();
            txtCedula.Text = clienteActual.getCedula();
            txtNombre.Text = clienteActual.getNombre();
            txtDireccion.Text = clienteActual.getDireccion();
            txtTelefono.Text = clienteActual.getTelefono();
            
            txtPrestamo.Text = ((long)prestamoActual.getPrestamo() / 1000).ToString();
            txtPlazo.Text = (prestamoActual.getPlazo()).ToString();
            txtValor.Text = ((long)prestamoActual.getValor()).ToString();

            txtCuota.Text = ((long)prestamoActual.getCuota()).ToString();
            txtValor.Text = ((long)prestamoActual.getValor()).ToString();
            txtPlazo.Text = (prestamoActual.getPlazo()).ToString();


            txtBoleta.Text = prestamoActual.getId().ToString();
            txtSaldoCapital.Text = ((long)prestamoActual.getPrestamo()).ToString();
            txtSaldoIntereses.Text = ((long)(prestamoActual.getValor() - prestamoActual.getPrestamo())).ToString();

            txtCuotaCapital.Text = ((long)prestamoActual.getCuotaCapital()).ToString();
            txtCuotaIntereses.Text = ((long)prestamoActual.getCuotaInteres()).ToString();
            cargarTablaDetalles();
            cargarTablaPrestamosCanselados();
            cargarTablaPrestamosIngresados();
            cargarTablaPrestamosNuevos();
            cargarTablaClientesNoCuota();
            cargarContabilidad();
            cargarTotales();
        }

        private void cargarCobros()
        {
            listaCobros = Cobro.cargarCobros();

            if (listaCobros != null)
            {
                cboCobro.Items.Clear();
                foreach (Cobro cobro in listaCobros)
                {
                    cboCobro.Items.Add(cobro.getNombre());
                }
            }

        }

        private void limpiarInformacionActual()
        {
            txtCedula.Text = null;
            txtNombre.Text = null;
            txtDireccion.Text = null;
            txtTelefono.Text = null;
            txtCuota.Text = null;
            txtPrestamo.Text = null;
            txtPlazo.Text = null;
            txtValor.Text = null;
            dpkFecha.Text = DateTime.Now.ToShortDateString();
            txtBoleta.Text = null;
            txtSaldoCapital.Text = null;
            txtSaldoIntereses.Text = null;
            txtCuotaCapital.Text = null;
            txtCuotaIntereses.Text = null;
            tablaDescripcion.Columns.Clear();
            tablaDescripcion.Rows.Clear();
            tablaPrestamosCancelados.Columns.Clear();
            tablaPrestamosCancelados.Rows.Clear();
        }

        private void buscarCliente()
        {
            Cliente clienteBuscado = new Cliente();
            clienteBuscado.setCedula(txtCedula.Text.Trim());
            clienteBuscado.setCobro(cboCobro.Text.Trim().ToUpper());
            if (clienteBuscado.buscarCliente() != null)
            {
                cargarClienteBuscado(clienteBuscado);
            }
        }

        private void cargarClienteBuscado(Cliente clienteBuscado)
        {
            clienteActual = clienteBuscado;
            prestamoActual = Prestamo.getPrestamoClienteActual(clienteActual.getCedula());
            this.cargarInformacionActual();
        }

        private void cambioDeCobro()
        {
            this.limpiarInformacionActual();
            this.cargarListaClientes();
            this.cargarClienteInicial();
        }

        private void calcularPrestamo()
        {
            double valor = Double.Parse(txtPrestamo.Text);

            if (valor > 0)
            {
                Prestamo prestamo = new Prestamo("", valor);
                txtCuota.Text = ((long)prestamo.getCuota()).ToString();

                txtValor.Text = ((long)prestamo.getValor()).ToString();
                txtPlazo.Text = prestamo.getPlazo().ToString();

                txtSaldoCapital.Text = ((long)prestamo.getPrestamo()).ToString();
                txtSaldoIntereses.Text = ((long)(prestamo.getValor() - prestamo.getPrestamo())).ToString();

                txtCuotaCapital.Text = ((long)prestamo.getCuotaCapital()).ToString();
                txtCuotaIntereses.Text = ((long)prestamo.getCuotaInteres()).ToString();
            }
        }

        private void irPrimerCliente()
        {
            cargarListaClientes();
            if(listaClientes != null)
            {
                clienteActual = listaClientes.Find(cliente => cliente.getRuta() == 1);
                prestamoActual = Prestamo.getPrestamoClienteActual(clienteActual.getCedula());
                cargarInformacionActual();
            }
        }

        private void irUltimoCliente()
        {
            cargarListaClientes();
            if (listaClientes != null)
            {
                clienteActual = listaClientes.Find(cliente => cliente.getRuta() == listaClientes.Count);
                prestamoActual = Prestamo.getPrestamoClienteActual(clienteActual.getCedula());
                cargarInformacionActual();
            }
        }

        private void irAnteriorCliente()
        {
            cargarListaClientes();
            if (listaClientes != null)
            {
                if (clienteActual.getRuta() == 1)
                {
                    clienteActual = listaClientes.Find(cliente => cliente.getRuta() == listaClientes.Count);
                }
                else
                {
                    clienteActual = listaClientes.Find(cliente => cliente.getRuta() == clienteActual.getRuta() - 1);
                }
                prestamoActual = Prestamo.getPrestamoClienteActual(clienteActual.getCedula());
                cargarInformacionActual();
            }
        }

        private void irSiguienteCliente()
        {
            cargarListaClientes();
            if (listaClientes != null)
            {
                if (clienteActual.getRuta() == listaClientes.Count)
                {
                    clienteActual = listaClientes.Find(cliente => cliente.getRuta() == 1);
                }
                else
                {
                    clienteActual = listaClientes.Find(cliente => cliente.getRuta() == clienteActual.getRuta() + 1);
                }
                prestamoActual = Prestamo.getPrestamoClienteActual(clienteActual.getCedula());
                cargarInformacionActual();
            }   
        }

        private void crearNuevoCliente()
        {
            if (validarFormularioCrearCliente())
            {
                if (listaClientes != null)
                {
                    if (!listaClientes.Exists(cliente => cliente.getCedula().Equals(txtCedula.Text)))
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
                        cargarInformacionActual();
                        // Cargar domingos
                        cargarPagoDomingos();
                        cargarInformacionActual();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un cliente con la cedula: " + txtCedula.Text);
                    }
                }
                else
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
                    cargarInformacionActual();
                    // Cargar domingos
                    cargarPagoDomingos();
                    cargarInformacionActual();
                }
                
            }
        }

        private void cargarPagoDomingos()
        {
            int domingos = Prestamo.getDomingosPrestamo(clienteActual.getCedula());

            CargarDomingos emergenteCargarDomingos = new CargarDomingos(domingos, prestamoActual.getValor(), prestamoActual.getId());
            emergenteCargarDomingos.ShowDialog();
        }

        private void cargarTablaDetalles()
        {
            tablaDescripcion.ColumnCount = 4;
            tablaDescripcion.Columns[0].Name = "FECHA -> ABONO";
            tablaDescripcion.Columns[1].Name = "ABONO";
            tablaDescripcion.Columns[2].Name = "RESTA";
            tablaDescripcion.Columns[3].Name = "TIPO";

            List<Abono> listaAbonos = Abono.listaAbonosCliente(clienteActual.getCedula());

            if (listaAbonos != null)
            {
                            listaAbonos.ForEach(abono => tablaDescripcion.Rows.Add(new string[] { abono.getFecha(), abono.getValor().ToString(), abono.getRestante().ToString(), abono.getTipo() }));
            }

        }

        private void cargarTablaPrestamosCanselados()
        {
            lblCantidadPrestamosIngresados.Text = "0";
           tablaPrestamosCancelados.Columns.Clear();
            tablaPrestamosCancelados.Rows.Clear();

            tablaPrestamosCancelados.ColumnCount = 1;
            tablaPrestamosCancelados.Columns[0].Name = "TARJETAS CANCELADAS";

            List<Cliente> listaClientes = Prestamo.listaPrestamosCanselados(dpkFecha.Value.ToShortDateString());

            if (listaClientes != null)
            {
                listaClientes.ForEach(cliente => tablaPrestamosCancelados.Rows.Add(new string[] { cliente.getCedula()+" / "+cliente.getNombre() }));

                lblCantidadPrestamosIngresados.Text = listaClientes.Count.ToString();
            }

        }

        private void cargarTablaPrestamosIngresados()
        {
            lblCantidadPrestamosIngresados.Text = "0";
            tablaPrestamosIngresados.Columns.Clear();
            tablaPrestamosIngresados.Rows.Clear();

            tablaPrestamosIngresados.ColumnCount = 1;
            tablaPrestamosIngresados.Columns[0].Name = "PRESTAMOS INGRESADOS";

            List<Cliente> listaClientes = Prestamo.listaPrestamosIngresados(dpkFecha.Value.ToShortDateString());

            if (listaClientes != null)
            {
                listaClientes.ForEach(cliente => tablaPrestamosIngresados.Rows.Add(new string[] { cliente.getCedula() + " / " + cliente.getNombre() }));

                lblCantidadPrestamosIngresados.Text = listaClientes.Count.ToString();
            }
        }

        private void cargarTablaPrestamosNuevos()
        {
            lblCantidadPrestamosNuevos.Text = "0";
            tablaPrestamosNuevos.Columns.Clear();
            tablaPrestamosNuevos.Rows.Clear();

            tablaPrestamosNuevos.ColumnCount = 1;
            tablaPrestamosNuevos.Columns[0].Name = "PRESTAMOS NUEVOS";

            List<Cliente> listaClientes = Prestamo.listaPrestamosNuevos(dpkFecha.Value.ToShortDateString());

            if (listaClientes != null)
            {
                listaClientes.ForEach(cliente => tablaPrestamosNuevos.Rows.Add(new string[] { cliente.getCedula() + " / " + cliente.getNombre() }));

                lblCantidadPrestamosNuevos.Text = listaClientes.Count.ToString();
            }
        }

        private void cargarTablaClientesNoCuota()
        {
            lblCantidadClientesNoCuota.Text = "0";
            tablaClientesNoCuota.Columns.Clear();
            tablaClientesNoCuota.Rows.Clear();

            tablaClientesNoCuota.ColumnCount = 1;
            tablaClientesNoCuota.Columns[0].Name = "NO DIERON CUOTA";

            List<Cliente> listaClientes = Prestamo.listaClientesNoCuota(dpkFecha.Value.ToShortDateString());

            if (listaClientes != null)
            {
                listaClientes.ForEach(cliente => tablaClientesNoCuota.Rows.Add(new string[] { cliente.getCedula() + " / " + cliente.getNombre() }));

                lblCantidadClientesNoCuota.Text = listaClientes.Count.ToString();
            }
        }

        private void cargarContabilidad()
        {
            if (this.cobroSelecionado())
            {
                if (rdbUnico.Checked)
                {
                    contabilidad = new Contabilidad();
                    contabilidad.setFecha(dtpFechaInicioContabilidad.Value.ToShortDateString());
                    contabilidad.setNombreCobro(cboCobro.Text);
                    contabilidad.cargarContabilidad();

                    txtContabilidadCobro.Text = (contabilidad.getCobro() / 1000).ToString();
                    double interes = contabilidad.getCobro() * 0.2;
                    txtContabilidadCobroCapital.Text = ((contabilidad.getCobro() - interes) / 1000).ToString();
                    txtContabilidadCobroInteres.Text = (interes / 1000).ToString();
                    txtContabilidadPresto.Text = (contabilidad.getPresto() / 1000).ToString();
                    txtContabilidadUtilidad.Text = (contabilidad.getUtilidad() / 1000).ToString();
                }
                else if (rdbVarios.Checked)
                {
                    contabilidad = new Contabilidad();
                    contabilidad.setFecha(dtpFechaInicioContabilidad.Value.ToShortDateString());
                    contabilidad.setFechaFinal(dtpFechaFinalContabilidad.Value.ToShortDateString());
                    contabilidad.setNombreCobro(cboCobro.Text);
                    contabilidad.cargarContabilidadConLimites();

                    txtContabilidadCobro.Text = (contabilidad.getCobro() / 1000).ToString();
                    double interes = contabilidad.getCobro() * 0.2;
                    txtContabilidadCobroCapital.Text = ((contabilidad.getCobro() - interes) / 1000).ToString();
                    txtContabilidadCobroInteres.Text = (interes / 1000).ToString();
                    txtContabilidadPresto.Text = (contabilidad.getPresto() / 1000).ToString();
                    txtContabilidadUtilidad.Text = (contabilidad.getUtilidad() / 1000).ToString();
                }

            }
        }

        private void cargarAbono()
        {
            if (validarFormularioCrearCliente())
            {
                if (Double.Parse(txtCuota.Text) <= prestamoActual.getValorDebe())
                {
                    if (MessageBox.Show("¿Realmente deseas cargar el abono?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Abono.pagarAbono(prestamoActual.getId(), dpkFecha.Value.ToShortDateString(), Double.Parse(txtCuota.Text), cboCobro.Text);
                        prestamoActual.calificarCliente();
                        cargarInformacionActual();
                        buscarCliente();
                    }
                }
                else
                {
                    MessageBox.Show("El valor a abonar es superior\n a lo que debe el cliente.", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cargarTotales()
        {
            if (listaCobros != null)
            {
                if (!String.IsNullOrEmpty(cboCobro.Text))
                {
                    lblTotales.Text = Cartera.agregarTotales(cboCobro.Text.ToUpper());
                }                
            }
        }

        private void cargarTirillaDeCartera()
        {
            if (cobroSelecionado())
            {
                carteraActual = new Cartera();
                carteraActual.setNombreCobro(cboCobro.Text.ToUpper());
                listaCarteras = carteraActual.listarCarteras();

                if (listaCarteras != null)
                {
                    CarteraTirilla carteraTirilla = new CarteraTirilla(listaCarteras);
                    carteraTirilla.ShowDialog();
                }
            }
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
                cargarCobros();
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
        
        private void txtCedula_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                limpiarInformacionActual();
            }
        }
              
        private void txtCedula_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cobroSelecionado() && cedulaValida())
                {
                    buscarCliente();
                    txtNombre.Focus();
                }               
            }
        }

        private void cboCobro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cambioDeCobro();
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (nombreClienteValido())
                {
                    txtPrestamo.Focus();
                }
            }
        }

        private void txtPrestamo_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (prestamoValido())
                {
                    txtDireccion.Focus();
                }
                else
                {
                    txtPlazo.Text = null;
                    txtValor.Text = null;
                    txtCuota.Text = null;
                    txtSaldoCapital.Text = null;
                    txtSaldoIntereses.Text = null;
                    txtCuotaCapital.Text = null;
                    txtCuotaIntereses.Text = null;
                }
            }
            else
            {
                if (prestamoValido())
                {
                    calcularPrestamo();
                }
                else
                {
                    txtPlazo.Text = null;
                    txtValor.Text = null;
                    txtCuota.Text = null;
                    txtSaldoCapital.Text = null;
                    txtSaldoIntereses.Text = null;
                    txtCuotaCapital.Text = null;
                    txtCuotaIntereses.Text = null;
                }
            }
        }

        private void txtDireccion_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (direccionValida() && !dpkFecha.Checked)
                {
                    dpkFecha.Show();
                    dpkFecha.Focus();
                }else if (direccionValida() && dpkFecha.Checked)
                {
                    txtTelefono.Focus();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIrPrimerCliente_Click(object sender, EventArgs e)
        {
            irPrimerCliente();
        }

        private void btnIrUltimoCliente_Click(object sender, EventArgs e)
        {
            irUltimoCliente();
        }

        private void btnIrAnteriorCliente_Click(object sender, EventArgs e)
        {
            irAnteriorCliente();
        }

        private void btnIrSiguienteCliente_Click(object sender, EventArgs e)
        {
            irSiguienteCliente();
        }

        private void btnCrearNuevoCliente_Click(object sender, EventArgs e)
        {
            crearNuevoCliente();
        }

        private void btnAbonar_Click(object sender, EventArgs e)
        {
            cargarAbono();
        }

        private void rdbUnico_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUnico.Checked)
            {
                rdbVarios.Checked = false;
                dtpFechaFinalContabilidad.Enabled = false;
                cargarContabilidad();
            }
        }

        private void rdbVarios_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbVarios.Checked)
            {
                rdbUnico.Checked = false;
                dtpFechaFinalContabilidad.Enabled = true;
                dtpFechaFinalContabilidad.Value = dtpFechaInicioContabilidad.Value.AddDays(1);
                cargarContabilidad();
            }
        }

        private void dtpFechaInicioAbono_ValueChanged(object sender, EventArgs e)
        {
            if (rdbVarios.Checked && dtpFechaInicioContabilidad.Value >= dtpFechaFinalContabilidad.Value)
            {
                dtpFechaFinalContabilidad.Value = dtpFechaInicioContabilidad.Value.AddDays(1);
            }

            cargarContabilidad();
        }

        private void dtpFechaFinalAbono_ValueChanged(object sender, EventArgs e)
        {
            if (rdbVarios.Checked && dtpFechaFinalContabilidad.Value <= dtpFechaInicioContabilidad.Value)
            {
                dtpFechaInicioContabilidad.Value = dtpFechaFinalContabilidad.Value.AddDays(-1);
            }

            cargarContabilidad();
        }

        private void dpkFecha_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaInicioContabilidad.Value = dpkFecha.Value;

            cargarTablaPrestamosCanselados();
            cargarTablaPrestamosIngresados();
            cargarTablaPrestamosNuevos();
            cargarTablaClientesNoCuota();
        }

        private void btnTirilla_Click(object sender, EventArgs e)
        {
            cargarTirillaDeCartera();
        }
    }
}
