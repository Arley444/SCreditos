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
    public partial class EditarNombreClienteView : Form
    {
        private String nombreActual;
        private int id;
        private String cobroDelcliente;
        private Cobro cobro;

        public EditarNombreClienteView(String pNombre, int pId, String pCobro)
        {
            this.id = pId;
            this.nombreActual = pNombre;
            this.cobroDelcliente = pCobro;
            InitializeComponent();
            txtNombre.Text = pNombre;
        }

        public Object getCobro()
        {
            return this.cobro;
        }

        private void btnCambiarNombre_Click(object sender, EventArgs e)
        {
            if (!ObjectUtils.isNull(txtNombre.Text.Trim()))
            {
                this.error.Dispose();
                if (nombreActual.Equals(txtNombre.Text.Trim()))
                {
                    this.Dispose();
                }
                else
                {
                    cobro = EditarNombreClienteUseCase.editarNombreCliente(txtNombre.Text.Trim(), id, cobroDelcliente);
                    this.Dispose();
                }
            }
            else
            {
                this.error.SetError(this.txtNombre, "Ingrese algun valor");
            }
        }
    }
}
