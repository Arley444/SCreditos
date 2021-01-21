using SCreditos.models;
using SCreditos.usecase.cartera;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SCreditos.views.dialogs
{
    public partial class CarteraTirilla : Form
    {
        private List<Cartera> listaCarteras;

        public CarteraTirilla(String pCobro)
        {
            InitializeComponent();

            listaCarteras = ConsultarCarterasUseCase.consultarCarteras(pCobro);


            tablaCarteras.ColumnCount = 10;
            tablaCarteras.Columns[0].Name = "FECHA";
            tablaCarteras.Columns[1].Name = "TARJETAS";
            tablaCarteras.Columns[2].Name = "COBRÓ";
            tablaCarteras.Columns[3].Name = "PRESTO";
            tablaCarteras.Columns[4].Name = "UTILIDAD";
            tablaCarteras.Columns[5].Name = "BASE";
            tablaCarteras.Columns[6].Name = "EFECTIVO";
            tablaCarteras.Columns[7].Name = "GASTOS";
            tablaCarteras.Columns[8].Name = "CARTERA";
            tablaCarteras.Columns[9].Name = "CAJA";

            foreach (Cartera cartera in listaCarteras)
            {
                Console.WriteLine(cartera.getCartera());
                tablaCarteras.Rows.Add(
                    new string[]
                    {
                        cartera.getFechaInicio() + " / " + cartera.getFechaFinal(),
                        cartera.getTarjetas().ToString(),
                        cartera.getCobro().ToString(),
                        cartera.getPresto().ToString(),
                        cartera.getUtilidad().ToString(),
                        cartera.getBase().ToString(),
                        cartera.getEfectivo().ToString(),
                        cartera.getGastos().ToString(),
                        cartera.getCartera().ToString(),
                        cartera.getCaja().ToString()
                    });
            }
        }
    }
}
