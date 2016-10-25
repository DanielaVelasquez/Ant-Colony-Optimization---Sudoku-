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
                    if (numeros.Contains(tablero[i,j]))
                        numeros.Remove(tablero[i,j]);
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
                    if (numeros.Contains(tablero[i,j]))
                        numeros.Remove(tablero[i,j]);
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
                            if (numeros.Contains(tablero[i + f,j + c]))
                                numeros.Remove(tablero[i + f,j + c]);
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
        /// <summary>
        /// Ubica un número en el tablero de sudoku si puede
        /// </summary>
        /// <param name="fila">fila para ubicar el número</param>
        /// <param name="col">columna para ubicar el número</param>
        /// <param name="num">número que se quiere ubicar</param>
        public void ubicar_numero_jugando(int fila, int col, int num)
        {
            if (puede_ubicar(fila, col, num))
                tablero[fila, col] = num;
            else
                throw new Exception("Número " + num + " repetido en fila, columna o cuadrante");
        }
        /// <summary>
        /// Ubica un número en el tablero sin revisar si es válido
        /// </summary>
        /// <param name="fila">fila para ubicar el número</param>
        /// <param name="col">columna para ubicar el número</param>
        /// <param name="num">número que se quiere ubicar</param>
        public void ubicar_numero(int fila,int col,int num)
        {
            tablero[fila, col] = num;
        }
        /// <summary>
        /// Determina si un numero se puede ubicar en una posición en el tablero
        /// </summary>
        /// <param name="fila">fila del tablero donde se quiere ubicar el número</param>
        /// <param name="col">columna del tablero donde se quiere ubicar el número</param>
        /// <param name="num">número se quiere ubicar el número</param>
        /// <returns>verdadero si el número se puede ubicar en el tablero, falso en caso contrario</returns>
        public Boolean puede_ubicar(int fila, int col,int num)
        {
            return !esta_fila(fila, num) && !esta_col(col, num) && !esta_cuadro(fila, col, num);
        }
        /// <summary>
        /// Determina si un número está en una fila 
        /// </summary>
        /// <param name="fila">número fila</param>
        /// <param name="num">número busca</param>
        /// <returns>verdadero si el número está en la fila, falso en caso contrario</returns>
        private Boolean esta_fila(int fila, int num)
        {
            for(int j = 0; j < n*n;j++)
            {
                if (tablero[fila, j] == num)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Determina si un número está en una columna 
        /// </summary>
        /// <param name="col">número columna</param>
        /// <param name="num">número busca</param>
        /// <returns>verdadero si el número está en la columna, falso en caso contrario</returns>
        private Boolean esta_col(int col, int num)
        {
            for(int i = 0;i<n*n;i++)
            {
                if (tablero[i, col] == num)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Determina si un valor está en el cuadro al que pertence el numero
        /// </summary>
        /// <param name="fila">fila tablero donde está ubicado el número</param>
        /// <param name="col">columna tablero donde está ubicado el número</param>
        /// <param name="num">numero que se busca en el tablero</param>
        /// <returns>verdadero si el numero está en el cuadro del tablero, falso en caso contrario</returns>
        private Boolean esta_cuadro(int fila,int col, int num)
        {
            int f = obtener_cuadrante(fila);
            int c = obtener_cuadrante(col);
            for(int i = 0; i<n*n;i++)
            {
                for(int j = 0; j< n*n;j++)
                {
                    if (tablero[i + fila, j + c] == num)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Obtiene el inicio del cuadrante dentro del cual está un valor de fila o columna
        /// </summary>
        /// <param name="valor">posicion fila o columna</param>
        /// <returns>inicio del cuadrante</returns>
        private int obtener_cuadrante(int valor)
        {
            for(int i = 0; i < n*n; i = i + n)
            {
                if (valor > i && valor < i + n)
                    return i;
            }
            return -1;
        }
    }
}
