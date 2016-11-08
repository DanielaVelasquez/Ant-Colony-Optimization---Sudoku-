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
            int repetidos = sudoku.contar_repetidos_fila(fila,valor) + sudoku.contar_repetidos_col(col,valor) + sudoku.contar_repetidos_region(fila,col,valor);
            //Cantidad de casillas que afecta un sudoku
            int total = (n * n - 1) + (n * n - 1) + ((n * n) - ((n - 1) * (n - 1)));

            //Si en el tablero dicha casilla está vacia, aumenta su probabilidad
            if (tablero[fila, col] == Sudoku.VACIO)
                atractivo += 1 / (double)total;
            //Si fila, columna o region de la casilla tiene números repetidos
            if(repetidos>0)
            {
                List<int> lista_repetidos = sudoku.listar_numeros_repetidos_en(fila, col);
                //Si uno de los números repetidos NO es el valor de la casilla, su deseabilidad aumenta
                if (!lista_repetidos.Contains(valor))
                    atractivo += 1 / (double)(total - repetidos);
            }
            
            
            
            atractivo += 1/(double)(repetidos + 1);
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
