using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyOptimization.Modelo_OCH;

namespace AntColonyOptimization.Modelo_Sudoku
{
    public class Sudoku:Solucion
    {   
        
        
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Tablero sudoku
        /// </summary>
        private int[,] tablero;
        /// <summary>
        /// Tamaño del tablero
        /// </summary>
        private int n;

        /*-----------------------------------Métodos-----------------------------------*/
        public Sudoku(int n)
        {
            this.n = n;
            tablero = new int[this.n, this.n];
        }
        public override double funcion_costo()
        {
            return repetidos_filas() + repetidos_columnas() + repetidos_cuadros();
        }
        /// <summary>
        /// Contabiliza la cantidad de números repetidos en las filas del tablero
        /// </summary>
        /// <returns>cantidad números repetidos en filas</returns>
        private int repetidos_filas()
        {
            int filas = 0;
            
            for(int i = 0; i < n*n; i++)
            {
                List<int> numeros = crear_lista_valores();
                for(int j=0; j< n*n;j++)
                {
                    if (numeros.Contains(tablero[i][j]))
                        numeros.Remove(tablero[i][j]);
                }
                filas += numeros.Count;
            }
            return filas;
        }
        /// <summary>
        /// Contabiliza la cantidad de números repetidos en las columnas del tablero
        /// </summary>
        /// <returns>cantidad números repetidos en columnas</returns>
        private int repetidos_columnas()
        {
            int columnas = 0;
            for(int j = 0; j< n*n; j++)
            {
                List<int> numeros = crear_lista_valores();
                for(int i = 0; i< n*n; i++)
                {
                    if (numeros.Contains(tablero[i][j]))
                        numeros.Remove(tablero[i][j]);
                }
                columnas += numeros.Count;
            }
            return columnas;
        }
        /// <summary>
        /// Contabiliza la cantidad de números repetidos en los cuadros del tablero
        /// </summary>
        /// <returns>cantidad números repetidos en cuadros</returns>
        private int repetidos_cuadros()
        {
            int cuadros = 0;
            for(int f = 0; f < n*n; f = f + n)
            {
                for(int c = 0; c < n*n; c = c+n)
                {
                    for(int i = 0; i <n;i++)
                    {
                        List<int> numeros = crear_lista_valores();
                        for(int j = 0; j< n; j++)
                        {
                            if (numeros.Contains(tablero[i + f][j + c]))
                                numeros.Remove(tablero[i + f][j + c]);
                        }
                        cuadros += numeros.Count;
                    }
                }
            }
            return cuadros;
        }
        /// <summary>
        /// Crea una lista de los posibles valores que puede tener cada fila, columna y cuadro del tablero
        /// </summary>
        /// <returns>lista de los posibles valores del juego</returns>
        private List<int> crear_lista_valores()
        {
            
            List<int> numeros = new List<int>();
            for (int i = 0; i < n * n; i++)
                numeros.Add(i);
            
            return numeros;
        }
    }
}
