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
    public partial class EditarDireccionClienteView : Form
    {
        private String direccionActual;
        private int id;
        private String cobroDelcliente;
        private Cobro cobro;

        public EditarDireccionClienteView(String pDireccion, int pId, String pCobro)
        {
            this.id = pId;
            this.direccionActual = pDireccion;
            this.cobroDelcliente = pCobro;
            InitializeComponent();
            txtDireccion.Text = pDireccion;
        }

        public Object getCobro()
        {
            return this.cobro;
        }

        private void btnCambiarDireccion_Click(object sender, EventArgs e)
        {
            if (!ObjectUtils.isNull(txtDireccion.Text.Trim()))
            {
                this.error.Dispose();
                if (direccionActual.Equals(txtDireccion.Text.Trim()))
                {
                    this.Dispose();
                }
                else
                {
                    cobro = EditarDireccionClienteUseCase.editarDireccionCliente(txtDireccion.Text.Trim(), id, cobroDelcliente);
                    this.Dispose();
                }
            }
            else
            {
                this.error.SetError(this.txtDireccion, "Ingrese algun valor");
            }
        }
    }
}
