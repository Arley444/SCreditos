using SCreditos.factory;
using SCreditos.models;
using SCreditos.usecase.cliente;
using System;
using System.Windows.Forms;

namespace SCreditos.views.dialogs
{
    public partial class EditarCedulaClienteView : Form
    {
        private String cedulaActual;
        private int id;
        private String cobroDelcliente;
        private Cobro cobro;

        public EditarCedulaClienteView(String pCedula, int pId, String pCobro)
        {
            this.id = pId;
            this.cedulaActual = pCedula;
            this.cobroDelcliente = pCobro;
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
                        cobro = EditarCedulaClienteUseCase.editarCedulaCliente(txtCedula.Text.Trim(), id, cobroDelcliente, cedulaActual);
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
