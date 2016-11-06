﻿using System;
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
            //Cantidad de casillas que afecta un sudoku
            atractivo = (n*n - 1) - sudoku.repetido_fila(fila,valor) + (n*n-1) -  sudoku.repetido_col(col,valor) + ((n*n)-((n-1)*(n-1))) - sudoku.repetido_cuadro(fila,col,valor);
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

    }
}
