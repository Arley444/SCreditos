using SCreditos.models;
using SCreditos.models.common;
using SCreditos.usecase.abono;
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
    public partial class EliminarAbonoView : Form
    {
        private List<Abono> abonos;
        private Abono abono;
        private Prestamo prestamo;
        private Contabilidad contabilidad;
        private String cobro;
        private Cobro cobroActual = null;

        public EliminarAbonoView(String pCobro, Object pAbono, List<Object> pAbonos, Object pPrestamo, Object pContabilidad)
        {
            abonos = new List<Abono>();
            pAbonos.ForEach(a =>
            {
                abonos.Add(a as Abono);
            });
            abono = pAbono as Abono;
            contabilidad = pContabilidad as Contabilidad;
            prestamo = pPrestamo as Prestamo;
            cobro = pCobro;

            InitializeComponent();

            txtFecha.Text = abono.getFecha().ToShortDateString();
            txtValorPago.Text = abono.getValor().ToString();
            txtValorRestante.Text = abono.getRestante().ToString();

            abonos.ForEach(a => Console.WriteLine("Fecha: " + a.getFecha() + " Valor " + a.getValor()));
        }

        public Object getCobroActual()
        {
            return this.cobroActual;
        }

        private void btnEliminarAbono_MouseEnter(object sender, EventArgs e)
        {
            btnEliminarAbono.BackColor = System.Drawing.Color.Red;
        }

        private void btnEliminarAbono_MouseLeave(object sender, EventArgs e)
        {
            btnEliminarAbono.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnEliminarAbono_Click(object sender, EventArgs e)
        {
            if (contabilidad.getEstado().Equals(TipoEstados.NO_GUARDADO))
            {
                if(MessageBox.Show("Realmente deseas eliminar el abono.", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cobro c = EliminarAbonoUseCase.eliminarAbono(cobro, abono, prestamo, contabilidad);
                    this.cobroActual = AumentarValorRestanteAbonoUseCase.aumentarValorRestanteAbono(cobro, abonos, abono.getValor());

                    MessageBox.Show("Se elimino el abono correctamente.", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show("No se puede eliminar el abono, ya que la contabilidad se guardo.", "No Se Puede", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
