using SCreditos.factory;
using SCreditos.usecase.contabilidad;
using System;
using System.Windows.Forms;

namespace SCreditos.views.dialogs
{
    public partial class AgregarGastoDiario : Form
    {
        private Double valor;

        private DateTime fecha;

        private String cobro;

        private String nombre;

        private String descripcion = null;

        public AgregarGastoDiario(String pFecha, String pCobro)
        {
            cobro = pCobro;
            InitializeComponent();
            dpkFecha.Text = pFecha;
            txtCobro.Text = cobro;
        }

        public Double getValor()
        {
            return this.valor;
        }

        public DateTime getFecha()
        {
            return this.fecha;
        }

        public String getNombre()
        {
            return this.nombre;
        }

        public String getDescripcion()
        {
            return this.descripcion;
        }

        public String getCobro()
        {
            return this.cobro;
        }

        private Boolean validarFormulario()
        {
            if (String.IsNullOrWhiteSpace(txtNombre.Text.Trim()) || String.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtValor.Text.Trim()) || String.IsNullOrEmpty(txtValor.Text.Trim()))
            {
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validarFormulario())
            {
                if (!ExisteContabilidadEnLaFecha.existe(this.getCobro(), new DateTime(dpkFecha.Value.Year, dpkFecha.Value.Month, dpkFecha.Value.Day).ToShortDateString()))
                {
                    this.fecha = new DateTime(dpkFecha.Value.Year, dpkFecha.Value.Month, dpkFecha.Value.Day);
                    this.nombre = txtNombre.Text.Trim().ToUpper();
                    this.valor = Convert.ToDouble(txtValor.Text);

                    if (!String.IsNullOrWhiteSpace(txtDescripcion.Text.Trim()) || !String.IsNullOrEmpty(txtDescripcion.Text.Trim()))
                    {
                        this.descripcion = txtDescripcion.Text.Trim().ToUpper();
                    }

                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("No es posible crear el gasto ya que en la fecha especificada existe contabilidad.", "No se pudo crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Faltan datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
