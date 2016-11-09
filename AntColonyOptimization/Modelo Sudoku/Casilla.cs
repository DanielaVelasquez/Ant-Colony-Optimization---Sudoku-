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

            //Si la casilla en el sudoku está vacia
            if (tablero[fila, col] == Sudoku.VACIO)
                atractivo += MUY_BUENO;

            //Si el número que está en el tablero NO es el de la casilla
            if (tablero[fila, col] != valor && tablero[fila, col] != Sudoku.VACIO)
                atractivo += NORMAL;

            //Si el número de la casilla es correcto en el sudoku 
            if (sudoku.puede_ubicar(fila, col, valor))
                atractivo += BUENO;
            //Si el valor que hay actualmente es incorrecto
            if (tablero[fila, col] != Sudoku.VACIO && sudoku.puede_ubicar(fila, col, tablero[fila, col]))
                atractivo += NORMAL;
            //Si al ubicar el número de la casilla, disminuyen las coliciones
            int actual = tablero[fila, col];
            int coliciones_a = sudoku.coliciones();
            sudoku.ubicar_numero(fila, col, valor);
            int coliciones_n = sudoku.coliciones();
            sudoku.ubicar_numero(fila, col, actual);
            if (coliciones_n <= coliciones_a)
                atractivo += MUY_BUENO;

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

            //Si la cantidad de veces que está repetido el número en fila, columna y region

            
            //Si la cantidad de veces está presente el valor de la casilla en su fila, columna y región es 0
            int repetido_numero = sudoku.contar_repetidos_fila(fila, valor) + sudoku.contar_repetidos_col(col, valor) + sudoku.contar_repetidos_region(fila, col, valor);
            if (repetido_numero == 0)
                atractivo += NORMAL;
            //Si de los numeros repetidos que hay en la misma fila, columna y región de la casilla el repetido 
            //es el valor en la posicion de la casilla y la casilla no tien ese numero
            List<int> lista_repetidos = sudoku.listar_numeros_repetidos_en(fila, col);
            if (lista_repetidos.Contains(tablero[fila, col]) && tablero[fila, col] != valor)
                atractivo += MUY_BUENO;

            //Si no está en una fila,columna,region completa
            Boolean fc = sudoku.completa_fila(fila);
            Boolean cc = sudoku.completa_col(col);
            Boolean rc = sudoku.esta_completa_region(fila, col);
            if (!fc && !cc && !rc)
                atractivo += MUY_BUENO;
            else
                return 0.1;

            atractivo = atractivo / (NORMAL * 3 + BUENO * 7 + MUY_BUENO * 6);
            return atractivo; 
            /*
            int total = (n * n - 1) + (n * n - 1) + ((n * n) - ((n - 1) * (n - 1)));

            //Cantidad de números repetidos que hay en la misma fila, columna y región de la casilla
           
            int repetidos = lista_repetidos.Count;

            //Si hay números repetidos
            if (repetidos > 0)
            {
                //Si entre los números repetidos NO es el valor de la casilla, su deseabilidad aumenta
                if (!lista_repetidos.Contains(valor))
                {
                    atractivo += (double)1 / ((double)repetido_numero + 1);
                }


            }
            return atractivo;

            /*
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
             * */
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
