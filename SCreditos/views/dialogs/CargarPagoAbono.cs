using SCreditos.factory;
using SCreditos.models;
using System;
using System.Windows.Forms;

namespace SCreditos.views.dialogs
{
    public partial class CargarPagoAbono : Form
    {
        private Cliente cliente;

        private Prestamo prestamo;
               
        private Abono abono;

        private Boolean pago = false;

        public CargarPagoAbono(Object pCliente, Object pPrestamo)
        {
            InitializeComponent();

            cliente = pCliente as Cliente;
            prestamo = pPrestamo as Prestamo;

            lblCedulaCliente.Text = cliente.getCedula();
            lblNombreCliente.Text = cliente.getNombre();

            lblBoleta.Text = prestamo.getId().ToString();
            lblValorPrestamo.Text = prestamo.getValor().ToString();
            lblValorDebe.Text = prestamo.getValorDebe().ToString();
            lblValorCuota.Text = prestamo.getCuota().ToString();
            txtValorAbono.Text = prestamo.getCuota().ToString();

            txtValorAbono.Focus();
            txtValorAbono.Select();
        }

        public Object getAbono()
        {
            return this.abono;
        }

        public Boolean sePago()
        {
            return this.pago;
        }

        public void pagar()
        {
            if (CampoFactory.isNull(txtValorAbono.Text.Trim()))
            {
                this.errorAbono.SetError(this.txtValorAbono, "Debes ingresar un valor.");
            }
            else
            {
                this.errorAbono.Dispose();

                if (Convert.ToDouble(txtValorAbono.Text.Trim()) > prestamo.getValorDebe())
                {
                    MessageBox.Show("El valor a abonar es superior\n a lo que debe el cliente.", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("¿Realmente deseas cargar el abono. \nVALOR: " + txtValorAbono.Text.Trim() + "" +
                        "\nFECHA DE PAGO: "+ dpkFecha.Value.ToShortDateString() +"?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        abono = new Abono(0, prestamo.getId(), new DateTime(dpkFecha.Value.Year, dpkFecha.Value.Month, dpkFecha.Value.Day), Convert.ToDouble(txtValorAbono.Text.Trim()), 0);
                        pago = true;
                        this.Dispose();
                    }
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            pagar();
        }

        private void txtValorAbono_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pagar();
            }
            else
            {
                if (!CampoFactory.isNumeric(txtValorAbono.Text.Trim()))
                {
                    this.errorAbono.SetError(this.txtValorAbono, "Solo valores numéricos.");
                    if (!CampoFactory.isNull(txtValorAbono.Text.Trim()))
                    {
                        txtValorAbono.Clear();
                    }
                }
                else
                {
                    this.errorAbono.Dispose();
                }
            }
        }
    }
}
