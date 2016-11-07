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
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Sudoku inicial que está gestionando  
        /// </summary>
        private Sudoku sudoku;

        /*-----------------------------------Métodos-----------------------------------*/
        public void set_sudoku(Sudoku s)
        {
            this.sudoku = s;
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
            return ((Sudoku)solucion).completo();

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
                    if (v.get_fila() == c.get_fila() && v.get_col() == c.get_col())
                        N.Remove(c);
                    else
                        cont++;
                    /*
                    if (!(v.get_fila() == c.get_fila() && v.get_col() == c.get_col()))
                    {
                        if(!vecinos.Contains(c))
                            vecinos.Add(c);
                        cont++;
                    }
                    else
                        N.Remove(c);
                     * */
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
                }
            }
            Grafica g = new Grafica();
            //Crea las aristas
            while(componentes.Count!=0)
            {
                Casilla actual = (Casilla) componentes[0];
                componentes.Remove(actual);
                foreach(Casilla casilla in componentes)
                {
                    actual.crear_transicion_con(casilla);
                }
                g.adicionar_vertice(actual);
            }
            foreach(Componente c in g.get_vertices())
            {
                if (c.N().Count >= 729)
                    Console.WriteLine("MAL");
            }
            return g;
        }
    }
}
