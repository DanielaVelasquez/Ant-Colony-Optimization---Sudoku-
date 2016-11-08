using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyOptimization.Modelo_OCH;

namespace AntColonyOptimization.Modelo_Sudoku
{
    public class GestorSudoku : GestorProblema
    {
        /*-----------------------------------Constantes-----------------------------------*/
        /// <summary>
        /// Cantidad hormigas en la colonia
        /// </summary>
        private const int N = 50;
        /// <summary>
        /// Influencia sobre nivel de feromonas
        /// </summary>
        private const double ALFA = 0.3;
        /// <summary>
        /// Influencia atractivo movimiento
        /// </summary>
        private const double BETA = 1;
        /// <summary>
        /// Coeficiente evaporacion feromonas
        /// </summary>
        private const double RHO = 0.1;
        /// <summary>
        /// Cantidad inicial de feromonas
        /// </summary>
        public const double FEROMONAS_INICIAL = 0.1;
        /// <summary>
        /// Valor mínimo de desviacion de las soluciones de las hormigas
        /// </summary>
        public const double PORCENTAJE_HORMIGAS = 0.85;

        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Sudoku inicial que está gestionando  
        /// </summary>
        private Sudoku sudoku;
        /// <summary>
        /// Colonia hormigas
        /// </summary>
        private ColoniaHormigas colonia;

        /*-----------------------------------Métodos-----------------------------------*/
        public void set_sudoku(Sudoku s)
        {
            this.sudoku = s;
            crear_grafica_solucion(s);
        }
        private void crear_grafica_solucion(Sudoku s)
        {

        }
        public void ubicar_posicion_inicial(Random r, List<Hormiga> hormigas, Grafica grafica)
        {
            List<Componente> componentes = grafica.get_vertices();
            foreach (Hormiga k in hormigas)
            {
                int num = r.Next(0, componentes.Count);
                Componente inicio = componentes[num];
                Sudoku clone = (Sudoku)sudoku.Clone();
                k.set_solucion(clone);
                k.getSolucion().cambiar_vertice_actual(inicio);
            }
        }
        public Boolean completo(Solucion solucion)
        {
            return ((Sudoku)solucion).funcion_costo() == 0;
            //return ((Sudoku)solucion).completo();

        }
        public  List<Componente> configurar_vecinos(List<Componente> N, Hormiga k)
        {
            List<Componente> vecinos = new List<Componente>();
            List<Componente> vertices_solucion = k.getSolucion().get_grafica().get_vertices();

            //Sudoku s = k.getSolucion(
            foreach(Casilla v in vertices_solucion)
            {
                int cont = 0;
                while(cont < N.Count)
                {
                    Casilla c = (Casilla) N[cont];
                    /*if(c.get_fila()==0 && c.get_col()==0 && c.get_valor() == 5)
                    {
                        Console.WriteLine("llegue");
                    }*/
                    //Si la fila y columna ya están ocupadas
                    if (v.get_fila() == c.get_fila() && v.get_col() == c.get_col())
                        N.Remove(c);
                    //Si la fila o columna ya tiene el número 
                    else if((v.get_fila() == c.get_fila() || v.get_col() == c.get_col())&& c.get_valor() == v.get_valor())
                        N.Remove(c);
                    //Si estan en el mismo cuadrante y el número ya está en el cuadrante
                    else if(sudoku.obtener_cuadrante(v.get_fila())==sudoku.obtener_cuadrante(c.get_fila()) && sudoku.obtener_cuadrante(v.get_col())==sudoku.obtener_cuadrante(c.get_col()) && c.get_valor() == v.get_valor())
                        N.Remove(c);
                    else
                        cont++;
                }
                /*
                foreach(Casilla c in N)
                {
                    
                    if (!(v.get_fila() == c.get_fila() && v.get_col() == c.get_col()) && !vecinos.Contains(c))
                        vecinos.Add(c);
                    else
                        copia.Remove(c);
                }*/
            }
            return N;
        }

        /// <summary>
        /// Crea una gráfica a partir de un sudoku inicial
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public Grafica crear_grafica(Sudoku s)
        {
            List<Componente> componentes = new List<Componente>();
            int[,] tablero = s.get_tablero();
            int n = s.get_n();
            //Crea las casillas correspondientes
            for(int i = 0;i < n*n; i++)
            {
                for(int j = 0; j < n*n; j++)
                {
                    if(tablero[i,j] == Sudoku.VACIO)
                    {
                        for(int valor = 1; valor <=n*n;valor++)
                        {
                            Casilla c = new Casilla(i, j, valor);
                            componentes.Add(c);
                        }
                    }
                    else
                    {
                        Casilla c = new Casilla(i, j, tablero[i, j]);
                        componentes.Add(c);
                    }
                }
            }
            Grafica g = new Grafica();
            List<Transicion> transicion = new List<Transicion>();
            //Crea las aristas
            while(componentes.Count!=0)
            {
                Casilla actual = (Casilla) componentes[0];
                componentes.Remove(actual);
                foreach(Casilla casilla in componentes)
                {
                    transicion.Add(actual.crear_transicion_con(casilla));
                }
                g.adicionar_vertice(actual);
            }
            g.set_aristas(transicion);
            return g;
        }
        
        public Sudoku resolver(Sudoku s,int semilla)
        {
            sudoku = s;
            colonia = new ColoniaHormigas();
            Grafica grafica = crear_grafica(s);

            Grafica solucion = new Grafica();

            int[,] tablero = s.get_tablero();
            int n = s.get_n();
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    if(tablero[i,j]!=Sudoku.VACIO)
                    {
                        Casilla c = new Casilla(i, j, tablero[i, j]);
                        Casilla casilla = (Casilla) grafica.buscar(c);
                        solucion.adicionar_vertice(casilla.clonar_sin_vecinos());
                    }
                }
            }
            sudoku.set_grafica(solucion);

            return (Sudoku)colonia.optimizacion_colonia_hormigas(PORCENTAJE_HORMIGAS,semilla, FEROMONAS_INICIAL, ColoniaHormigas.VERTICES_FEROMONAS, ColoniaHormigas.MINIMIZAR, this, grafica, N, ALFA, BETA, RHO);

        }
        
    }
}
