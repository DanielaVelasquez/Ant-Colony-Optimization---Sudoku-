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
            if (fila == 6 && col == 5 && valor == 6)
                Console.WriteLine("k");
            atractivo = 0;
            //Cantidad de veces está presente el valor de la casilla en su fila, columna y región 
            int repetido_numero = sudoku.contar_repetidos_fila(fila,valor) + sudoku.contar_repetidos_col(col,valor) + sudoku.contar_repetidos_region(fila,col,valor);
            //Cantidad de casillas que afecta un sudoku
            int total = (n * n - 1) + (n * n - 1) + ((n * n) - ((n - 1) * (n - 1)));
            
            //Si el valor de la casilla es válido aumenta su deseabilidad
            if (sudoku.puede_ubicar(fila, col, valor))
                atractivo += 1 - ((double)1 /( (double)total - repetido_numero + 1));

            //Cantidad de números repetidos que hay en la misma fila, columna y región de la casilla
            List<int> lista_repetidos = sudoku.listar_numeros_repetidos_en(fila, col);
            int repetidos = lista_repetidos.Count;

            //Si hay números repetidos
            if (repetidos > 0)
            {
                //Si entre los números repetidos NO es el valor de la casilla, su deseabilidad aumenta
                if (!lista_repetidos.Contains(valor))
                {
                    atractivo += (double) 1 / ((double)repetido_numero + 1);
                }
                    
               
            }
            
            atractivo += (double) 1 / ((double)repetido_numero + 1);
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
