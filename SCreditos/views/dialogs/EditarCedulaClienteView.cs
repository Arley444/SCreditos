using SCreditos.factory;
using SCreditos.models;
using SCreditos.usecase.cliente;
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
    public partial class EditarCedulaClienteView : Form
    {
        private String cedulaActual;
        private String id;
        private String cobroDelcliente;
        private Cobro cobro;

        public EditarCedulaClienteView(String pCedula)
        {
            cedulaActual = pCedula;
            InitializeComponent();
            txtCedula.Text = pCedula;
        }

        private void btnCambiarCedula_Click(object sender, EventArgs e)
        {
            if (!ObjectUtils.isNull(txtCedula.Text.Trim()))
            {
                this.error.Dispose();
                if (cedulaActual.Equals(txtCedula.Text.Trim()))
                {
                    this.Dispose();
                }
                else
                {
                    if (ExisteClienteUseCase.existeCliente(txtCedula.Text.Trim()))
                    {
                        MessageBox.Show("Ya existe un cliente con la misma cedula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cobro = EditarCedulaClienteUseCase.editarCedulaCliente(txtCedula.Text.Trim(), id, cobroDelcliente);
                        this.Dispose();
                    }
                }
            }
            else
            {
                this.error.SetError(this.txtCedula, "Ingrese algun valor");
            }
        }

        public Object getCobro()
        {
            return this.cobro;
        }
    }
}
