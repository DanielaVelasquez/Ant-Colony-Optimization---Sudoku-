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
        public void configurar_grafica(Grafica g, Hormiga k)
        {
            Componente c = k.getSolucion().get_vertice_actual();
            g.eliminar_vertice(c);
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
            return g;
        }
    }
}
