using SCreditos.models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SCreditos.usecase.cobro;
using SCreditos.factory;
using SCreditos.views.dialogs;
using SCreditos.usecase;
using SCreditos.usecase.abono;
using SCreditos.usecase.prestamo;
using SCreditos.usecase.contabilidad;
using SCreditos.models.common;
using SCreditos.usecase.gasto;
using SCreditos.usecase.cartera;
using SCreditos.usecase.cliente;
using SCreditos.usecase.domingo;

namespace SCreditos.views
{
    public partial class Principal : Form
    {
        public  String CLIENTE_PRIMERO = "PRIMERO";

        public  String CLIENTE_ANTERIOR = "ANTES";

        public  String CLIENTE_DESPUES = "DESPUES";

        public const String CALIFICACION_BUENO = "BUENO";

        public const String CALIFICACION_REGULAR = "REGULAR";

        public const String CALIFICACION_MALO = "MALO";

        public const String CALIFICACION_CLAVO = "CLAVO";


        // ---------------------------------------------------------------------------------------------------------------------------------
        //  ATRIBUTOS
        // ---------------------------------------------------------------------------------------------------------------------------------
        private Usuario usuario;

        private Cliente clienteActual;

        private Prestamo prestamoActual;

        private Cartera carteraActual;

        private Contabilidad contabilidad;
        
        private List<Cliente> listaClientes;

        private List<Cobro> listaCobros;

        private List<Cartera> listaCarteras;

        private List<Contabilidad> listaContabilidades;

        private Contabilidad contabilidadActual;

        List<Prestamo> listaPrestamosActuales;

        private Cobro cobroActual;


        // ---------------------------------------------------------------------------------------------------------------------------------
        //  CONSTRUCTORES
        // ---------------------------------------------------------------------------------------------------------------------------------
        public Principal(Object usuario)
        {

            InitializeComponent();
            this.usuario = (Usuario)usuario;
            this.Text = "SCREDITOS - " + this.usuario.getNombreCompleto();           
            this.cargarCobros();

            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(btnAgregarOtroGastoContabilidad, "Agregar Gasto Adicional.");


            btnPasarAClavo.Enabled = false;
            btnCancelar.Enabled = false;
            btnCrearNuevoCliente.Enabled = false;
            btnIrPrimerCliente.Enabled = false;
            btnIrSiguienteCliente.Enabled = false;
            btnIrAnteriorCliente.Enabled = false;
            btnIrUltimoCliente.Enabled = false;
            btnNuevoPrestamo.Enabled = false;
            btnAbonar.Enabled = false;
            btnTirilla.Enabled = false;
            btnSave.Enabled = false;
            dpkFecha.Enabled = false;
            cboPrestamos.Enabled = false;
            rdbAntes.Enabled = false;
            rdbDespues.Enabled = false;
            ckbFechaSistema.Enabled = false;
            txtCedula.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            txtPrestamo.Enabled = false;
            txtNombre.Enabled = false;
        }


        // ---------------------------------------------------------------------------------------------------------------------------------
        //  METODOS
        // ---------------------------------------------------------------------------------------------------------------------------------
        private void cargarCobros()
        {
            listaCobros = CargarCobrosUseCase.cargarCobros();

            if (!ListValidators.validarListaVaciaONula(listaCobros))
            {
                cboCobro.Items.Clear();
                foreach (Cobro cobro in listaCobros)
                {
                    cboCobro.Items.Add(cobro.getNombre());
                }
            }
        }

        private void cargarPanelPrestamo(Prestamo pPrestamo)
        {
            txtBoleta.Text = pPrestamo.getId().ToString();
            txtSaldoCapital.Text = ((long)pPrestamo.getPrestamo()).ToString();
            txtSaldoIntereses.Text = ((long)(pPrestamo.getValor() - pPrestamo.getPrestamo())).ToString();
            txtCuotaCapital.Text = ((long)pPrestamo.getCuotaCapital()).ToString();
            txtCuotaIntereses.Text = ((long)pPrestamo.getCuotaInteres()).ToString();
        }

        private void limpiarPanelPrestamo()
        {
            txtBoleta.Clear();
            txtSaldoCapital.Clear();
            txtSaldoIntereses.Clear();
            txtCuotaCapital.Clear();
            txtCuotaIntereses.Clear();
        }

        private void cargarPanelCliente(Cliente pCliente, Prestamo pPrestamo, List<Prestamo> pListaPrestamos, Boolean pDesdeCero)
        {
            txtCedula.Text = pCliente.getCedula();
            txtNombre.Text = pCliente.getNombre();
            txtDireccion.Text = pCliente.getDireccion();
            txtTelefono.Text = pCliente.getTelefono();
            lblNumeroDePrestamos.Text = "Prestamo: 1 / " + pListaPrestamos.Count;

            if (pDesdeCero)
            {
                cboPrestamos.Items.Clear();
                foreach (Prestamo prestamo in pListaPrestamos)
                {
                    cboPrestamos.Items.Add(prestamo.getId());
                }
                cboPrestamos.SelectedIndex = 0;

                // seleccion del nuevo prestamo.
            }  

            txtPrestamo.Text = pPrestamo.getPrestamo().ToString();
            txtPlazo.Text = pPrestamo.getPlazo().ToString();
            txtValor.Text = pPrestamo.getValor().ToString();
            txtCuota.Text = pPrestamo.getCuota().ToString();
        }

        private void limpiarPanelCliente()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            lblNumeroDePrestamos.Text = "Prestamo: 0 / 0";
            cboPrestamos.Items.Clear();
            txtPrestamo.Clear();
            txtPlazo.Clear();
            txtValor.Clear();
            txtCuota.Clear();
        }

        // ANALIZARLO
        private void cargarPanelDescripcion(Prestamo pPrestamo)
        {
            limpiarPanelDescripcion();

            tablaDescripcion.ColumnCount = 4;
            tablaDescripcion.Columns[0].Name = "FECHA -> ABONO";
            tablaDescripcion.Columns[1].Name = "ABONO";
            tablaDescripcion.Columns[2].Name = "RESTA";
            tablaDescripcion.Columns[3].Name = "TIPO";

            if (!ObjectUtils.isNull(pPrestamo.getDomingo()))
            {
                tablaDescripcion.Rows.Add(new string[] { pPrestamo.getFechaInicio().ToShortDateString(), pPrestamo.getDomingo().getValorPago().ToString(), pPrestamo.getDomingo().getValorRestante().ToString(), "DOMINGOS" });
            }

            if (!ListValidators.validarListaVaciaONula(pPrestamo.getAbonos()))
            {
                pPrestamo.getAbonos().ForEach(abono => tablaDescripcion.Rows.Add(new string[] { abono.getFecha().ToShortDateString(), abono.getValor().ToString(), abono.getRestante().ToString(), abono.getTipoAbono()}));
            }
        }

        private void limpiarPanelDescripcion()
        {
            tablaDescripcion.Columns.Clear();
            tablaDescripcion.Rows.Clear();
        }

        private void cargarPanelTablas(Cobro pCobro)
        {
            limpiarPanelTablas();
            cargarContabilidadoByFecha();

            tablaPrestamosCancelados.ColumnCount = 1;
            tablaPrestamosCancelados.Columns[0].Name = "TARJETAS CANCELADAS";
            int tc = 0;
            if (!CampoFactory.isNull(dpkFecha.Value.ToShortDateString()))
            {
                if (!ListValidators.validarListaVaciaONula(pCobro.getClientes()))
                { 
                    pCobro.getClientes().ForEach(cliente =>
                    {
                        cliente.getPrestamos().ForEach(prestamo =>
                        {
                            if (!CampoFactory.isNull(prestamo.getFechaPago().ToShortDateString()))
                            {
                                if (prestamo.getFechaPago().ToShortDateString().Equals(dpkFecha.Value.ToShortDateString()))
                                {
                                    tc++;
                                    tablaPrestamosCancelados.Rows.Add(new string[] { "CC:" + cliente.getCedula() + " Nom:" + cliente.getNombre().Substring(0, 5) + " N°Pre:" + prestamo.getId().ToString() + " Val_pag:" + prestamo.getValorPago().ToString() });
                                    lblCantidadPrestamosCancelados.Text = tc.ToString();
                                }
                            }
                        });
                    });
                }                
            }
                       
            tablaPrestamosIngresados.ColumnCount = 1;
            tablaPrestamosIngresados.Columns[0].Name = "PRESTAMOS INGRESADOS";
            int pi = 0;
            if (!CampoFactory.isNull(dpkFecha.Value.ToShortDateString()))
            {
                if (!ListValidators.validarListaVaciaONula(pCobro.getClientes()))
                {
                    pCobro.getClientes().ForEach(cliente =>
                    {
                        cliente.getPrestamos().ForEach(prestamo =>
                        {
                            if (!ListValidators.validarListaVaciaONula(prestamo.getAbonos()))
                            {
                                prestamo.getAbonos().ForEach(abono =>
                                {
                                    if (abono.getFecha().ToShortDateString().Equals(dpkFecha.Value.ToShortDateString()) && abono.getValor() > 0)
                                    {
                                        pi++;
                                        tablaPrestamosIngresados.Rows.Add(new string[] { "CC:" + cliente.getCedula() + " Nom:" + cliente.getNombre().Substring(0, 5) + " N°Pre:" + prestamo.getId().ToString() + " Val_abo:" + abono.getValor().ToString() });
                                        lblCantidadPrestamosIngresados.Text = pi.ToString();
                                    }
                                });
                            }                            
                        });
                    });
                }
            }

            tablaPrestamosNuevos.ColumnCount = 1;
            tablaPrestamosNuevos.Columns[0].Name = "PRESTAMOS NUEVOS";
            int pn = 0;
            if (!CampoFactory.isNull(dpkFecha.Value.ToShortDateString()))
            {
                if (!ListValidators.validarListaVaciaONula(pCobro.getClientes()))
                {
                    pCobro.getClientes().ForEach(cliente =>
                {
                    cliente.getPrestamos().ForEach(prestamo =>
                    {
                        if (prestamo.getFechaInicio().ToShortDateString().Equals(dpkFecha.Value.ToShortDateString()))
                        {
                            pn++;
                            tablaPrestamosNuevos.Rows.Add(new string[] { "CC:" + cliente.getCedula() + " Nom:" + cliente.getNombre().Substring(0, 5) + " N°Pre:" + prestamo.getId().ToString() + " Val_pre:" + prestamo.getValor().ToString() });
                            lblCantidadPrestamosNuevos.Text = pn.ToString();
                        }
                    });
                });
                }
            }

            tablaClientesNoCuota.ColumnCount = 1;
            tablaClientesNoCuota.Columns[0].Name = "NO DIERON CUOTA";
            int cnc = 0;
            if (!CampoFactory.isNull(dpkFecha.Value.ToShortDateString()))
            {
                if (!ListValidators.validarListaVaciaONula(pCobro.getClientes()))
                {
                    pCobro.getClientes().ForEach(cliente =>
                {
                    cliente.getPrestamos().ForEach(prestamo =>
                    {
                        if (!ListValidators.validarListaVaciaONula(prestamo.getAbonos()))
                        {
                            prestamo.getAbonos().ForEach(abono =>
                            {
                                if (abono.getFecha().ToShortDateString().Equals(dpkFecha.Value.ToShortDateString()) && abono.getValor() <= 0)
                                {
                                    cnc++;
                                    tablaClientesNoCuota.Rows.Add(new string[] { "CC:" + cliente.getCedula() + " Nom:" + cliente.getNombre().Substring(0, 5) + " N°Pre:" + prestamo.getId().ToString() });
                                    lblCantidadClientesNoCuota.Text = cnc.ToString();
                                }
                            });
                        }
                    });
                });
                }
            }
        }

        private void limpiarPanelTablas()
        {
            lblCantidadPrestamosCancelados.Text = "0";
            tablaPrestamosCancelados.Columns.Clear();
            tablaPrestamosCancelados.Rows.Clear();

            lblCantidadPrestamosIngresados.Text = "0";
            tablaPrestamosIngresados.Columns.Clear();
            tablaPrestamosIngresados.Rows.Clear();

            lblCantidadPrestamosNuevos.Text = "0";
            tablaPrestamosNuevos.Columns.Clear();
            tablaPrestamosNuevos.Rows.Clear();

            lblCantidadClientesNoCuota.Text = "0";
            tablaClientesNoCuota.Columns.Clear();
            tablaClientesNoCuota.Rows.Clear();
        }

        private void cargarPanelCalificacion(Cliente pCliente, int pTotalClientes, Prestamo prestamo)
        {
            lblTarjetas.Text = pCliente.getRuta() + "/" + pTotalClientes;

            switch (prestamo.getCalificacion())
            {
                case CALIFICACION_BUENO:
                    lblCalificacion.BackColor = System.Drawing.Color.Green;
                    lblCalificacion.Text = CALIFICACION_BUENO;
                    break;

                case CALIFICACION_REGULAR:
                    lblCalificacion.BackColor = System.Drawing.Color.Yellow;
                    lblCalificacion.Text = CALIFICACION_REGULAR;
                    break;

                case CALIFICACION_MALO:
                    lblCalificacion.BackColor = System.Drawing.Color.Orange;
                    lblCalificacion.Text = CALIFICACION_MALO;
                    break;

                case CALIFICACION_CLAVO:
                    lblCalificacion.BackColor = System.Drawing.Color.Red;
                    lblCalificacion.Text = CALIFICACION_CLAVO;
                    break;
            }

            panel2.Refresh();
        }

        private void limpiarPanelCalificacion()
        {
            lblTarjetas.Text = "0 / 0";
            lblCalificacion.BackColor = System.Drawing.Color.Empty;
            lblCalificacion.Text = null;
        }

        private void cambioDeCobro()
        {
            String cobro = cboCobro.Text.ToUpper().Trim();

            if (!CampoFactory.isNull(cobro))
            {
                btnCrearNuevoCliente.Enabled = true;
                rdbAntes.Enabled = true;
                rdbDespues.Enabled = true;
                ckbFechaSistema.Enabled = true;
                txtCedula.Enabled = true;
                txtTelefono.Enabled = true;
                txtDireccion.Enabled = true;
                txtPrestamo.Enabled = true;
                txtNombre.Enabled = true;
                btnTirilla.Enabled = true;
                btnSave.Enabled = true;

                limpiarPanelCalificacion();
                limpiarPanelCliente();
                limpiarPanelDescripcion();
                limpiarPanelPrestamo();
                limpiarPanelTablas();

                cobroActual = listaCobros.Find(c => cobro.Equals(c.getNombre()));
                cargarPanelTablas(cobroActual);
                cargarContabilidadoByFecha();

                if (!ListValidators.validarListaVaciaONula(cobroActual.getClientes()))
                {
                    if (cobroActual.getClientes().Count > 1)
                    {
                        btnIrPrimerCliente.Enabled = true;
                        btnIrSiguienteCliente.Enabled = true;
                        btnIrAnteriorCliente.Enabled = true;
                        btnIrUltimoCliente.Enabled = true;
                    }
                    else
                    {
                        btnIrPrimerCliente.Enabled = false;
                        btnIrSiguienteCliente.Enabled = false;
                        btnIrAnteriorCliente.Enabled = false;
                        btnIrUltimoCliente.Enabled = false;
                    }

                    btnPasarAClavo.Enabled = true;
                    btnAbonar.Enabled = true;
                    btnCancelar.Enabled = true;
                    cboPrestamos.Enabled = true;
                    btnNuevoPrestamo.Enabled = true;

                    clienteActual = cobroActual.getClientes().Find(c => c.getRuta() == 1);

                    listaPrestamosActuales = clienteActual.getPrestamos();
                    prestamoActual = listaPrestamosActuales[0];

                    cargarPanelCliente(clienteActual, prestamoActual, listaPrestamosActuales, true);
                    cargarPanelPrestamo(prestamoActual);
                    cargarPanelDescripcion(prestamoActual);
                    cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
                }
                else
                {
                    btnPasarAClavo.Enabled = false;
                    btnCancelar.Enabled = false;                    
                    btnIrPrimerCliente.Enabled = false;
                    btnIrSiguienteCliente.Enabled = false;
                    btnIrAnteriorCliente.Enabled = false;
                    btnIrUltimoCliente.Enabled = false;
                    btnNuevoPrestamo.Enabled = false;
                    btnAbonar.Enabled = false;
                    dpkFecha.Enabled = false;
                    cboPrestamos.Enabled = false;
                }
            }
            else
            {
                btnCrearNuevoCliente.Enabled = false;
                rdbAntes.Enabled = false;
                rdbDespues.Enabled = false;
                ckbFechaSistema.Enabled = false;
                txtCedula.Enabled = false;
                txtTelefono.Enabled = false;
                txtDireccion.Enabled = false;
                txtPrestamo.Enabled = false;
                txtNombre.Enabled = false;
            }
        }

        private void irUltimoCliente()
        {
            if (!ListValidators.validarListaVaciaONula(cobroActual.getClientes()))
            {
                clienteActual = cobroActual.getClientes().Find(cliente => cliente.getRuta() == cobroActual.getClientes().Count);
                listaPrestamosActuales = clienteActual.getPrestamos();
                prestamoActual = listaPrestamosActuales[0];

                cargarPanelCliente(clienteActual, prestamoActual, listaPrestamosActuales, true);
                cargarPanelPrestamo(prestamoActual);
                cargarPanelDescripcion(prestamoActual);
                cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
            }
        }

        private void irPrimerCliente()
        {
            if (!ListValidators.validarListaVaciaONula(cobroActual.getClientes()))
            {
                clienteActual = cobroActual.getClientes().Find(cliente => cliente.getRuta() == 1);
                listaPrestamosActuales = clienteActual.getPrestamos();
                prestamoActual = listaPrestamosActuales[0];

                cargarPanelCliente(clienteActual, prestamoActual, listaPrestamosActuales, true);
                cargarPanelPrestamo(prestamoActual);
                cargarPanelDescripcion(prestamoActual);
                cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
            }
        }

        private void irAnteriorCliente()
        {
            if (!ListValidators.validarListaVaciaONula(cobroActual.getClientes()))
            {
                clienteActual = cobroActual.getClientes().Find(cliente => {
                    if(clienteActual.getRuta() == 1)
                    {
                        return cliente.getRuta() == cobroActual.getClientes().Count;
                    }
                    else
                    {
                        return cliente.getRuta() == clienteActual.getRuta() - 1;
                    }
                });
                listaPrestamosActuales = clienteActual.getPrestamos();
                prestamoActual = listaPrestamosActuales[0];

                cargarPanelCliente(clienteActual, prestamoActual, listaPrestamosActuales, true);
                cargarPanelPrestamo(prestamoActual);
                cargarPanelDescripcion(prestamoActual);
                cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
            }
        }

        private void irSiguienteCliente()
        {
            if (!ListValidators.validarListaVaciaONula(cobroActual.getClientes()))
            {
                clienteActual = cobroActual.getClientes().Find(cliente => {
                    if (clienteActual.getRuta() == cobroActual.getClientes().Count)
                    {
                        return cliente.getRuta() == 1;
                    }
                    else
                    {
                        return cliente.getRuta() == clienteActual.getRuta() + 1;
                    }
                });
                listaPrestamosActuales = clienteActual.getPrestamos();
                prestamoActual = listaPrestamosActuales[0];

                cargarPanelCliente(clienteActual, prestamoActual, listaPrestamosActuales, true);
                cargarPanelPrestamo(prestamoActual);
                cargarPanelDescripcion(prestamoActual);
                cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
            }
        }

        private void cambioDePrestamo()
        {
            if (!ListValidators.validarListaVaciaONula(listaPrestamosActuales))
            {
                prestamoActual = prestamoActual = listaPrestamosActuales.Find(x => x.getId() == Convert.ToInt32(cboPrestamos.Text));
                cargarPanelPrestamo(prestamoActual);
                cargarPanelDescripcion(prestamoActual);
                cargarPanelCliente(clienteActual, prestamoActual, listaPrestamosActuales, false);
                cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
            }
        }

        private void crearNuevoCobro()
        {
            CrearNuevoCobro crearNuevoCobro = new CrearNuevoCobro(listaCobros);
            crearNuevoCobro.ShowDialog();

            if (crearNuevoCobro.getSeCreo())
            {
                btnPasarAClavo.Enabled = false;
                btnCancelar.Enabled = false;
                btnCrearNuevoCliente.Enabled = false;
                btnIrPrimerCliente.Enabled = false;
                btnIrSiguienteCliente.Enabled = false;
                btnIrAnteriorCliente.Enabled = false;
                btnIrUltimoCliente.Enabled = false;
                btnNuevoPrestamo.Enabled = false;
                btnAbonar.Enabled = false;
                btnTirilla.Enabled = false;
                btnSave.Enabled = false;
                dpkFecha.Enabled = false;
                cboPrestamos.Enabled = false;
                rdbAntes.Enabled = false;
                rdbDespues.Enabled = false;
                ckbFechaSistema.Enabled = false;
                txtCedula.Enabled = false;
                txtTelefono.Enabled = false;
                txtDireccion.Enabled = false;
                txtPrestamo.Enabled = false;
                txtNombre.Enabled = false;

                listaCobros.Add(crearNuevoCobro.getCobro() as Cobro);

                cobroActual = listaCobros.Find(c => c.getNombre().Equals((crearNuevoCobro.getCobro() as Cobro).getNombre()));
                
                limpiarPanelTablas();
                limpiarPanelPrestamo();
                limpiarPanelDescripcion();
                limpiarPanelCliente();
                limpiarPanelCalificacion();

                cboCobro.Items.Clear();
                int n = 0;
                int indice = 0;
                foreach (Cobro cobro in listaCobros)
                {
                    n++;
                    if (cobro.getNombre().Equals(cobroActual.getNombre()))
                    {
                        indice = n;
                    }
                    cboCobro.Items.Add(cobro.getNombre());
                }
                cboCobro.SelectedIndex = indice - 1;

                btnCrearNuevoCliente.Enabled = true;
                rdbAntes.Enabled = true;
                rdbDespues.Enabled = true;
                ckbFechaSistema.Enabled = true;
                txtCedula.Enabled = true;
                txtTelefono.Enabled = true;
                txtDireccion.Enabled = true;
                txtPrestamo.Enabled = true;
                txtNombre.Enabled = true;
            }
        }

        private void crearNuevoCliente()
        {
            if (formularioCrearNuevoClienteValido())
            {
                if (!ListValidators.validarListaVaciaONula(cobroActual.getClientes()))
                {
                    if (!cobroActual.getClientes().Exists(cliente => cliente.getCedula().Equals(txtCedula.Text)))
                    {
                        Cliente nuevoCliente = new Cliente();
                        nuevoCliente.setCedula(txtCedula.Text.Trim().ToUpper());
                        nuevoCliente.setNombre(txtNombre.Text.Trim().ToUpper());
                        nuevoCliente.setCobro(cboCobro.Text.Trim().ToUpper());
                        nuevoCliente.setDireccion(txtDireccion.Text.Trim().ToUpper());
                        nuevoCliente.setTelefono(txtTelefono.Text.Trim().ToUpper());

                        Prestamo nuevoPrestamo = new Prestamo(nuevoCliente.getCedula(), Double.Parse(txtPrestamo.Text));
                        nuevoPrestamo.setFechaInicio(new DateTime(dpkFecha.Value.Year, dpkFecha.Value.Month, dpkFecha.Value.Day));

                        CargarDomingos vCargarDomingos = new CargarDomingos(nuevoPrestamo.getValor());
                        vCargarDomingos.ShowDialog();

                        nuevoPrestamo.setDomingo(new Domingo(0, 0, vCargarDomingos.getDomingos(), vCargarDomingos.getValorAbono(), vCargarDomingos.getValorPorDomingo(), nuevoPrestamo.getValor() - vCargarDomingos.getValorAbono()));

                        List<Prestamo> nuevosPrestamos = new List<Prestamo>();

                        nuevosPrestamos.Add(nuevoPrestamo);

                        nuevoCliente.setPrestamos(nuevosPrestamos);

                        String enRuta;

                        if (rdbAntes.Checked)
                        {
                            enRuta = this.CLIENTE_ANTERIOR;
                        }
                        else
                        {
                            enRuta = this.CLIENTE_DESPUES;
                        }

                        if (MessageBox.Show("Deseas crear el cliente:" +
                        "\n\nCEDULA:       " + nuevoCliente.getCedula() + "" +
                        "\nNOMBRE:       " + nuevoCliente.getNombre() + "" +
                        "\nDIRECCIÓN:    " + nuevoCliente.getDireccion() + "" +
                        "\nTELÉFONO:     " + nuevoCliente.getTelefono() + "" +
                        "\n\nPRESTAMO" +
                        "\nVALOR:        " + nuevoPrestamo.getPrestamo() + "" +
                        "\nINTERES:      " + nuevoPrestamo.getInteres() + "" +
                        "\nTOTAL:        " + nuevoPrestamo.getValor() + "" +
                        "\nFECHA INICIO: " + nuevoPrestamo.getFechaInicio().ToShortDateString() + "" +
                        "\n\nRUTA        " +
                        "\n" + enRuta + " DE: " + clienteActual.getNombre(), "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (!ListValidators.validarListaVaciaONula(cobroActual.getClientes()))
                            {
                                if (rdbAntes.Checked)
                                {
                                    cobroActual = CrearNuevoClienteUseCase.crearCliente(this.CLIENTE_ANTERIOR, clienteActual.getRuta(), nuevoCliente);
                                }
                                else
                                {
                                    cobroActual = CrearNuevoClienteUseCase.crearCliente(this.CLIENTE_DESPUES, clienteActual.getRuta(), nuevoCliente);
                                }
                            }
                            else
                            {
                                cobroActual = CrearNuevoClienteUseCase.crearCliente(this.CLIENTE_PRIMERO, clienteActual.getRuta(), nuevoCliente);
                            }

                            listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;

                            clienteActual = cobroActual.getClientes().Find(cli => cli.getCedula().Equals(nuevoCliente.getCedula()));
                            prestamoActual = clienteActual.getPrestamos()[0];

                            cargarPanelCliente(clienteActual, prestamoActual, clienteActual.getPrestamos(), true);
                            cargarPanelDescripcion(prestamoActual);
                            cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
                            cargarPanelPrestamo(prestamoActual);
                            cargarPanelTablas(cobroActual);

                            MessageBox.Show("El cliente se creo con exito.");

                            if (cobroActual.getClientes().Count > 1)
                            {
                                btnIrPrimerCliente.Enabled = true;
                                btnIrSiguienteCliente.Enabled = true;
                                btnIrAnteriorCliente.Enabled = true;
                                btnIrUltimoCliente.Enabled = true;
                            }
                            else
                            {
                                btnIrPrimerCliente.Enabled = false;
                                btnIrSiguienteCliente.Enabled = false;
                                btnIrAnteriorCliente.Enabled = false;
                                btnIrUltimoCliente.Enabled = false;
                            }

                            btnPasarAClavo.Enabled = true;
                            btnAbonar.Enabled = true;
                            btnCancelar.Enabled = true;
                            cboPrestamos.Enabled = true;
                            btnNuevoPrestamo.Enabled = true;
                        }
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

                    Prestamo nuevoPrestamo = new Prestamo(nuevoCliente.getCedula(), Double.Parse(txtPrestamo.Text));
                    nuevoPrestamo.setFechaInicio(new DateTime(dpkFecha.Value.Year, dpkFecha.Value.Month, dpkFecha.Value.Day));

                    CargarDomingos vCargarDomingos = new CargarDomingos(nuevoPrestamo.getValor());
                    vCargarDomingos.ShowDialog();

                    nuevoPrestamo.setDomingo(new Domingo(0, 0, vCargarDomingos.getDomingos(), vCargarDomingos.getValorAbono(), vCargarDomingos.getValorPorDomingo(), nuevoPrestamo.getValor() - vCargarDomingos.getValorAbono()));

                    List<Prestamo> nuevosPrestamos = new List<Prestamo>();

                    nuevosPrestamos.Add(nuevoPrestamo);

                    nuevoCliente.setPrestamos(nuevosPrestamos);

                    if (MessageBox.Show("Deseas crear el cliente:" +
                        "\n\nCEDULA:       " + nuevoCliente.getCedula() + "" +
                        "\nNOMBRE:       " + nuevoCliente.getNombre() + "" +
                        "\nDIRECCIÓN:    " + nuevoCliente.getDireccion() + "" +
                        "\nTELÉFONO:     " + nuevoCliente.getTelefono() + "" +
                        "\n\nPRESTAMO" +
                        "\nVALOR:        " + nuevoPrestamo.getPrestamo() + "" +
                        "\nINTERES:      " + nuevoPrestamo.getInteres() + "" +
                        "\nTOTAL:        " + nuevoPrestamo.getValor() + "" +
                        "\nFECHA INICIO: " + nuevoPrestamo.getFechaInicio().ToShortDateString(), "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cobroActual = CrearNuevoClienteUseCase.crearCliente(this.CLIENTE_PRIMERO, 0, nuevoCliente);

                        listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;

                        clienteActual = cobroActual.getClientes().Find(cli => cli.getCedula().Equals(nuevoCliente.getCedula()));
                        prestamoActual = clienteActual.getPrestamos()[0];

                        cargarPanelCliente(clienteActual, prestamoActual, clienteActual.getPrestamos(), true);
                        cargarPanelDescripcion(prestamoActual);
                        cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
                        cargarPanelPrestamo(prestamoActual);
                        cargarPanelTablas(cobroActual);

                        MessageBox.Show("El cliente se creo con exito.");

                        if (cobroActual.getClientes().Count > 1)
                        {
                            btnIrPrimerCliente.Enabled = true;
                            btnIrSiguienteCliente.Enabled = true;
                            btnIrAnteriorCliente.Enabled = true;
                            btnIrUltimoCliente.Enabled = true;
                        }
                        else
                        {
                            btnIrPrimerCliente.Enabled = false;
                            btnIrSiguienteCliente.Enabled = false;
                            btnIrAnteriorCliente.Enabled = false;
                            btnIrUltimoCliente.Enabled = false;
                        }

                        btnPasarAClavo.Enabled = true;
                        btnAbonar.Enabled = true;
                        btnCancelar.Enabled = true;
                        cboPrestamos.Enabled = true;
                        btnNuevoPrestamo.Enabled = true;
                    }
                }                
            }            
        }

        private Boolean formularioCrearNuevoClienteValido()
        {
            Boolean valido = true;

            if (CampoFactory.isNull(cboCobro.Text.Trim()))
            {
                valido = false;
                this.errorCobro.SetError(this.cboCobro, "Debeas seleccionar o crear un cobro.");
            }
            else
            {
                this.errorCobro.Dispose();
            }

            if (CampoFactory.isNull(txtCedula.Text.Trim()))
            {
                valido = false;
                this.errorCedula.SetError(this.txtCedula, "Debes ingresar un valor.");
            }
            else
            {
                this.errorCedula.Dispose();
            }

            if (CampoFactory.isNull(txtNombre.Text.Trim()))
            {
                valido = false;
                this.errorNombreCliente.SetError(this.txtNombre, "Debes ingresar un valor.");
            }
            else
            {
                this.errorNombreCliente.Dispose();
            }

            if (CampoFactory.isNull(txtDireccion.Text.Trim()))
            {
                valido = false;
                this.errorDireccion.SetError(this.txtDireccion, "Debes ingresar un valor.");
            }
            else
            {
                this.errorDireccion.Dispose();
            }

            if (CampoFactory.isNull(txtPrestamo.Text.Trim()))
            {
                valido = false;
                this.errorPrestamo.SetError(this.txtPrestamo, "Debes ingresar un valor.");
            }
            else
            {
                this.errorPrestamo.Dispose();
            }

            if (CampoFactory.isNull(txtTelefono.Text.Trim()))
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

        private void cargarPagoAbono()
        {
            if (formularioCrearNuevoClienteValido())
            {
                if (!prestamoActual.getEstado().Equals(TipoEstados.PAGO))
                {
                    CargarPagoAbono cargarPagoAbono = new CargarPagoAbono(clienteActual, prestamoActual);
                    cargarPagoAbono.ShowDialog();

                    if (cargarPagoAbono.sePago())
                    {
                        cobroActual = CargarPagoAbonoUseCase.pagarAbono(clienteActual, cargarPagoAbono.getAbono() as Abono, prestamoActual);
                        listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;

                        clienteActual = cobroActual.getClientes().Find(cli => cli.getCedula().Equals(clienteActual.getCedula()));

                        listaPrestamosActuales = clienteActual.getPrestamos();
                        prestamoActual = listaPrestamosActuales.Find(p => p.getId() == prestamoActual.getId());

                        cargarPanelDescripcion(prestamoActual);
                        cargarPanelTablas(cobroActual);
                        cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);

                        MessageBox.Show("El abono se cargo con exito.");
                    }
                }
                else
                {
                    MessageBox.Show("El prestamo ya esta cancelado.");
                }
            }
        }

        private void cancelarPrestamo()
        {
            if (formularioCrearNuevoClienteValido())
            {
                if (prestamoActual.getValorDebe() > 0)
                {
                    if (MessageBox.Show("¿Realmente deseas cancelar la totalidad del prestamo: " + prestamoActual.getValorDebe() + "?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("¿Realmentes lo deseas?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cobroActual = CancelarTotalidadPrestamoUseCase.cancelarTotalidadPrestamo(cobroActual, new DateTime(dpkFecha.Value.Year, dpkFecha.Value.Month, dpkFecha.Value.Day), prestamoActual);
                            listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;
                            clienteActual = cobroActual.getClientes().Find(cli => cli.getCedula().Equals(clienteActual.getCedula()));
                            listaPrestamosActuales = clienteActual.getPrestamos();
                            prestamoActual = clienteActual.getPrestamos().Find(p => p.getId() == prestamoActual.getId());

                            cargarPanelDescripcion(prestamoActual);
                            cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
                            cargarPanelTablas(cobroActual);

                            MessageBox.Show("El prestamo se cancelo con exito.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El prestamo ya esta cancelado.");
                }

                
            }
        }

        private void crearNuevoPrestamo()
        {
            if (formularioCrearNuevoClienteValido())
            {
                Prestamo nuevoPrestamo = new Prestamo(clienteActual.getCedula(), Double.Parse(txtPrestamo.Text));
                nuevoPrestamo.setFechaInicio(new DateTime(dpkFecha.Value.Year, dpkFecha.Value.Month, dpkFecha.Value.Day));

                if (MessageBox.Show("Deseas crear el nuevo prestamo para el cliente:" +
                    "\n\nCEDULA:       " + clienteActual.getCedula() + "" +
                    "\nNOMBRE:       " + clienteActual.getNombre() + "" +
                    "\nDIRECCIÓN:    " + clienteActual.getDireccion() + "" +
                    "\nTELÉFONO:     " + clienteActual.getTelefono() + "" +
                    "\n\nPRESTAMO" +
                    "\nVALOR:        " + nuevoPrestamo.getPrestamo() + "" +
                    "\nINTERES:      " + nuevoPrestamo.getInteres() + "" +
                    "\nTOTAL:        " + nuevoPrestamo.getValor() + "" +
                    "\nFECHA INICIO: " + nuevoPrestamo.getFechaInicio().ToShortDateString(), "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CargarDomingos vCargarDomingos = new CargarDomingos(nuevoPrestamo.getValor());
                    vCargarDomingos.ShowDialog();

                    nuevoPrestamo.setDomingo(new Domingo(0, 0, vCargarDomingos.getDomingos(), vCargarDomingos.getValorAbono(), vCargarDomingos.getValorPorDomingo(), nuevoPrestamo.getValor() - vCargarDomingos.getValorAbono()));

                    cobroActual = CrearNuevoPrestamoUseCase.crearNuevoPrestamo(cobroActual, nuevoPrestamo);
                    listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;
                    clienteActual = cobroActual.getClientes().Find(cli => cli.getCedula().Equals(clienteActual.getCedula()));
                    listaPrestamosActuales = clienteActual.getPrestamos();
                    prestamoActual = clienteActual.getPrestamos().Find(p => p.getId() == prestamoActual.getId());

                    cargarPanelCliente(clienteActual, prestamoActual, clienteActual.getPrestamos(), true);
                    cargarPanelDescripcion(prestamoActual);
                    cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
                    cargarPanelPrestamo(prestamoActual);
                    cargarPanelTablas(cobroActual);

                    MessageBox.Show("El prestamo se creo con exito.");

                    //if (cobroActual.getClientes().Count > 1)
                    //{
                    //    btnIrPrimerCliente.Enabled = true;
                    //    btnIrSiguienteCliente.Enabled = true;
                    //    btnIrAnteriorCliente.Enabled = true;
                    //    btnIrUltimoCliente.Enabled = true;
                    //}
                    //else
                    //{
                    //    btnIrPrimerCliente.Enabled = false;
                    //    btnIrSiguienteCliente.Enabled = false;
                    //    btnIrAnteriorCliente.Enabled = false;
                    //    btnIrUltimoCliente.Enabled = false;
                    //}

                    //btnPasarAClavo.Enabled = true;
                    //btnAbonar.Enabled = true;
                    //btnCancelar.Enabled = true;
                    //cboPrestamos.Enabled = true;
                    //btnNuevoPrestamo.Enabled = true;
                }




                    //if (nuevoPrestamo.crearNuevoPrestamo(cboCobro.Text))
                    //{
                    //    cargarPrestamosActuales();
                    //    cargarListaClientes();
                    //    cargarInformacionActual();
                    //    // Cargar domingos
                    //    cargarPagoDomingos();
                    //    cargarInformacionActual();
                    //}

                }
            }

        private void cargarContabilidad()
        {
            listaContabilidades = CargarContabilidadesUseCase.cargarContabilidades(cobroActual);
        }

        private void cargarContabilidadoByFecha()
        {
            if (!ObjectUtils.isNull(cobroActual))
            {
                if (!CampoFactory.isNull(dpkFecha.Value.ToShortDateString()))
                {
                    limpiarPanelContabilidad();
                    cargarContabilidad();
                    contabilidadActual = null;

                    if (!ListValidators.validarListaVaciaONula(listaContabilidades))
                    {
                        contabilidadActual = listaContabilidades.Find(c => c.getFecha().ToShortDateString().Equals(dpkFecha.Value.ToShortDateString()));
                    } 

                    if (!ObjectUtils.isNull(contabilidadActual))
                    {
                        txtContabilidadCobro.Text = (contabilidadActual.getCobro() / 1000).ToString();
                        double interes = contabilidadActual.getCobro() * 0.2;
                        txtContabilidadCobroCapital.Text = ((contabilidadActual.getCobro() - interes) / 1000).ToString();
                        txtContabilidadCobroInteres.Text = (interes / 1000).ToString();
                        txtContabilidadPresto.Text = (contabilidadActual.getPresto() / 1000).ToString();
                        txtContabilidadUtilidad.Text = (contabilidadActual.getUtilidad() / 1000).ToString();
                        txtContabilidadGastos.Text = (contabilidadActual.getGastos() / 1000).ToString();
                        txtContabilidadOtrosGastos.Text = (contabilidadActual.getOtrosGastos() / 1000).ToString();
                    }
                }
            }
        }

        private void limpiarPanelContabilidad()
        {
            txtContabilidadCobro.Text = "0";
            txtContabilidadCobroCapital.Text = "0";
            txtContabilidadCobroInteres.Text = "0";
            txtContabilidadPresto.Text = "0";
            txtContabilidadUtilidad.Text = "0";
        }

        private void crearNuevoGastoDiario()
        {
            if (!ObjectUtils.isNull(cobroActual))
            {

                String pFecha = dpkFecha.Value.ToShortDateString();
                String pCobro = cobroActual.getNombre();

                AgregarGastoDiario agregarGastoDiario = new AgregarGastoDiario(pFecha, pCobro);
                agregarGastoDiario.ShowDialog();

                if (!ObjectUtils.isNull(agregarGastoDiario.getValor()))
                {
                    Gasto gasto = new Gasto(agregarGastoDiario.getCobro(), agregarGastoDiario.getNombre(), agregarGastoDiario.getDescripcion(), agregarGastoDiario.getFecha(), agregarGastoDiario.getValor());

                    GuardarGastoDiarioUseCase.guardarGasto(gasto);
                }
            }
            else
            {
                MessageBox.Show("Debes selecionar primero un cobro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void agregarOtroGastoContabilidad()
        {
            if (!ObjectUtils.isNull(cobroActual))
            {
                if (!ObjectUtils.isNull(contabilidadActual))
                {
                    if (contabilidadActual.getEstado().Equals(TipoEstados.NO_GUARDADO))
                    {
                        AgregarGastoContabilidad agregarGastoContabilidad = new AgregarGastoContabilidad(contabilidadActual, dpkFecha.Value, cobroActual.getNombre());
                        agregarGastoContabilidad.ShowDialog();

                        if (agregarGastoContabilidad.getAgrego())
                        {
                            Console.WriteLine(agregarGastoContabilidad.getValorGasto());
                            contabilidadActual = AgregarOtroGastoUseCase.agregarGasto(contabilidadActual.getId(), cobroActual.getNombre(), agregarGastoContabilidad.getDescripcionGasto(), agregarGastoContabilidad.getFecha(), agregarGastoContabilidad.getValorGasto());
                            listaContabilidades[listaContabilidades.FindIndex(c => c.getId() == contabilidadActual.getId())] = contabilidadActual;

                            MessageBox.Show("Gasto agregado exitosamente.", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cargarContabilidadoByFecha();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No es posible agragar gasto a la contabilidad ya que la contabilidad fue guardada.", "No se puede agregar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Primero debes cargar abonos para poder cargar otros gastos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debes selecionar primero un cobro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void cargarTotales()
        //{
        //    if (listaCobros != null)
        //    {
        //        if (!String.IsNullOrEmpty(cboCobro.Text))
        //        {
        //            //lblTotales.Text = Cartera.agregarTotales(cboCobro.Text.ToUpper());
        //        }                
        //    }
        //}

        private void cargarTirillaDeCartera()
        {
            if (!CampoFactory.isNull(cboCobro.Text.ToUpper().Trim()))
            {
                listaCarteras = ConsultarCarterasUseCase.consultarCarteras(cboCobro.Text.ToUpper().Trim());

                if (!ListValidators.validarListaVaciaONula(listaCarteras))
                {
                    CarteraTirilla carteraTirilla = new CarteraTirilla(cboCobro.Text.ToUpper());
                    carteraTirilla.ShowDialog();
                }
            }
        }

        private void calcularCartera()
        {
            if (formularioCrearNuevoClienteValido())
            {
                cargarContabilidad();
                List<Contabilidad> contabilidads = listaContabilidades.FindAll(c => c.getNombreCobro().Equals(cobroActual.getNombre()) && c.getEstado().Equals(TipoEstados.NO_GUARDADO));

                if (ListValidators.validarListaVaciaONula(contabilidads))
                {
                    MessageBox.Show("No hay contabilidades para procesar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    List<Object> list = new List<Object>();
                    contabilidads.ForEach(co =>
                    {
                        list.Add(co as Object);
                    });

                    CargarCarteraView cargarCarteraView = new CargarCarteraView(cobroActual.getNombre(), list);
                    cargarCarteraView.ShowDialog();

                    if (cargarCarteraView.seGuardo())
                    {
                        List<Contabilidad> contabilidadesAGuardar = new List<Contabilidad>();
                        cargarCarteraView.getContabilidadesAGuardar().ForEach(co =>
                        {
                            contabilidadesAGuardar.Add(co as Contabilidad);
                        });
                    }
                }
            }
        }

        private void enviarAClavo()
        {
            if (formularioCrearNuevoClienteValido())
            {
                if (sePuedeEnviarAClavo(prestamoActual))
                {
                    if(MessageBox.Show("¿Realmente desean enviar a CLAVO", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cobroActual = EnviarClavoUseCase.enviarClavo(cobroActual, prestamoActual, new DateTime(dpkFecha.Value.Year, dpkFecha.Value.Month, dpkFecha.Value.Day));
                        listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;
                        clienteActual = cobroActual.getClientes().Find(cli => cli.getCedula().Equals(clienteActual.getCedula()));
                        listaPrestamosActuales = clienteActual.getPrestamos();
                        prestamoActual = clienteActual.getPrestamos().Find(p => p.getId() == prestamoActual.getId());

                        cargarPanelCliente(clienteActual, prestamoActual, clienteActual.getPrestamos(), true);
                        cargarPanelDescripcion(prestamoActual);
                        cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
                        cargarPanelPrestamo(prestamoActual);
                        cargarPanelTablas(cobroActual);

                        MessageBox.Show("Enviado a clavo exitosamente.");
                    }
                }
                else
                {
                    MessageBox.Show("El prestamo no se puede enviar a CLAVO", "Error envio a clavo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Boolean sePuedeEnviarAClavo(Prestamo prestamo)
        {
            if(prestamo.getValorDebe() > 0 && prestamo.getEstado().Equals(TipoEstados.ACTIVO))
            {
                return true;
            }

            return false;
        }

        private void cambiarRutaCliente()
        {
            if (formularioCrearNuevoClienteValido())
            {
                EditarRutaCliente editarRutaCliente= new EditarRutaCliente(cobroActual, clienteActual);
                editarRutaCliente.ShowDialog();

                if (!ObjectUtils.isNull(editarRutaCliente.getAccion())){
                    cobroActual = EditarRutaClienteUseCase.editarRutaCliente(editarRutaCliente.getClienteActual() as Cliente, editarRutaCliente.getClienteProximo() as Cliente, editarRutaCliente.getAccion());

                    listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;

                    clienteActual = cobroActual.getClientes().Find(cli => cli.getCedula().Equals(clienteActual.getCedula()));
                    prestamoActual = clienteActual.getPrestamos()[0];

                    cargarPanelCliente(clienteActual, prestamoActual, clienteActual.getPrestamos(), true);
                    cargarPanelDescripcion(prestamoActual);
                    cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
                    cargarPanelPrestamo(prestamoActual);
                    cargarPanelTablas(cobroActual);

                    MessageBox.Show("Se actualizo la ruta del cliente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void editarCedula()
        {
            if (formularioCrearNuevoClienteValido())
            {
                EditarCedulaClienteView editarCedulaClienteView = new EditarCedulaClienteView(txtCedula.Text, clienteActual.getId(), cobroActual.getNombre());
                editarCedulaClienteView.ShowDialog();

                if (!ObjectUtils.isNull(editarCedulaClienteView.getCobro()))
                {
                    cobroActual = editarCedulaClienteView.getCobro() as Cobro;

                    listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;

                    clienteActual = cobroActual.getClientes().Find(cli => cli.getId().Equals(clienteActual.getId()));
                    prestamoActual = clienteActual.getPrestamos()[0];

                    cargarPanelCliente(clienteActual, prestamoActual, clienteActual.getPrestamos(), true);
                    cargarPanelDescripcion(prestamoActual);
                    cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
                    cargarPanelPrestamo(prestamoActual);
                    cargarPanelTablas(cobroActual);

                    MessageBox.Show("Se actualizo la cedula del cliente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void eliminarPrestamo()
        {
            if (formularioCrearNuevoClienteValido())
            {
                Contabilidad contabilidad = listaContabilidades.Find(c =>
                    c.getFecha().Year.Equals(prestamoActual.getFechaInicio().Year)
                    && c.getFecha().Month.Equals(prestamoActual.getFechaInicio().Month)
                    && c.getFecha().Day.Equals(prestamoActual.getFechaInicio().Day)
                    && c.getNombreCobro().Equals(cobroActual.getNombre()));

                if (contabilidad.getEstado().Equals(TipoEstados.NO_GUARDADO))
                {
                    if (prestamoActual.getEstado().Equals(TipoEstados.PAGO))
                    {
                        MessageBox.Show("El prestamo ya se pago, no se puede eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // UseCase.
                        if(clienteActual.getPrestamos().Count == 1)
                        {
                            //Se elimina cliente y prestamo
                            if (MessageBox.Show("Realmente deseas eliminar el prestamo.", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (!ListValidators.validarListaVaciaONula(prestamoActual.getAbonos()))
                                {
                                    listaContabilidades = RestarAbonosDeContabilidadesUseCase.restarAbonosAContabilidades(prestamoActual.getAbonos(), listaContabilidades.FindAll(c => c.getNombreCobro().Equals(cobroActual.getNombre())));
                                }

                                listaContabilidades = RestarCobroUtilidadContabilidadUseCase.restarAbonosAContabilidades(contabilidad, prestamoActual);
                                Cobro cobro = EliminarAbonosUseCase.eliminarAbonos(cobroActual.getNombre(), prestamoActual);
                                cobro = EliminarDomingoUseCase.eliminarDomingo(cobroActual.getNombre(), prestamoActual);
                                cobro = EliminarPrestamoUseCase.eliminarPrestamo(cobroActual.getNombre(), prestamoActual);

                                cobroActual = EliminarClienteUseCase.eliminarCliente(cobroActual.getNombre(), clienteActual, cobroActual.getClientes().Find(cliente => cliente.getRuta() == cobroActual.getClientes().Count).getRuta());
                                listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;

                                clienteActual = cobroActual.getClientes().Find(cli => cli.getRuta() == 1);

                                listaPrestamosActuales = clienteActual.getPrestamos();
                                prestamoActual = listaPrestamosActuales[0];

                                MessageBox.Show("Se elimino exitosamente el prestamo.", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                cargarPanelDescripcion(prestamoActual);
                                cargarPanelTablas(cobroActual);
                                cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);

                                cargarContabilidadoByFecha();
                            }
                        }
                        else
                        {
                            //Se elimina prestamo   
                            if (MessageBox.Show("Realmente deseas eliminar el prestamo.", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (!ListValidators.validarListaVaciaONula(prestamoActual.getAbonos()))
                                {
                                    listaContabilidades = RestarAbonosDeContabilidadesUseCase.restarAbonosAContabilidades(prestamoActual.getAbonos(), listaContabilidades.FindAll(c => c.getNombreCobro().Equals(cobroActual.getNombre())));
                                }                                

                                listaContabilidades = RestarCobroUtilidadContabilidadUseCase.restarAbonosAContabilidades(contabilidad, prestamoActual);
                                Cobro cobro = EliminarAbonosUseCase.eliminarAbonos(cobroActual.getNombre(), prestamoActual);
                                cobro = EliminarDomingoUseCase.eliminarDomingo(cobroActual.getNombre(), prestamoActual);

                                cobroActual = EliminarPrestamoUseCase.eliminarPrestamo(cobroActual.getNombre(), prestamoActual);
                                listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;

                                clienteActual = cobroActual.getClientes().Find(cli => cli.getCedula().Equals(clienteActual.getCedula()));

                                listaPrestamosActuales = clienteActual.getPrestamos();
                                prestamoActual = listaPrestamosActuales[0];

                                MessageBox.Show("Se elimino exitosamente el prestamo.", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                cargarPanelDescripcion(prestamoActual);
                                cargarPanelTablas(cobroActual);
                                cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);

                                cargarContabilidadoByFecha();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La contabilidad de este prestamo ya fue guardada, no se puede eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cambiarNumeroTelefono()
        {
            if (formularioCrearNuevoClienteValido())
            {
                EditarTelefonoClienteView editarTelefonoClienteView = new EditarTelefonoClienteView(txtTelefono.Text, clienteActual.getId(), cobroActual.getNombre());
                editarTelefonoClienteView.ShowDialog();

                if (!ObjectUtils.isNull(editarTelefonoClienteView.getCobro()))
                {
                    cobroActual = editarTelefonoClienteView.getCobro() as Cobro;

                    listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;

                    clienteActual = cobroActual.getClientes().Find(cli => cli.getCedula().Equals(clienteActual.getCedula()));
                    prestamoActual = clienteActual.getPrestamos()[0];

                    cargarPanelCliente(clienteActual, prestamoActual, clienteActual.getPrestamos(), true);
                    cargarPanelDescripcion(prestamoActual);
                    cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
                    cargarPanelPrestamo(prestamoActual);
                    cargarPanelTablas(cobroActual);

                    MessageBox.Show("Se actualizo el telefono del cliente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cambiarDireccionCliente()
        {
            if (formularioCrearNuevoClienteValido())
            {
                EditarDireccionClienteView editarDireccionClienteView = new EditarDireccionClienteView(txtDireccion.Text, clienteActual.getId(), cobroActual.getNombre());
                editarDireccionClienteView.ShowDialog();

                if (!ObjectUtils.isNull(editarDireccionClienteView.getCobro()))
                {
                    cobroActual = editarDireccionClienteView.getCobro() as Cobro;

                    listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;

                    clienteActual = cobroActual.getClientes().Find(cli => cli.getCedula().Equals(clienteActual.getCedula()));
                    prestamoActual = clienteActual.getPrestamos()[0];

                    cargarPanelCliente(clienteActual, prestamoActual, clienteActual.getPrestamos(), true);
                    cargarPanelDescripcion(prestamoActual);
                    cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
                    cargarPanelPrestamo(prestamoActual);
                    cargarPanelTablas(cobroActual);

                    MessageBox.Show("Se actualizo la direccion del cliente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cambiarNombreCliente()
        {
            if (formularioCrearNuevoClienteValido())
            {
                EditarNombreClienteView editarNombreClienteView = new EditarNombreClienteView(txtNombre.Text, clienteActual.getId(), cobroActual.getNombre());
                editarNombreClienteView.ShowDialog();

                if (!ObjectUtils.isNull(editarNombreClienteView.getCobro()))
                {
                    cobroActual = editarNombreClienteView.getCobro() as Cobro;

                    listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;

                    clienteActual = cobroActual.getClientes().Find(cli => cli.getCedula().Equals(clienteActual.getCedula()));
                    prestamoActual = clienteActual.getPrestamos()[0];

                    cargarPanelCliente(clienteActual, prestamoActual, clienteActual.getPrestamos(), true);
                    cargarPanelDescripcion(prestamoActual);
                    cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
                    cargarPanelPrestamo(prestamoActual);
                    cargarPanelTablas(cobroActual);

                    MessageBox.Show("Se actualizo el nombre del cliente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------------
        //  EVENTOS
        // ---------------------------------------------------------------------------------------------------------------------------------

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("¿Deseas salir de la aplicación?", "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               // CrearCopiaBaseDatosUseCase.tenga();

                Application.Exit();
            }
        }

        private void menuNuevoCobro_Click(object sender, EventArgs e)
        {
            crearNuevoCobro();
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
                limpiarPanelCalificacion();
                limpiarPanelCliente();
                limpiarPanelPrestamo();
                limpiarPanelDescripcion();
            }
        }
              
        private void txtCedula_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!CampoFactory.isNull(cboCobro.Text.Trim()))
                {
                    if (CampoFactory.isNull(txtCedula.Text.Trim()))
                    {
                        this.errorCedula.SetError(this.txtCedula, "Debes ingresar un valor.");
                        txtCedula.Focus();
                    }
                    else
                    {
                        if (!ListValidators.validarListaVaciaONula(cobroActual.getClientes()))
                        {
                            if (cobroActual.getClientes().Exists(c => c.getCedula().Equals(txtCedula.Text.Trim().ToUpper())))
                            {
                                clienteActual = cobroActual.getClientes().Find(c => c.getCedula().Equals(txtCedula.Text.Trim().ToUpper()));
                                prestamoActual = clienteActual.getPrestamos()[0];

                                cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
                                cargarPanelDescripcion(prestamoActual);
                                cargarPanelPrestamo(prestamoActual);
                                cargarPanelCliente(clienteActual, prestamoActual, clienteActual.getPrestamos(), true);
                            }
                        }
                        txtNombre.Focus();
                        this.errorCedula.Dispose();
                    }                                   
                }
            }
            else
            {
                if (!CampoFactory.isNumeric(txtCedula.Text.Trim()))
                {
                    this.errorCedula.SetError(this.txtCedula, "Solo valores numéricos.");
                    if (!CampoFactory.isNull(txtCedula.Text.Trim()))
                    {
                        txtCedula.Text = txtCedula.Text.Trim().Remove(txtCedula.Text.Trim().Length - 1);
                    }
                }
                else
                {
                    this.errorCedula.Dispose();
                }
            }
        }

        private void cboCobro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cambioDeCobro();
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CampoFactory.isNull(txtNombre.Text.Trim()))
                {
                    this.errorNombreCliente.SetError(this.txtNombre, "Debes ingresar un valor.");
                    txtNombre.Focus();
                }
                else
                {
                    this.errorNombreCliente.Dispose();
                    txtPrestamo.Focus();
                }
            }
        }

        private void txtPrestamo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!CampoFactory.isNull(txtPrestamo.Text.Trim()))
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
                if (!CampoFactory.isNumeric(txtPrestamo.Text.Trim()))
                {
                    this.errorPrestamo.SetError(this.txtPrestamo, "Solo valores numéricos.");
                    if (!CampoFactory.isNull(txtPrestamo.Text.Trim()))
                    {
                        txtPrestamo.Text = txtPrestamo.Text.Trim().Remove(txtPrestamo.Text.Trim().Length - 1);
                    }                        
                }
                else
                {
                    this.errorPrestamo.Dispose();
                    calcularPrestamo();
                }
            }
        }

        private void txtDireccion_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (CampoFactory.isNull(txtDireccion.Text.Trim()))
                {
                    this.errorDireccion.SetError(this.txtDireccion, "Debes ingresar un valor.");
                    txtDireccion.Focus();
                }
                else
                {
                    this.errorNombreCliente.Dispose();

                    if (!ckbFechaSistema.Checked)
                    {
                        dpkFecha.Select();
                    }
                    else
                    {
                        txtTelefono.Focus();
                    }
                }
            }
        }

        private void txtTelefono_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CampoFactory.isNull(txtTelefono.Text.Trim()))
                {
                    this.errorTelefono.SetError(this.txtTelefono, "Debes ingresar un valor.");
                    txtTelefono.Focus();
                }
                else
                {
                    this.errorTelefono.Dispose();
                    crearNuevoCliente();                    
                }
            }
            else
            {
                if (!CampoFactory.isNumeric(txtTelefono.Text.Trim()))
                {
                    this.errorTelefono.SetError(this.txtTelefono, "Solo valores numéricos.");
                    if (!CampoFactory.isNull(txtTelefono.Text.Trim()))
                    {
                        txtTelefono.Text = txtTelefono.Text.Trim().Remove(txtTelefono.Text.Trim().Length - 1);
                    }
                }
                else
                {
                    this.errorTelefono.Dispose();
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
            cargarPagoAbono();
        }

        private void rdbUnico_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdbUnico.Checked)
            //{
            //    rdbVarios.Checked = false;
            //    dtpFechaFinalContabilidad.Enabled = false;
            //    cargarContabilidad();
            //}
        }

        private void rdbVarios_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdbVarios.Checked)
            //{
            //    rdbUnico.Checked = false;
            //    dtpFechaFinalContabilidad.Enabled = true;
            //    dtpFechaFinalContabilidad.Value = dtpFechaInicioContabilidad.Value.AddDays(1);
            //    cargarContabilidad();
            //}
        }

        private void dtpFechaInicioAbono_ValueChanged(object sender, EventArgs e)
        {
            //if (rdbVarios.Checked && dtpFechaInicioContabilidad.Value >= dtpFechaFinalContabilidad.Value)
            //{
            //    dtpFechaFinalContabilidad.Value = dtpFechaInicioContabilidad.Value.AddDays(1);
            //}

            //cargarContabilidad();
        }

        private void dtpFechaFinalAbono_ValueChanged(object sender, EventArgs e)
        {
            //if (rdbVarios.Checked && dtpFechaFinalContabilidad.Value <= dtpFechaInicioContabilidad.Value)
            //{
            //    dtpFechaInicioContabilidad.Value = dtpFechaFinalContabilidad.Value.AddDays(-1);
            //}

            //cargarContabilidad();
        }

        private void dpkFecha_ValueChanged(object sender, EventArgs e)
        {
            //dtpFechaInicioContabilidad.Value = dpkFecha.Value;
            cargarPanelTablas(cobroActual);
        }

        private void btnTirilla_Click(object sender, EventArgs e)
        {
            cargarTirillaDeCartera();
        }

        private void cboPrestamos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cambioDePrestamo();
        }

        private void btnPasarAClavo_MouseEnter(object sender, EventArgs e)
        {
            btnPasarAClavo.BackColor = System.Drawing.Color.Red;
        }

        private void btnPasarAClavo_MouseLeave(object sender, EventArgs e)
        {
            btnPasarAClavo.BackColor = System.Drawing.Color.White;
        }

        private void btnNuevoPrestamo_Click(object sender, EventArgs e)
        {
            crearNuevoPrestamo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarPrestamo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //calcularCartera();
        }

        private void btnAgregarOtroGastoContabilidad_MouseEnter(object sender, EventArgs e)
        {
            btnAgregarOtroGastoContabilidad.BackColor = System.Drawing.Color.LawnGreen;
        }

        private void btnAgregarOtroGastoContabilidad_MouseLeave(object sender, EventArgs e)
        {
            btnAgregarOtroGastoContabilidad.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnAgregarOtroGastoContabilidad_Click(object sender, EventArgs e)
        {
            agregarOtroGastoContabilidad();
        }

        private void gastoDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crearNuevoGastoDiario();
        }

        private void btnPasarAClavo_Click(object sender, EventArgs e)
        {
            enviarAClavo();
        }

        private void btnEditarRuta_Click(object sender, EventArgs e)
        {
            cambiarRutaCliente();
        }

        private void btnEditarCedula_MouseEnter(object sender, EventArgs e)
        {
            btnEditarCedula.BackColor = System.Drawing.Color.Orange;
        }

        private void btnEditarCedula_MouseLeave(object sender, EventArgs e)
        {
            btnEditarCedula.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnEditarNombre_Click(object sender, EventArgs e)
        {
            cambiarNombreCliente();
        }

        private void btnEditarNombre_MouseEnter(object sender, EventArgs e)
        {
            btnEditarNombre.BackColor = System.Drawing.Color.Orange;
        }

        private void btnEditarNombre_MouseLeave(object sender, EventArgs e)
        {
            btnEditarNombre.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnEditarDireccion_Click(object sender, EventArgs e)
        {
            cambiarDireccionCliente();
        }

        private void btnEditarDireccion_MouseEnter(object sender, EventArgs e)
        {
            btnEditarDireccion.BackColor = System.Drawing.Color.Orange;
        }

        private void btnEditarDireccion_MouseLeave(object sender, EventArgs e)
        {
            btnEditarDireccion.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnEditarTelefono_Click(object sender, EventArgs e)
        {
            cambiarNumeroTelefono();
        }

        private void btnEditarTelefono_MouseEnter(object sender, EventArgs e)
        {
            btnEditarTelefono.BackColor = System.Drawing.Color.Orange;
        }

        private void btnEditarTelefono_MouseLeave(object sender, EventArgs e)
        {
            btnEditarTelefono.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnEditarCedula_Click(object sender, EventArgs e)
        {
            editarCedula();
        }

        private void tablaDescripcion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!ObjectUtils.isNull(tablaDescripcion.CurrentRow.Cells["FECHA -> ABONO"].Value))
            {
                if (!tablaDescripcion.CurrentRow.Cells["TIPO"].Value.ToString().Equals("DOMINGOS"))
                {
                    DateTime fecha = Convert.ToDateTime(tablaDescripcion.CurrentRow.Cells["FECHA -> ABONO"].Value.ToString());

                    Abono abono = prestamoActual.getAbonos().Find(a =>
                                        a.getFecha().Year.Equals(fecha.Year)
                                        && a.getFecha().Month.Equals(fecha.Month)
                                        && a.getFecha().Day.Equals(fecha.Day)
                                        && a.getTipoAbono().Equals(tablaDescripcion.CurrentRow.Cells["TIPO"].Value.ToString())
                                        && a.getValor().Equals(Double.Parse(tablaDescripcion.CurrentRow.Cells["ABONO"].Value.ToString()))
                                        && a.getRestante().Equals(Double.Parse(tablaDescripcion.CurrentRow.Cells["RESTA"].Value.ToString())));

                    List<Object> abonos = new List<object>();
                    prestamoActual.getAbonos().FindAll(a => a.getFecha() >= fecha && !a.getId().Equals(abono.getId()))
                        .ForEach(ab => abonos.Add(ab as Object));

                    Contabilidad contabilidad = listaContabilidades.Find(c =>
                                        c.getFecha().Year.Equals(fecha.Year)
                                        && c.getFecha().Month.Equals(fecha.Month)
                                        && c.getFecha().Day.Equals(fecha.Day)
                                        && c.getNombreCobro().Equals(cobroActual.getNombre()));

                    EliminarAbonoView eliminarAbonoView = new EliminarAbonoView(cobroActual.getNombre(), abono, abonos, prestamoActual, contabilidad);
                    eliminarAbonoView.ShowDialog();

                    if (!ObjectUtils.isNull(eliminarAbonoView.getCobroActual()))
                    {
                        cobroActual = eliminarAbonoView.getCobroActual() as Cobro;
                        listaCobros[listaCobros.FindIndex(c => c.getId() == cobroActual.getId())] = cobroActual;

                        clienteActual = cobroActual.getClientes().Find(cli => cli.getCedula().Equals(clienteActual.getCedula()));

                        listaPrestamosActuales = clienteActual.getPrestamos();
                        prestamoActual = listaPrestamosActuales[0];

                        cargarPanelDescripcion(prestamoActual);
                        cargarPanelTablas(cobroActual);
                        cargarPanelCalificacion(clienteActual, cobroActual.getClientes().Count, prestamoActual);
                    }
                }
            }
        }

        private void btnEliminarPrestamo_MouseEnter(object sender, EventArgs e)
        {
            btnEliminarPrestamo.BackColor = System.Drawing.Color.Red;
        }

        private void btnEliminarPrestamo_MouseLeave(object sender, EventArgs e)
        {
            btnEliminarPrestamo.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnEliminarPrestamo_Click(object sender, EventArgs e)
        {
            eliminarPrestamo();
        }
    }
}
