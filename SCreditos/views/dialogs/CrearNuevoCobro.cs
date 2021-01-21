using SCreditos.factory;
using SCreditos.models;
using SCreditos.usecase.cobro;
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
        // ---------------------------------------------------------------------------------------------------------------------------------
        //  ATRIBUTOS
        // ---------------------------------------------------------------------------------------------------------------------------------
        private Boolean seCreo = false;

        private Cobro cobro = null;

        private List<Cobro> l;

        // ---------------------------------------------------------------------------------------------------------------------------------
        //  CONSTRUCTORES
        // ---------------------------------------------------------------------------------------------------------------------------------
        public CrearNuevoCobro(Object o)
        {
            InitializeComponent();

            l = o as List<Cobro>;
        }


        // ---------------------------------------------------------------------------------------------------------------------------------
        //  METODOS
        // ---------------------------------------------------------------------------------------------------------------------------------
        private Boolean validarFormulario()
        {
            Boolean valido = true;

            if (CampoFactory.isNull(txtNombre.Text.Trim()))
            {
                valido = false;
            }

            if (CampoFactory.isNull(txtCapital.Text.Trim()))
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

        public Object getCobro()
        {
            return this.cobro as Object;
        }

        // ---------------------------------------------------------------------------------------------------------------------------------
        //  EVENTOS
        // ---------------------------------------------------------------------------------------------------------------------------------

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (validarFormulario())
            {
                if (ObjectUtils.isNull(l))
                {
                    if (MessageBox.Show("Deseas crear el cobro:" +
                        "\nNOMBRE: " + txtNombre.Text.Trim().ToUpper() + "" +
                        "\nCAPITAL: " + txtCapital.Text.Trim() + " Domingos" +
                        "\nFECHA INICIO: " + dpkFechaInicio.Value.ToShortDateString() + "", "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cobro = new Cobro();
                        cobro.setNombre(txtNombre.Text.Trim().ToUpper());
                        cobro.setCapital(Int32.Parse(txtCapital.Text.Trim()));
                        cobro.setFechaInicio(new DateTime(dpkFechaInicio.Value.Year, dpkFechaInicio.Value.Month, dpkFechaInicio.Value.Day));

                        cobro = CrearNuevoCobroUseCase.crearNuevoCobro(cobro);
                    }
                }
                else
                {
                    if (!l.Exists(c => c.getNombre().Equals(txtNombre.Text.Trim().ToUpper())))
                    {
                        if (MessageBox.Show("Deseas crear el cobro:" +
                            "\nNOMBRE: " + txtNombre.Text.Trim().ToUpper() + "" +
                            "\nCAPITAL: " + txtCapital.Text.Trim() + " Domingos" +
                            "\nFECHA INICIO: " + dpkFechaInicio.Value.ToShortDateString() + "", "CONFIRMACIÓN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            cobro = new Cobro();
                            cobro.setNombre(txtNombre.Text.Trim().ToUpper());
                            cobro.setCapital(Int32.Parse(txtCapital.Text.Trim()));
                            cobro.setFechaInicio(new DateTime(dpkFechaInicio.Value.Year, dpkFechaInicio.Value.Month, dpkFechaInicio.Value.Day));

                            cobro = CrearNuevoCobroUseCase.crearNuevoCobro(cobro);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El cobro: " +
                            "\nNOMBRE: " + txtNombre.Text.Trim().ToUpper() + "" +
                            "\nCAPITAL: " + txtCapital.Text.Trim() + " Domingos" +
                            "\nFECHA INICIO: " + dpkFechaInicio.Value.ToShortDateString() +
                            "\n\n YA EXISTE.");
                    }
                }                

                if (!ObjectUtils.isNull(cobro))
                {
                    seCreo = true;
                    MessageBox.Show("El cobro se creo con exitos.");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Todos los datos son necesarios.");
            }
        }
    }
}
