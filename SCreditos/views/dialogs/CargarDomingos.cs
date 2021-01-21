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
    public partial class CargarDomingos : Form
    {
        // ---------------------------------------------------------------------------------------------------------------------------------
        //  ATRIBUTOS
        // ---------------------------------------------------------------------------------------------------------------------------------
        private int idPrestamo;
        private long valorPorDomingo;
        private int domingos;
        private Double valorAbono;


        // ---------------------------------------------------------------------------------------------------------------------------------
        //  CONSTRUCTORES
        // ---------------------------------------------------------------------------------------------------------------------------------
        public CargarDomingos(Double pPrestamoValor)
        {
            InitializeComponent();
            valorPorDomingo = ((long)(pPrestamoValor / 50000)) * 2000;
            cargarInterfaz();
        }


        // ---------------------------------------------------------------------------------------------------------------------------------
        //  METODOS
        // ---------------------------------------------------------------------------------------------------------------------------------
        private void cargarInterfaz()
        {
            if (chkAbono.Checked)
            {
                lblDomingos.Enabled = false;
                cboDomingos.Enabled = false;

                txtAbono.Enabled = true;
            }
            else
            {
                lblDomingos.Enabled = true;
                cboDomingos.Enabled = true;

                txtAbono.Enabled = false;
                txtAbono.Clear();
            }
        }

        private Boolean validarFormulario()
        {
            if (chkAbono.Checked && String.IsNullOrEmpty(txtAbono.Text))
            {
                error.SetError(txtAbono, "Ingrese un valor");
                return false;
            }
            else
            {
                error.Dispose();
            }

            return true;
        }

        public Double getValorAbono()
        {
            return this.valorAbono;
        }

        public int getDomingos()
        {
            return this.domingos;
        }

        public long getValorPorDomingo()
        {
            return this.valorPorDomingo;
        }

        // ---------------------------------------------------------------------------------------------------------------------------------
        //  EVENTOS
        // ---------------------------------------------------------------------------------------------------------------------------------
        private void chkAbono_CheckStateChanged(object sender, EventArgs e)
        {
            cargarInterfaz();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿No vas a cargar pago de domingos?", "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                if (MessageBox.Show("¿Realmente NO vas a cargar pago de domingos?", "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    valorAbono = 0;
                    domingos = 0;
                    //Abono.pagarDomingos(this.idPrestamo, 0, 0, valorPorDomingo);
                    this.Dispose();
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarFormulario())
            {
                if (chkAbono.Checked)
                {
                    valorAbono = Double.Parse(txtAbono.Text);
                    domingos = Int32.Parse(((long)(valorAbono / valorPorDomingo)).ToString());

                    if (MessageBox.Show("Deseas cargar el pago de domingos." +
                        "\nVALOR A PAGAR: "+ valorAbono +"" +
                        "\nEQUIVALE A: "+ domingos +" Domingos" +
                        "\nVALOR POR DOMINGO: "+ valorPorDomingo +"", "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        
                        //Abono.pagarDomingos(this.idPrestamo, domingos, valorAbono, valorPorDomingo);
                        this.Dispose();
                    }
                }
                else
                {
                    domingos = Int32.Parse(cboDomingos.Text);
                    valorAbono = domingos * this.valorPorDomingo;

                    if (MessageBox.Show("Deseas cargar el pago de domingos." +
                        "\nVALOR A PAGAR: " + valorAbono + "" +
                        "\nEQUIVALE A: " + domingos + " Domingos" +
                        "\nVALOR POR DOMINGO: " + valorPorDomingo + "", "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                       // Abono.pagarDomingos(this.idPrestamo, domingos, valorPagar, valorPorDomingo);
                        this.Dispose();
                    }
                }
            }
        }
    }
}
