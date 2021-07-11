using SCreditos.factory;
using SCreditos.models;
using SCreditos.usecase.cliente;
using System;
using System.Windows.Forms;

namespace SCreditos.views.dialogs
{
    public partial class EditarTelefonoClienteView : Form
    {
        private String telefonoActual;
        private int id;
        private String cobroDelcliente;
        private Cobro cobro;

        public EditarTelefonoClienteView(String pTelefono, int pId, String pCobro)
        {
            this.id = pId;
            this.telefonoActual = pTelefono;
            this.cobroDelcliente = pCobro;
            InitializeComponent();
            txtTelefono.Text = pTelefono;
        }

        public Object getCobro()
        {
            return this.cobro;
        }

        private void btnCambiarTelefono_Click(object sender, EventArgs e)
        {
            if (!ObjectUtils.isNull(txtTelefono.Text.Trim()))
            {
                this.error.Dispose();
                if (telefonoActual.Equals(txtTelefono.Text.Trim()))
                {
                    this.Dispose();
                }
                else
                {                
                    cobro = EditarTelefonoClienteUseCase.editarTelefonoCliente(txtTelefono.Text.Trim(), id, cobroDelcliente);
                    this.Dispose();
                }
            }
            else
            {
                this.error.SetError(this.txtTelefono, "Ingrese algun valor");
            }
        }
    }
}
