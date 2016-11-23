﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyOptimization.Modelo_OCH;
using System.Threading;

namespace AntColonyOptimization.Modelo_Sudoku
{
    public class GestorSudoku : GestorProblema
    {
        /*-----------------------------------Constantes-----------------------------------*/
        
        /// <summary>
        /// Influencia sobre nivel de feromonas
        /// </summary>
        private const double ALFA = 0.7;
        /// <summary>
        /// Influencia atractivo movimiento
        /// </summary>
        private const double BETA = 0.4;
        /// <summary>
        /// Coeficiente evaporacion feromonas
        /// </summary>
        private const double RHO = 0.1;
        /// <summary>
        /// Cantidad inicial de feromonas
        /// </summary>
        public const double FEROMONAS_INICIAL = 0.3;
        /// <summary>
        /// Valor mínimo de desviacion de las soluciones de las hormigas
        /// </summary>
        public const double PORCENTAJE_HORMIGAS = 0.85;
        /// <summary>
        /// Cantidad máxima de iteraciones de una hormiga
        /// </summary>
        public  int MAX_ITERACION_HORMIGAS = 200;
        /// <summary>
        /// Cantidad máxima de iteraciones de la simulación
        /// </summary>
        public  int MAX_ITERACIONES ;
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Sudoku inicial que está gestionando  
        /// </summary>
        private Sudoku sudoku;
        /// <summary>
        /// Colonia hormigas
        /// </summary>
        private ColoniaHormigas colonia;
        /// <summary>
        /// Grafica del sudoku
        /// </summary>
        private Grafica grafica;
        private int N;
        private int semilla;
        /*-----------------------------------Métodos-----------------------------------*/
       
        public void ubicar_posicion_inicial(Random r, List<Hormiga> hormigas, Grafica grafica)
        {
            List<Componente> componentes = grafica.get_vertices();
            int[,] tablero = sudoku.get_tablero();
            foreach (Hormiga k in hormigas)
            {
                Boolean escogio = false;
                while(!escogio)
                {
                    int num = r.Next(0, componentes.Count);
                    Casilla inicio = (Casilla)componentes[num];
                    escogio = (tablero[inicio.get_fila(), inicio.get_col()] == Sudoku.VACIO)&&sudoku.puede_ubicar(inicio.get_fila(),inicio.get_col(),inicio.get_valor());
                    if (escogio)
                    {
                        Sudoku clone = (Sudoku)sudoku.Clone();
                        k.set_solucion(clone);
                        k.getSolucion().cambiar_vertice_actual(inicio);
                    }
                    
                }
                
            }
        }
        public Boolean completo(Solucion solucion)
        {
            //return ((Sudoku)solucion).coliciones() == 0;
            return ((Sudoku)solucion).completo();

        }
        public  List<Componente> configurar_vecinos(List<Componente> N, Hormiga k)
        {
            List<Componente> vecinos = new List<Componente>();
            List<Componente> vertices_solucion = k.getSolucion().get_grafica().get_vertices();
            
            Sudoku sudoku = (Sudoku)k.getSolucion();
            int n = sudoku.get_n();
            int[,] tablero = sudoku.get_tablero();

            int coliciones_a = sudoku.coliciones();
            int i = 0;
            while(i< N.Count)
            {
                Casilla c = (Casilla)N[i];
                if(tablero[c.get_fila(), c.get_col()]!= c.get_valor())
                {
                    int actual = tablero[c.get_fila(), c.get_col()];
                    sudoku.ubicar_numero(c.get_fila(), c.get_col(), c.get_valor());
                    int coliciones_n = sudoku.coliciones();
                    sudoku.ubicar_numero(c.get_fila(), c.get_col(), actual);
                    if (coliciones_n <= coliciones_a)
                        i++;
                    else
                        N.Remove(c);
                }
                else
                    N.Remove(c);
                

            }
            return N;
        }
        public Boolean cumple_condicion_parada(Solucion mejor)
        {
            Sudoku s = (Sudoku)mejor;
            return s.completo();
        }
        public Boolean condicion_parada_hormigas(Solucion s_k)
        {
            Sudoku s = (Sudoku)s_k;
            return s.completo();
        }
        public GestorSudoku()
        {
            
        }

        /// <summary>
        /// Crea una gráfica a partir de un sudoku inicial
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private Grafica crear_grafica(Sudoku s)
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
                            if(s.puede_ubicar(i, j, valor))
                            {
                                Casilla c = new Casilla(i, j, valor);
                                componentes.Add(c);
                            }
                        }
                    }
                    /*else
                    {
                        Casilla c = new Casilla(i, j, tablero[i, j]);
                        componentes.Add(c);
                    }*/
                }
            }
            Grafica g = new Grafica();
            List<Transicion> transicion = new List<Transicion>();
            //Crea las aristas
            while(componentes.Count!=0)
            {
                Casilla actual = (Casilla) componentes[0];
                componentes.Remove(actual);
                foreach(Casilla casilla in componentes)
                {
                    transicion.Add(actual.crear_transicion_con(casilla));
                }
                g.adicionar_vertice(actual);
            }
            g.set_aristas(transicion);
            return g;
        }
        /// <summary>
        /// Crea la gráfica asociada al sudoku y le asigna su solucion inicial
        /// </summary>
        /// <param name="s">sudoku a gestionar</param>
        private void configurar(Sudoku s)
        {
            sudoku = s;
            grafica = crear_grafica(s);

            Grafica solucion = new Grafica();

            int[,] tablero = s.get_tablero();
            int n = s.get_n();
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    if (tablero[i, j] != Sudoku.VACIO)
                    {
                        Casilla c = new Casilla(i, j, tablero[i, j]);
                        Casilla casilla = (Casilla)grafica.buscar(c);
                        if(casilla!=null)
                            solucion.adicionar_vertice(casilla.clonar_sin_vecinos());
                    }
                }
            }
            sudoku.set_grafica(solucion);
        }
        /// <summary>
        /// Da solución a un sudoku
        /// </summary>
        /// <param name="s">sudoku que se quiere resolver</param>
        /// <param name="semilla">semilla para el generador de números aleatorios</param>
        /// <returns>solucion del sudoku</returns>
        public Thread resolver(Sudoku s,int semilla)
        {
            
            
            configurar(s);
            colonia = new ColoniaHormigas();
            int n = s.get_n();
            //Cantidad hormigas depende del tamaño del tablero
            N = (n * n);

            //Cantidad máxima de iteraciones para hormiga
            double total_casillas = Math.Pow(n * n, 2);
            double casillas_llenas = total_casillas - s.casillas_vacias();//Cantidad casillas número inicial

            
            this.semilla = semilla;
            MAX_ITERACION_HORMIGAS = sudoku.casillas_vacias() * 10 / 4;
            MAX_ITERACIONES = MAX_ITERACION_HORMIGAS * 2;
            Thread hilo = new Thread(ejecutar);
            hilo.Start();

            return hilo;

        }
        private void ejecutar()
        {
            colonia.optimizacion_colonia_hormigas(MAX_ITERACIONES, MAX_ITERACION_HORMIGAS, PORCENTAJE_HORMIGAS, semilla, FEROMONAS_INICIAL, ColoniaHormigas.VERTICES_FEROMONAS, ColoniaHormigas.MINIMIZAR, this, grafica, N, ALFA, BETA, RHO);
        }
        public ColoniaHormigas getColonias()
        {
            return colonia;
        }
        
    }
}
