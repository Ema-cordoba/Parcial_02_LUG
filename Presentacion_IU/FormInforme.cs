using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using System.Windows.Forms.DataVisualization.Charting;

namespace Presentacion_IU
{
    public partial class FormInforme : Form
    {
        public FormInforme()
        {
            InitializeComponent();
            oBEDormitorio = new BEDormitorio();
            oBEOficina = new BEOficina();
            oBLLDormitorio = new BLLDormitorio();
            oBLLOficina = new BLLOficina();
        }

        BEDormitorio oBEDormitorio;
        BEOficina oBEOficina;

        BLLDormitorio oBLLDormitorio;
        BLLOficina oBLLOficina;

        void CargarChart()
        {
            Dictionary<string, int> ListaChart = new Dictionary<string, int>();

            foreach(BEDormitorio dormitorio in oBLLDormitorio.ListarTodo())
            {
                ListaChart.Add(dormitorio.Descripcion , Convert.ToInt32(dormitorio.Cantidad));
            }

            chart1.Titles.Clear();
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Add(new Title("Stock de muebles"));
            chart1.ChartAreas.Add(new ChartArea());

            Series serie = new Series("Muebles");
            serie.ChartType = SeriesChartType.Column;
            serie.Points.DataBindXY(ListaChart.Keys, ListaChart.Values);
            chart1.Series.Add(serie);
        }

        private void FormInforme_Load(object sender, EventArgs e)
        {
            CargarChart();
        }
    }
}
