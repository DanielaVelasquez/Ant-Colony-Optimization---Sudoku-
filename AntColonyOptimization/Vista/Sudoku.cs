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
    public partial class Sudoku : Form
    {
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Casillas del tablero del sudoku
        /// </summary>
        private TextBox[,] casillas;
        /// <summary>
        /// Tamaño tablero
        /// </summary>
        private int n;
        /*-----------------------------------Métodos-----------------------------------*/
        public Sudoku()
        {
            n = 3;
            InitializeComponent();
            crear_tablero();
        }
        private void crear_tablero()
        {
            int ancho = panel_tablero.Size.Width;
            for (int i = 0; i < n *n ; i++ )
            {
                for(int j = 0; i< n*n ;j++)
                {
                    TextBox casilla = new TextBox();
                    casilla.Location = new System.Drawing.Point(i+1,j+1);
                    casilla.Size = new System.Drawing.Size(ancho, ancho);
                    this.panel_tablero.Controls.Add(casilla);
                }
            }
                
        }
        private void lb_tamanio_tablero_Click(object sender, EventArgs e)
        {

        }

        private void Sudoku_Load(object sender, EventArgs e)
        {

        }
    }
}
