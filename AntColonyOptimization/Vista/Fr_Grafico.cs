using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntColonyOptimization.Vista
{
    public partial class Fr_Grafico : Form
    {
        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/

        
        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/
        private void Grafico_Load(object sender, EventArgs e)
        {

        }
        
        
        public Fr_Grafico()
        {
            InitializeComponent();
            grafica.Series.Clear();
        }
        public void crear_serie(String serie)
        {
            grafica.Series.Add(serie);
            grafica.Series[serie].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }
        public void crear_punto(int pos_serie, double x, double y)
        {
            grafica.Series[pos_serie].Points.AddXY(x, y);
            
        }
        private void Chart_Load(object sender, EventArgs e)
        {

        }
    }
}
