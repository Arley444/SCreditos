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
    public partial class ConfirmacionGuardarCarteraView : Form
    {
        private Cartera cartera;
        private Boolean seAprueba = false;

        public ConfirmacionGuardarCarteraView(Object pCartera)
        {
            this.cartera = pCartera as Cartera;
            InitializeComponent();
            this.lblFecha.Text = "( " + this.cartera.getFechaInicio().ToString() + " - " + this.cartera.getFechaFinal().ToString() + " )";
            this.lblTarjetas.Text = ".................... " + this.cartera.getTarjetas().ToString();
            this.lblCobro.Text = ".................... " + this.cartera.getCobro().ToString();
            this.lblPresto.Text = ".................... " + this.cartera.getPresto().ToString();
            this.lblUtilidad.Text = ".................... " + this.cartera.getUtilidad().ToString();
            this.lblBase.Text = ".................... " + this.cartera.getBase().ToString();
            this.lblEfectivo.Text = ".................... " + this.cartera.getEfectivo().ToString();
            this.lblGastos.Text = ".................... " + this.cartera.getGastos().ToString();
            this.lblCartera.Text = ".................... " + this.cartera.getCartera().ToString();
            this.lblCaja.Text = ".................... " + this.cartera.getCaja().ToString();
        }

        public Boolean getAprobo()
        {
            return this.seAprueba;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.seAprueba = true;
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.seAprueba = false;
            this.Dispose();
        }
    }
}
