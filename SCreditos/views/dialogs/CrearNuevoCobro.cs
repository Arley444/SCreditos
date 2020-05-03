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
    public partial class CrearNuevoCobro : Form
    {
        private Boolean seCreo = false;


        public CrearNuevoCobro()
        {
            InitializeComponent();
        }

        private Boolean validarFormulario()
        {
            Boolean valido = true;

            if (String.IsNullOrEmpty(txtNombre.Text.Trim()) | String.IsNullOrWhiteSpace(txtNombre.Text.Trim()))
            {
                valido = false;
            }

            if (String.IsNullOrEmpty(txtCapital.Text.Trim()) | String.IsNullOrWhiteSpace(txtCapital.Text.Trim()))
            {
                valido = false;
            }

            return valido;
        }

        private void setCreo(Boolean pSecreo)
        {
            this.seCreo = pSecreo;
        }

        public Boolean getSeCreo()
        {
            return this.seCreo;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (validarFormulario())
            {
                Cobro cobro = new Cobro();
                cobro.setNombre(txtNombre.Text.Trim().ToUpper());
                cobro.setCapital(Int32.Parse(txtCapital.Text.Trim()));

                if (cobro.validarCobro() == null)
                {
                    seCreo = true;                    
                    MessageBox.Show("El cobro se creo con exitos.");
                    this.Close();
                }
                else if (cobro.validarCobro().Equals("Se cancelo la creacion del cobro."))
                {

                }
                else
                {
                    MessageBox.Show(cobro.validarCobro(), "Error");
                }
            }
            else
            {
                MessageBox.Show("Todos los datos son necesarios.");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
