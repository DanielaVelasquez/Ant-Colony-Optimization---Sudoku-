using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyOptimization.Modelo_OCH;
using AntColonyOptimization.Complemento;

namespace AntColonyOptimization.Modelo_Sudoku
{
    [Serializable]
    public class Casilla:Componente
    {
        /*-----------------------------------Constantes-----------------------------------*/
        private const int NORMAL = 3;
        private const int BUENO = 7;
        private const int MUY_BUENO = 12;
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Fila a la que pertenece la casilla
        /// </summary>
        private int fila;
        /// <summary>
        /// Columna a la cual pertenece la casilla
        /// </summary>
        private int col;
        /// <summary>
        /// Número asociado a la casilla
        /// </summary>
        private int valor;

        /*-----------------------------------Métodos-----------------------------------*/
        public Casilla(int fila,int col,int valor)
        {
            this.fila = fila;
            this.col = col;
            this.valor = valor;
        }
        
        public int get_fila()
        {
            return fila;
        }
        public int get_col()
        {
            return col;
        }
        public int get_valor()
        {
            return valor;
        }

        public override double calcular_atractivo(Solucion s)
        {
            Sudoku sudoku = (Sudoku) s;
            int n = sudoku.get_n();
            int[,] tablero = sudoku.get_tablero();
            atractivo = 0;
            //Si la casilla en el sudoku está vacia
            if (tablero[fila, col] == Sudoku.VACIO)
                atractivo += MUY_BUENO;

            //Si el número que está en el tablero NO es el de la casilla
            if (tablero[fila, col] != valor && tablero[fila, col] != Sudoku.VACIO)
                atractivo += NORMAL;

                     
            
            //Si es uno de los números faltantes en la fila
            List<int> faltantes_filas = sudoku.faltantes_fila(fila);
            if (faltantes_filas.Contains(valor))
                atractivo += BUENO;

            //Si es el único faltante en un fila
            if (faltantes_filas.Contains(valor) && faltantes_filas.Count == 1)
                atractivo += BUENO;

            //Si es uno de los números faltantes en la columna
            List<int> faltantes_cols = sudoku.faltantes_col(col);
            if (faltantes_cols.Contains(valor))
                atractivo += BUENO;

            //Si es el único faltante en la columna
            if (faltantes_cols.Contains(valor) && faltantes_cols.Count == 1)
                atractivo += BUENO;

            //Si es uno de los números faltantes en su region
            List<int> faltantes_region = sudoku.faltantes_region(fila,col);
            if (faltantes_region.Contains(valor))
                atractivo += BUENO;

            //Si es el único faltante en la region
            if (faltantes_region.Contains(valor) && faltantes_region.Count == 1)
                atractivo += BUENO;
            
            //Si es el único faltante en la fila, columna y region
            if ((faltantes_filas.Contains(valor) && faltantes_filas.Count == 1) && (faltantes_cols.Contains(valor) && faltantes_cols.Count == 1) && (faltantes_region.Contains(valor) && faltantes_region.Count == 1))
                atractivo += MUY_BUENO;

            //Si hace falta en todos
            if (faltantes_filas.Contains(valor) && faltantes_cols.Contains(valor) && faltantes_region.Contains(valor))
                atractivo += MUY_BUENO;

           
           

            atractivo = atractivo / (NORMAL * 1 + BUENO * 0 + MUY_BUENO * 2);
            return atractivo; 
        }

        public override Object Clone()
        {
            return Clonar<Casilla>.Clonacion(this);
        }
        public override Componente clonar_sin_vecinos()
        {
            Casilla c = new Casilla(fila, col, valor);
            c.set_feromonas(this.get_feromonas());
            return c;
        }
        public override bool Equals(object obj)
        {
            Casilla c = (Casilla)obj;
            return c.get_fila() == fila && c.get_valor() == valor && c.get_col() == col;
        }
        public override string ToString()
        {
            return "Fila: " + fila + " Col: " + col + " Valor: " + valor;
        }
    }
}
