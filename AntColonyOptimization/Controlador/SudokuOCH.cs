using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyOptimization.Modelo_Sudoku;
using AntColonyOptimization.Modelo_OCH;
using AntColonyOptimization.Complemento;

namespace AntColonyOptimization.Controlador
{
    public class SudokuOCH
    {
        /*-----------------------------------Constantes-----------------------------------*/
        /// <summary>
        /// Cantidad hormigas en la colonia
        /// </summary>
        private const int N = 200;
        /// <summary>
        /// Influencia sobre nivel de feromonas
        /// </summary>
        private const double ALFA = 1;
        /// <summary>
        /// Influencia atractivo movimiento
        /// </summary>
        private const double BETA = 1;
        /// <summary>
        /// Coeficiente evaporacion feromonas
        /// </summary>
        private const double RHO = 0.1;
        /*-----------------------------------Atributos-----------------------------------*/
        private static SudokuOCH instance = null;

        private GestorSudoku gestor;

        private ColoniaHormigas colonia;
        /*-----------------------------------Métodos-----------------------------------*/
        public static SudokuOCH get_instance()
        {
            if (instance == null)
                instance = new SudokuOCH();
            return instance;
        }
        /// <summary>
        /// Encuentra la solución al sudoku
        /// </summary>
        /// <param name="n">Tamaño tablero</param>
        /// <param name="s">Tablero inicial</param>
        /// <param name="semilla">Semilla para aleatoriedad</param>
        /// <returns></returns>
        public Sudoku resolver(int n,Sudoku s,int semilla)
        {
           
            gestor = new GestorSudoku();
            gestor.set_sudoku(s);
            colonia = new ColoniaHormigas(semilla);
            return (Sudoku)colonia.optimizacion_colonia_hormigas(ColoniaHormigas.VERTICES_FEROMONAS,gestor,gestor.crear_grafica(s),N,ALFA,BETA,RHO);
        }

    }
}
