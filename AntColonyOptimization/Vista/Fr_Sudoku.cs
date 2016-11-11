using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntColonyOptimization.Modelo_Sudoku;
using System.IO;
using AntColonyOptimization.Modelo_OCH;
using System.Threading;

namespace AntColonyOptimization.Vista
{
    public partial class Fr_Sudoku : Form
    {
        /*-----------------------------------Constantes-----------------------------------*/
        private static char separador = ',';
        private const int MAX_CASILLAS_VACIAS = 64;
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Casillas del tablero del sudoku
        /// </summary>
        private RichTextBox[,] casillas;
        /// <summary>
        /// Tamaño tablero
        /// </summary>
        private int n;
        /// <summary>
        /// Controlador 
        /// </summary>
        private GestorSudoku controlador;
        /// <summary>
        /// Sudoku en pantalla
        /// </summary>
        private Sudoku sudoku;
        /// <summary>
        /// Colonia presentada en pantalla;
        /// </summary>
        private ColoniaHormigas colonia;
        /*-----------------------------------Métodos-----------------------------------*/
        public Fr_Sudoku()
        {
            n = 3;
            sudoku = new Sudoku(n);
            InitializeComponent();
            crear_tablero();
            colorear_tablero();
            controlador = new GestorSudoku();
            btn_graficas.Enabled = false;
        }
        private void resolver()
        {
            n = 3;
            //int[,] tablero = new int[n * n, n * n];
            for(int i = 0; i<100;i++)
            {
                //Sudoku s = crear_sudoku("5,3,1,0,8,0,6,0,0,0,0,0,4,0,6,0,0,0,0,7,0,0,0,2,8,5,0,8,0,2,7,3,0,0,1,0,7,0,0,5,0,0,0,9,0,3,4,0,0,6,0,0,0,0,0,6,9,8,0,0,0,0,0,0,5,0,0,4,1,0,0,7,0,0,0,2,0,0,4,0,3");
                Sudoku s = new Sudoku(n);
                controlador.resolver(s, i);
                ColoniaHormigas colonia = controlador.getColonias();
                Solucion sol = colonia.get_mejor();
                Console.WriteLine(i+", "+sol.funcion_costo()+","+colonia.get_tiempo().ToString());
                /*Console.WriteLine(colonia.ToString());
                
                Console.WriteLine(sol.ToString());
                Console.*/
            }
            
        }
        private Sudoku leer_sudoku(String cad,int n)
        {
            String[] sep = cad.Split(',');
            int cont = 0;
            Sudoku s = new Sudoku(n);
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    int num = int.Parse(sep[cont]);
                    if(num != Sudoku.VACIO)
                        s.ubicar_numero_jugando(i, j,num );
                    cont++;
                }
            }
            return s;
           
            
        }
        private void crear_tablero()
        {
            int ancho = (panel_tablero.Size.Width/(n*n));
            casillas = new RichTextBox[n*n, n*n];
            for (int i = 0; i < n *n ; i++ )
            {
                for(int j = 0; j< n*n ;j++)
                {
                    RichTextBox casilla = new RichTextBox();
                    casilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    casilla.Location = new System.Drawing.Point(i*ancho,j*ancho);
                    casilla.Size = new System.Drawing.Size(ancho,ancho );
                    casilla.Name = j+""+separador+i;
                    casilla.KeyUp += new System.Windows.Forms.KeyEventHandler(this.casilla_selecciona);
                    casillas[j, i] = casilla;
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
            KeyEventArgs key = (KeyEventArgs) e;
            RichTextBox casilla = (RichTextBox)sender;
            String[] posiciones = casilla.Name.Split(separador);
            int i = int.Parse(posiciones[0]);
            int j = int.Parse(posiciones[1]);

            if(key.KeyCode == Keys.Back || key.KeyCode == Keys.Delete)
            {
                sudoku.ubicar_numero(i, j, Sudoku.VACIO);
            }
            else if(key.KeyCode == Keys.Enter)
            {
                casilla.Text = "";
            }
            else
            {
                try
                {
                    String nombre = "Casilla";
                    int num = obtener_numero(casilla.Text, nombre);
                    if (num <= 0 || num > n * n)
                    {
                        throw new Exception("Valor ingresado incorrecto, sudoku solo admite número: " + 1 + "-" + (n * n));
                    }
                    sudoku.ubicar_numero_jugando(i, j, num);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    casilla.Text = "";
                }
            }
        }
        private int obtener_numero(String texto,String nombre)
        {
            try
            {
                return int.Parse(texto);
            }
            catch
            {
                throw new Exception("Valor no numérico ingresado en "+nombre);
            }
        }
        
       
        private void lb_limpiar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            sudoku = new Sudoku(n);
            for(int i = 0; i< n*n;i++)
            {
                for(int j = 0;j<n*n;j++)
                {
                    casillas[i, j].Text = "";
                }
            }
            txt_tiempo.Text = "";
            ls_casillas.Items.Clear();
            btn_graficas.Enabled = false;
            colonia = null;
        }
        private void pintar(Sudoku s)
        {
            Console.WriteLine(s.ToString());
            int[,] tablero = s.get_tablero();
            for(int i = 0; i< n*n;i++)
            {
                for(int j = 0; j< n*n; j++)
                {
                    if (tablero[i, j] != Sudoku.VACIO)
                        casillas[i, j].Text = ""+tablero[i, j];
                }
            }
        }
        private void btn_archivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ventana = new OpenFileDialog();
            Stream myStream = null;
            ventana.InitialDirectory = "c:\\desktop";
            ventana.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ventana.FilterIndex = 2;

            if (ventana.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = ventana.OpenFile()) != null)
                    {
                        String nombre = ventana.FileName;
                        String[] texto = File.ReadAllLines(nombre);
                        if (texto.Length > 1)
                            throw new Exception("Formato del archivo incorrecto, deber ser una linea separando cada valor por " + separador);
                        limpiar();
                        String cad = texto[0];
                        sudoku = leer_sudoku(cad, n);
                        pintar(sudoku);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    limpiar();
                }
            }
        }
        private void colorear_tablero()
        {
            int cont = 0;
            for(int i = 0; i < n*n; i = i + n)
            {
                for(int j = 0; j < n*n ;j = j + n)
                {

                    for(int f = 0; f<n;f++)
                    {
                        for( int c = 0; c < n; c++)
                        {
                            RichTextBox casilla = casillas[i + f, j + c];
                            if (cont % 2 == 0)
                            {
                                casilla.BackColor = System.Drawing.SystemColors.ActiveCaption;
                            }
                            else
                                casilla.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                        }
                    }
                    cont++;
                }
            }
        }
        private void pintar_colonia(ColoniaHormigas c)
        {
            
            sudoku = (Sudoku)c.get_mejor();
            if (sudoku != null)
                pintar(sudoku);
            
            TimeSpan t = c.get_tiempo();
            txt_tiempo.Text = "" + t.Hours + ":" + t.Minutes + ":" + t.Seconds + ":" + t.Milliseconds;
            List<Componente> vertices = c.get_grafica().get_vertices();
            ls_casillas.Items.Clear();
            ls_casillas.Items.AddRange(vertices.ToArray());
        }
        private void btn_simular_Click(object sender, EventArgs e)
        {
            try
            {
                int semilla = obtener_numero(txt_semilla.Text," campo valor de la semilla");
                Thread hilo = controlador.resolver(sudoku, semilla);
                colonia = controlador.getColonias();
                while(hilo.IsAlive)
                {
                    this.Refresh();
                    if ((sudoku = (Sudoku)colonia.get_solucion_actual()) != null)
                    {
                        pintar(sudoku);
                        Console.WriteLine(sudoku.ToString());
                    }

                    //pintar_colonia(colonia);
                    /*List<Componente> vertices = colonia.get_grafica().get_vertices();
                    ls_casillas.Items.Clear();
                    ls_casillas.Items.AddRange(vertices.ToArray());*/
                    Thread.Sleep(2000);
                }
                
                pintar_colonia(colonia);
               
                btn_graficas.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
                
        }

        private void btn_graficas_Click(object sender, EventArgs e)
        {
            if(colonia!=null)
            {
                List<ResultadoOCH> resultados = colonia.getResultados();
                int cantHormigas = colonia.getCantidadHormigas();
                Fr_Grafico fr_grafico = new Fr_Grafico();
                for(int k = 1; k<=cantHormigas;k++)
                {
                    fr_grafico.crear_serie("Hormiga " + k);
                }
                foreach(ResultadoOCH r in resultados)
                {
                    fr_grafico.crear_punto(r.getHormiga() -1, r.getIteracion(), r.getFuncionCosto());
                }
                fr_grafico.Show();
            }
        }

       
    }
}
