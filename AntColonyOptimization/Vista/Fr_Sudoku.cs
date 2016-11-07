using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntColonyOptimization.Controlador;
using AntColonyOptimization.Modelo_Sudoku;

namespace AntColonyOptimization.Vista
{
    public partial class Fr_Sudoku : Form
    {
        /*-----------------------------------Constantes-----------------------------------*/
        private static char separador = ',';
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Casillas del tablero del sudoku
        /// </summary>
        private TextBox[,] casillas;
        /// <summary>
        /// Tamaño tablero
        /// </summary>
        private int n;
        /// <summary>
        /// Controlador 
        /// </summary>
        private SudokuOCH controlador;
        /*-----------------------------------Métodos-----------------------------------*/
        public Fr_Sudoku()
        {
            n = 3;
            InitializeComponent();
            crear_tablero();
            disponible_conjunto(false);
            controlador = SudokuOCH.get_instance();
            resolver();
        }
        private void resolver()
        {
            n = 3;
            //int[,] tablero = new int[n * n, n * n];
            for(int i = 0; i<100;i++)
            {
                Sudoku s = crear_sudoku("5,3,1,0,8,0,6,0,0,0,0,0,4,0,6,0,0,0,0,7,0,0,0,2,8,5,0,8,0,2,7,3,0,0,1,0,7,0,0,5,0,0,0,9,0,3,4,0,0,6,0,0,0,0,0,6,9,8,0,0,0,0,0,0,5,0,0,4,1,0,0,7,0,0,0,2,0,0,4,0,3");
                Sudoku solucion = controlador.resolver(n, s, i);
                if (solucion.funcion_costo() == 0)
                    Console.WriteLine("I'm amazing");
                Console.WriteLine(solucion.ToString());
            }
            
        }
        private Sudoku crear_sudoku(String cad)
        {
            String[] sep = cad.Split(',');
            int cont = 0;
            int n = 3;
            Sudoku s = new Sudoku(n);
            for(int i = 0; i<n*n;i++)
            {
                for(int j = 0; j < n*n; j++)
                {
                    s.ubicar_numero(i, j, int.Parse(sep[cont]));
                    cont++;
                }
            }
            return s;
        }
        private void crear_tablero()
        {
            int ancho = (panel_tablero.Size.Width/(n*n));
            casillas = new TextBox[n*n, n*n];
            for (int i = 0; i < n *n ; i++ )
            {
                for(int j = 0; j< n*n ;j++)
                {
                    TextBox casilla = new TextBox();
                    casilla.Location = new System.Drawing.Point(i*ancho,j*ancho);
                    casilla.Size = new System.Drawing.Size(ancho - (n *n), ancho*n );
                    casilla.Name = i+""+separador+j;
                    casilla.KeyUp += new System.Windows.Forms.KeyEventHandler(this.casilla_selecciona);
                    casillas[i, j] = casilla;
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
        private void casilla_selecciona(object sender, EventArgs e)
        {
            TextBox casilla = (TextBox)sender;
            String[] posiciones = casilla.Name.Split(separador);
            int i = int.Parse(posiciones[0]);
            int j = int.Parse(posiciones[1]);

            Console.WriteLine("casilla " + casilla.Name);
        }
        private void ckbox_unitario_CheckedChanged(object sender, EventArgs e)
        {
            disponible_conjunto(!ckbox_unitario.Checked);
            ckbox_conjunto.Checked = !ckbox_unitario.Checked;            
        }
        private void disponible_conjunto(bool valor)
        {
            txt_cant_semillas.Enabled = valor;
            txt_inicio.Enabled = valor;
            txt_paso.Enabled = valor;
            ls_resultados.Enabled = valor;

            txt_semilla.Enabled = !valor;
        }
        private void ckbox_conjunto_CheckedChanged(object sender, EventArgs e)
        {
            disponible_conjunto(ckbox_conjunto.Checked);
            ckbox_unitario.Checked = !ckbox_conjunto.Checked; 
        }
    }
}
