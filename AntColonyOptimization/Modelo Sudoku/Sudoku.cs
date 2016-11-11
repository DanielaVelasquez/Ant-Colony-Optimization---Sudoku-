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
    public class Sudoku:Solucion
    {
        /*-----------------------------------Constantes-----------------------------------*/
        public const int VACIO = 0;
        private const int PENALIZACION_VACIOS = 25;
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
            tablero = new int[this.n*this.n, this.n*this.n];
            /*for (int i = 0; i < n * n; i++ )
            {
                for(int j = 0; j< n*n; j++)
                {
                    tablero[i, j] = VACIO;
                }
            }*/
            grafica = new Grafica();
        }
        public override double funcion_costo()
        {
            return casillas_vacias() + 1;
        }
        /// <summary>
        /// Cuenta cantidad de números que chocan indebidamente en el tablero
        /// </summary>
        /// <returns>cantidad de coliciones</returns>
        public int coliciones()
        {
            return repetidos_filas() + repetidos_columnas() + repetidos_region();
        }
        /// <summary>
        /// Cuenta la cantidad de casillas vacias
        /// </summary>
        /// <returns>cantidad de casillas vacias en el tablero</returns>
        public int casillas_vacias()
        {
            int cont = 0;
            for(int i = 0; i < n*n; i++)
            {
                for(int j = 0; j < n*n; j++)
                {
                    if (tablero[i, j] == VACIO)
                        cont++;
                }
            }
            return cont;
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
                    if (tablero[i, j] != VACIO && !numeros.Contains(tablero[i, j]))
                        filas++;
                    else if (tablero[i, j] != VACIO)
                        numeros.Remove(tablero[i, j]);
                }
                
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
                    if (tablero[i, j] != VACIO && !numeros.Contains(tablero[i, j]))
                        columnas++;
                    else if (tablero[i, j] != VACIO)
                        numeros.Remove(tablero[i, j]);
                }
            }
            return columnas;
        }
        /// <summary>
        /// Contabiliza la cantidad de números repetidos en los cuadros del tablero
        /// </summary>
        /// <returns>cantidad números repetidos en cuadros</returns>
        private int repetidos_region()
        {
            int cuadros = 0;
            for(int f = 0; f < n*n; f = f + n)
            {
                for(int c = 0; c < n*n; c = c+n)
                {
                    List<int> numeros = crear_lista_valores();
                    for(int i = 0; i <n;i++)
                    {
                        
                        for(int j = 0; j< n; j++)
                        {
                            if (tablero[i + f, j + c] != VACIO && !numeros.Contains(tablero[i + f, j + c]))
                                cuadros++;
                            else if (tablero[i + f, j + c] != VACIO)
                                numeros.Remove(tablero[i + f, j + c]);
                        }
                        
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
            for (int i = 1; i <= n * n; i++)
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
                throw new Exception("Número " + num + " repetido en fila, columna o región");
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
            return !casilla_utilizada(fila,col,num)&&!esta_fila(fila, num) && !esta_col(col, num) && !esta_cuadro(fila, col, num);
        }
        public Boolean casilla_utilizada(int fila,int col,int num)
        {
            return !(tablero[fila, col] == VACIO);
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
            for(int i = 0; i<n;i++)
            {
                for(int j = 0; j< n;j++)
                {
                    if (tablero[i + f, j + c] == num)
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
        public int obtener_cuadrante(int valor)
        {
            for(int i = 0; i < n*n; i = i + n)
            {
                if (valor >= i && valor < i + n)
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// Determina la cantidad de veces que un número se encuentra en la misma fila
        /// </summary>
        /// <param name="fila">fila tablero en la que se busca</param>
        /// <param name="num">número que se busca</param>
        /// <returns>Cantidad de veces que el número se repite en la fila</returns>
        public int contar_repetidos_fila(int fila, int num)
        {
            int cont = 0;
            for (int j = 0; j < n * n; j++)
            {
                if (tablero[fila, j] == num)
                    cont++;
            }
            /*if (cont >= 1)
                cont -= 1;*/
            return cont;
        }
        /// <summary>
        /// Determina la cantidad de veces que un número se encuentra en la misma columna
        /// </summary>
        /// <param name="col">columna tablero en la que se busca</param>
        /// <param name="num">número que se busca</param>
        /// <returns>Cantidad de veces que el número se repite en la columna</returns>
        public int contar_repetidos_col(int col,int num)
        {
            int cont = 0;
            for (int i = 0; i < n * n; i++)
            {
                if (tablero[i, col] == num)
                    cont++;
            }
            /*if (cont >= 1)
                cont -= 1;*/
            return cont;
        }
        /// <summary>
        /// Determina la cantidad de veces que un número está repetido en un cuadro
        /// </summary>
        /// <param name="fila">fila donde esta ubicado el número</param>
        /// <param name="col">columna donde está ubicado el número</param>
        /// <param name="num">número está buscando</param>
        /// <returns></returns>
        public int contar_repetidos_region(int fila,int col,int num)
        {
            int f = obtener_cuadrante(fila);
            int c = obtener_cuadrante(col);
            int cont = 0;
            for (int i = 0; i < n ; i++)
            {
                for (int j = 0; j < n ; j++)
                {
                    if (tablero[i + f, j + c] == num)
                        cont++;
                }
            }
            /*if (cont >= 1)
                cont -= 1;*/
            return cont;
        }
        /// <summary>
        /// Determina si el tablero está lleno
        /// </summary>
        /// <returns></returns>
        public Boolean completo()
        {
            return filas_completas() && cols_completas() && regiones_completas();
        }
        /// <summary>
        /// Determina si las regiones se llenaron de forma correcta
        /// </summary>
        /// <returns>verdadero si las regiones se llenaron de forma correcta</returns>
        private Boolean regiones_completas()
        {
            
            for (int f = 0; f < n * n; f = f + n)
            {
                for (int c = 0; c < n * n; c = c + n)
                {
                    if (!region_completa(f, c))
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Determina si la region a la cual pertence la casilla[fila, col] está completa
        /// </summary>
        /// <param name="fila">fila de la casilla</param>
        /// <param name="col">columna de la casilla</param>
        /// <returns>verdadero si la region de la casilla está completa</returns>
        public Boolean esta_completa_region(int fila, int col)
        {
            int f = obtener_cuadrante(fila);
            int c = obtener_cuadrante(col);
            return region_completa(f, c);
        }
        
        /// <summary>
        /// Determina si una region está completa
        /// </summary>
        /// <param name="f">Fila inicio de la region</param>
        /// <param name="c">Columna incio de la region</param>
        /// <returns>verdadero si la region está completa</returns>
        private Boolean region_completa(int f, int c)
        {
            int v = n * n;
            int suma = (v * (v + 1)) / 2;
            int region = 0;
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    region += tablero[i + f, j + c];
                }

            }
            if (region != suma)
                return false;
            return true;

        }
        /// <summary>
        /// Determina si todas las columnas se llenaron correctamente
        /// </summary>
        /// <returns>verdadero si todas las columnas se llenaron de fomra correcta</returns>
        private Boolean cols_completas()
        {
            
            for (int i = 0; i < n * n; i++)
            {
                if (!completa_col(i))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Determinas si la columna i se lleno adecuadamente
        /// </summary>
        /// <param name="i">columna</param>
        /// <returns>verdadero si la columna se lleno apropiadamente</returns>
        public Boolean completa_col(int i)
        {
            int v = n * n;
            int suma = (v * (v + 1)) / 2;
            int col = 0;
            for (int j = 0; j < n * n; j++)
            {
                col += tablero[j, i];
            }
            if (col != suma)
                return false;
            return true;
        }
        /// <summary>
        /// Determina si todas las filas se llenaron correctamente
        /// </summary>
        /// <returns>verdadero si todas las filas se llenaron de fomra correcta</returns>
        private Boolean filas_completas()
        {
            
            for(int i = 0; i < n*n; i++)
            {
                if (!completa_fila(i))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Determina si la fila i está completa
        /// </summary>
        /// <param name="i">fila</param>
        /// <returns>verdadero si la fila está completa</returns>
        public Boolean completa_fila(int i)
        {
            int v = n * n;
            int suma = (v * (v + 1)) / 2;
            int fila = 0;
            for (int j = 0; j < n * n; j++)
            {
                fila += tablero[i, j];
            }
            if (fila != suma)
                return false;
            return true;
        }
        /// <summary>
        /// Crea una lista con los números repetidos en un fila, col y región
        /// </summary>
        /// <param name="fila">fila de la casilla que se desea ver</param>
        /// <param name="col">columna de la casilla que se desea ver</param>
        /// <returns>Lista con los números que se repiten en una fila, columna o región</returns>
        public List<int> listar_numeros_repetidos_en(int fila, int col)
        {
            List<int> lista = new List<int>();
            adicionar_sin_repetir(lista, listar_repetidos_region(fila,col));
            adicionar_sin_repetir(lista, listar_repetidos_col(col));
            adicionar_sin_repetir(lista, listar_repetidos_fila(fila));
            return lista;
        }
        private void adicionar_sin_repetir(List<int> lista, List<int> adicionar)
        {
            foreach(int v in adicionar)
            {
                if (!lista.Contains(v))
                    lista.Add(v);
            }
        }
        /// <summary>
        /// Crea una lista con los números repetidos en una region
        /// </summary>
        /// <param name="fila">fila de la casilla que se desea ver</param>
        /// <param name="col">columna de la casilla que se desea ver</param>
        /// <returns>Lista con los números que se repiten en una región</returns>
        private List<int> listar_repetidos_region(int fila, int col)
        {
            List<int> repetidos = new List<int>();
            int f = obtener_cuadrante(fila);
            int c = obtener_cuadrante(col);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for(int i_1 = i + 1; i_1 < n; i_1++)
                    {
                       for (int j_1 = j; j_1 < n; j_1++)
                       {
                           if(tablero[i+f,j+c]!= VACIO && tablero[i_1+f, j_1+f]!= VACIO && tablero[i+f,j+c] == tablero[i_1+f, j_1+f] && !repetidos.Contains(tablero[i_1+f, j_1+f]))
                           {
                               repetidos.Add(tablero[i + f, j + c]);
                           }
                       }
                    }
                }
            }
            return repetidos;

        }
        /// <summary>
        /// Crea una lista con los números repetidos en una columna
        /// </summary>
        /// <param name="col">col de la casilla que se desea ver</param>
        /// <returns>Lista con los números que se repiten en una columna</returns>
        private List<int> listar_repetidos_col(int col)
        {
            List<int> repetidos = new List<int>();
            for (int i = 0; i < (n * n) - 1; i++)
            {
                for (int j = i+1; j < n * n; j++)
                {
                    if (tablero[i, col]  != VACIO && tablero[j, col] != VACIO && tablero[i, col] == tablero[j, col] && !repetidos.Contains(tablero[i, col]))
                        repetidos.Add(tablero[i, col]);
                }
            }
            return repetidos;
        }
        /// <summary>
        /// rea una lista con los números repetidos en un fila
        /// </summary>
        /// <param name="fila">fila de la casilla que se desea ver</param>
        /// <returns>Lista con los números que se repiten en una fila</returns>
        private List<int> listar_repetidos_fila(int fila)
        {
            List<int> repetidos = new List<int>();
            for(int i = 0; i<  (n*n) - 1;i++)
            {
                for(int j = i+1; j< n*n;j++)
                {
                    if (tablero[fila, i] != VACIO && tablero[fila, j] != VACIO && tablero[fila, i] == tablero[fila, j] && !repetidos.Contains(tablero[fila, i]))
                        repetidos.Add(tablero[fila, i]);
                }
            }
            return repetidos;
        }
        /// <summary>
        /// Crea una lista del conjunto de números que faltan en una fila
        /// </summary>
        /// <param name="fila">fila que se desea</param>
        /// <returns>Lista del conjunto de números que faltan en la fila</returns>
        public List<int> faltantes_fila(int fila)
        {
            List<int> faltantes = crear_lista_valores();
            for(int j = 0; j< n*n;j++)
            {
                if (faltantes.Contains(tablero[fila, j]))
                    faltantes.Remove(tablero[fila, j]);
            }
            return faltantes;
        }
        /// <summary>
        /// Crea una lista del conjunto de números que faltan en una columna
        /// </summary>
        /// <param name="col">columna que se desea</param>
        /// <returns>Lista del conjunto de números que faltan en la fila</returns>
        public List<int> faltantes_col(int col)
        {
            List<int> faltantes = crear_lista_valores();
            for (int i = 0; i < n * n; i++)
            {
                if (faltantes.Contains(tablero[i, col]))
                    faltantes.Remove(tablero[i, col]);
            }
            return faltantes;
        }
        /// <summary>
        /// Crea una lista del conjunto de números que faltan en la region en la cual está la fila y columna
        /// </summary>
        /// <param name="fila">fila que se desea</param>
        /// /// <param name="col">columna que se desea</param>
        /// <returns>Lista del conjunto de números que faltan en la region en la cual está la fila y columna</returns>
        public List<int> faltantes_region(int fila,int col)
        {
            List<int> faltantes = crear_lista_valores();
            int f = obtener_cuadrante(fila);
            int c = obtener_cuadrante(col);
            for (int i = 0; i < n; i++ )
            {
                for(int j = 0; j< n;j++)
                {
                    if (faltantes.Contains(tablero[i + f, c + j]))
                        faltantes.Remove(tablero[i + f, c + j]);
                }
            }
             return faltantes;
        }
        public int get_n()
        {
            return n;
        }
        public int[,] get_tablero()
        {
            return tablero;
        }

        public override void vertice_actualizado()
        {
            Casilla c = (Casilla) this.get_vertice_actual();
            /*if (tablero[c.get_fila(), c.get_col()] != VACIO)
                Console.WriteLine("Repetido");*/
            tablero[c.get_fila(), c.get_col()] = c.get_valor();
        }
        public override string ToString()
        {
            String cad = "";
            for(int i = 0; i < n*n; i++)
            {
                for(int j = 0; j< n*n; j++)
                {
                    cad += tablero[i, j]+"   ";
                    if (j+1 % n == 0 )
                        cad += "|";
                }
                if (i+1 % n == 0 )
                    cad += "\n__________________________________________________";
                cad += "\n";
            }
            return cad;
        }
        public override Object Clone()
        {
            return Clonar<Sudoku>.Clonacion(this);
        }
        public override bool Equals(object obj)
        {
            try
            {
                Sudoku s = (Sudoku)obj;
                int[,] tablero2 = s.get_tablero();
                int n2 = s.get_n();
                if (n == n2)
                {
                    for (int i = 0; i < n * n; i++)
                    {
                        for (int j = 0; j < n * n; j++)
                        {
                            if (tablero[i, j] != tablero2[i, j])
                                return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            
        }

    }
}
