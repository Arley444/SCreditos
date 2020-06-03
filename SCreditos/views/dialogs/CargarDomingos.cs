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
        private int idPrestamo;

        private long valorPorDomingo;
        private int domingos;
        private double valorAbono;

        public CargarDomingos(int pDomingos, double pPrestamoValor, int pPrestamoId)
        {
            InitializeComponent();

            idPrestamo = pPrestamoId;

            cboDomingos.Items.Clear();
            int contador = 0;
            while (contador < pDomingos)
            {
                cboDomingos.Items.Add(contador);
                contador++;
            }
            valorPorDomingo = ((long)(pPrestamoValor / 50000)) * 2000;
            cargarInterfaz();
        }

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

        private void chkAbono_CheckStateChanged(object sender, EventArgs e)
        {
            cargarInterfaz();
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


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿No vas a cargar pago de domingos o abono?", "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                if (MessageBox.Show("¿Realmente NO?", "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    Abono.pagarDomingos(this.idPrestamo, 0, 0, valorPorDomingo);
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

                    if (MessageBox.Show("Deseas cargar el pago.", "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        domingos = Int32.Parse(((long)(valorAbono / valorPorDomingo)).ToString());
                        Abono.pagarDomingos(this.idPrestamo, domingos, valorAbono, valorPorDomingo);
                        this.Dispose();
                    }
                }
                else
                {
                    domingos = Int32.Parse(cboDomingos.Text);

                    if (MessageBox.Show("Deseas cargar el pago.", "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        double valorPagar = domingos * this.valorPorDomingo;
                        Abono.pagarDomingos(this.idPrestamo, domingos, valorPagar, valorPorDomingo);
                        this.Dispose();
                    }
                }
            }
        }
    }
}
