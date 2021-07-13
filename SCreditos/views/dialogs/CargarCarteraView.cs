using SCreditos.factory;
using SCreditos.models;
using SCreditos.usecase.cartera;
using SCreditos.usecase.contabilidad;
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
        private Boolean guardado = false;
        private String cobro;
        private Cobro cobroActual;


        public CargarCarteraView(String pCobro, List<Object> pContabilidades)
        {            
            this.contabilidades = new List<Contabilidad>();
            this.cobro = pCobro;
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
            return this.guardado;
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

        public Object getCobro()
        {
            return this.cobroActual;
        }

        private void sacarContabilidadesAGuardar()
        {
            List<Contabilidad> con = contabilidades.FindAll(c => c.getFecha() >= DateTime.Parse(cboFechaInicial.Text) && c.getFecha() <= DateTime.Parse(cboFechaFinal.Text));
            Cartera ultimaCartera = ConsultarCarterasUseCase.consultarUltimaCartera(this.cobro);
            int tarjetas = ultimaCartera.getTarjetas() + con.Sum(c => c.getTarjetas());
            Double cobro = con.Sum(c => c.getCobro());
            Double presto = con.Sum(c => c.getPresto());
            Double utilidad = con.Sum(c => c.getUtilidad());
            Double valorBase = ultimaCartera.getCaja();
            Double efectivo = cobro - presto + valorBase;
            Double gastos = con.Sum(c => c.getGastos() + c.getOtrosGastos());
            Double caja = efectivo;
            Double cartera = ultimaCartera.getCartera() + (utilidad + valorBase) - (efectivo + gastos);

            Cartera carteraNueva = new Cartera();
            carteraNueva.setNombreCobro(this.cobro);
            carteraNueva.setFechaInicio(cboFechaInicial.Text);
            carteraNueva.setFechaFinal(cboFechaFinal.Text);
            carteraNueva.setTarjetas(tarjetas);
            carteraNueva.setCobro(cobro);
            carteraNueva.setPresto(presto);
            carteraNueva.setUtilidad(utilidad);
            carteraNueva.setBase(valorBase);
            carteraNueva.setEfectivo(efectivo);
            carteraNueva.setGastos(gastos);
            carteraNueva.setCaja(caja);
            carteraNueva.setCartera(cartera);

            ConfirmacionGuardarCarteraView confirmacionGuardarCarteraView = new ConfirmacionGuardarCarteraView(carteraNueva as Object);
            confirmacionGuardarCarteraView.ShowDialog();

            if (confirmacionGuardarCarteraView.getAprobo())
            { 
                List<Contabilidad> contabilidadesGuardadas = GuardarContabilidadesUseCase.guardarContabilidades(con, this.cobro);
                this.cobroActual = ConsultarCarterasUseCase.guardarCartera(carteraNueva);

                guardado = true;
                this.Dispose();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            sacarContabilidadesAGuardar();
        }
    }
}
