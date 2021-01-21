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
    public partial class AgregarGastoContabilidad : Form
    {

        private Boolean agrego = false;

        private Contabilidad contabilidad;

        public AgregarGastoContabilidad(Object pContabilidad, DateTime pFecha, String pCobro)
        {
            contabilidad = pContabilidad as Contabilidad;
            InitializeComponent();
            txtFecha.Text = pFecha.ToShortDateString();
            txtCobro.Text = pCobro;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //contabilidad.setG
            agrego = true;
        }
    }
}
