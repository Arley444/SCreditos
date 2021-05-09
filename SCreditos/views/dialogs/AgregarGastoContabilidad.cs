using SCreditos.factory;
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
        private Double valorGasto;
        private DateTime fecha;
        private String descripcion;

        private Contabilidad contabilidad;

        public AgregarGastoContabilidad(Object pContabilidad, DateTime pFecha, String pCobro)
        {
            contabilidad = pContabilidad as Contabilidad;
            this.fecha = pFecha;
            InitializeComponent();
            txtFecha.Text = pFecha.ToShortDateString();
            txtCobro.Text = pCobro;

        }

        private void agregarGasto()
        {
            if (CampoFactory.isNull(this.txtValorGasto.Text.Trim()) || this.txtValorGasto.Text.Trim().Equals("0"))
            {
                this.errorValorGasto.SetError(this.txtValorGasto, "Ingrese un valor valido.");
            }
            else
            {
                if (CampoFactory.isNull(this.txtDescripcion.Text.Trim()))
                {
                    this.errorDescripcionGasto.SetError(this.txtDescripcion, "Ingrese un valor valido.");
                    this.txtDescripcion.Focus();
                }
                else
                {
                    this.valorGasto = Double.Parse(this.txtValorGasto.Text);
                    this.agrego = true;
                    this.descripcion = this.txtDescripcion.Text.Trim();
                    this.errorValorGasto.Dispose();
                    this.Dispose();
                }                
            }           
        }

        public Double getValorGasto()
        {
            return this.valorGasto;
        }

        public Boolean getAgrego()
        {
            return this.agrego;
        }

        public DateTime getFecha()
        {
            return this.fecha;
        }

        public String getDescripcionGasto()
        {
            return this.descripcion;
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarGasto();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtValorGasto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                agregarGasto();                
            }
            else if (e.KeyCode == Keys.Back)
            {

            }
            else
            {
                if (!CampoFactory.isNumeric(this.txtValorGasto.Text.Trim()))
                {
                    this.errorValorGasto.SetError(this.txtValorGasto, "Solo valores numéricos.");

                    if (!CampoFactory.isNull(this.txtValorGasto.Text.Trim()))
                    {
                        this.txtValorGasto.Text = this.txtValorGasto.Text.Trim().Remove(this.txtValorGasto.Text.Trim().Length - 1);
                        this.txtValorGasto.Select(this.txtValorGasto.Text.Length, 0);
                    }
                }
                else
                {
                    this.errorValorGasto.Dispose();
                }
            }
        }
    }
}
