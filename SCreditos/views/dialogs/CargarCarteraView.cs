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
    public partial class CargarCarteraView : Form
    {
        private List<Contabilidad> contabilidades;
        private List<Object> contabilidadesAGuardar;
        private Boolean gardado = false;


        public CargarCarteraView(String pCobro, List<Object> pContabilidades)
        {            
            contabilidades = new List<Contabilidad>();
            pContabilidades.ForEach(c =>
            {
                contabilidades.Add(c as Contabilidad);
            });

            InitializeComponent();

            lblCobro.Text = pCobro;
            cargarContabilidades();
        }

        public List<Object> getContabilidadesAGuardar()
        {
            return this.contabilidadesAGuardar;
        }

        public Boolean seGuardo()
        {
            return this.gardado;
        }

        private void cargarContabilidades()
        {
            if (ListValidators.validarListaVaciaONula(contabilidades))
            {
                MessageBox.Show("No hay contabilidades.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
            else
            {
                //tablaContabilidades.ColumnCount = 3;
                //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                //tablaContabilidades.Columns.Add(chk);
                //chk.HeaderText = "Check Data";
                //chk.Name = "chk";
                //tablaContabilidades.Columns[0].Name = "Product ID";
                //tablaContabilidades.Columns[1].Name = "Product Name";
                //tablaContabilidades.Columns[2].Name = "Product Price";
                //string[] row = new string[] { "1", "Product 1", "1000" };
                //tablaContabilidades.Rows.Add(row);
                //row = new string[] { "2", "Product 2", "2000" };
                //tablaContabilidades.Rows.Add(row);
                //row = new string[] { "3", "Product 3", "3000" };
                //tablaContabilidades.Rows.Add(row);
                //row = new string[] { "4", "Product 4", "4000" };
                //tablaContabilidades.Rows.Add(row);
                //tablaContabilidades.Rows[2].Cells[3].Value = true;

                tablaContabilidades.ColumnCount = 8;
                tablaContabilidades.Columns[0].Name = "FECHA";
                tablaContabilidades.Columns[1].Name = "TARJETAS";
                tablaContabilidades.Columns[2].Name = "COBRO";
                tablaContabilidades.Columns[3].Name = "PRESTO";
                tablaContabilidades.Columns[4].Name = "UTILIDAD";
                tablaContabilidades.Columns[5].Name = "GASTOS";
                tablaContabilidades.Columns[6].Name = "OTROS GASTOS";
                tablaContabilidades.Columns[7].Name = "ESTADO";

                contabilidades.Sort((p, q) => DateTime.Compare(p.getFecha(), q.getFecha()));

                cboFechaInicial.Items.Add(contabilidades[0].getFecha().ToShortDateString());
                cboFechaInicial.SelectedIndex = 0;

                contabilidades.ForEach(c =>
                {
                    cboFechaFinal.Items.Add(c.getFecha().ToShortDateString());
                    tablaContabilidades.Rows.Add(new String[] {
                                                                c.getFecha().ToShortDateString(),
                                                                c.getTarjetas().ToString(),
                                                                c.getCobro().ToString(),
                                                                c.getPresto().ToString(),
                                                                c.getUtilidad().ToString(),
                                                                c.getGastos().ToString(),
                                                                c.getOtrosGastos().ToString(),
                                                                c.getEstado()
                    });
                });

                cboFechaFinal.SelectedIndex = 0;

            }
        }

        private void sacarContabilidadesAGuardar()
        {
            if(MessageBox.Show("¿ Estas seguro ?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<Contabilidad> con = contabilidades.FindAll(c => c.getFecha() >= DateTime.Parse(cboFechaInicial.Text) && c.getFecha() <= DateTime.Parse(cboFechaFinal.Text));
                contabilidadesAGuardar = new List<Object>();

                con.ForEach(co =>
                {
                    contabilidadesAGuardar.Add(co as Object);
                });

                gardado = true;
                this.Dispose();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            sacarContabilidadesAGuardar();
        }
    }
}
