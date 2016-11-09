﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AntColonyOptimization.Modelo_OCH
{
    /// <summary>
    /// Colonia de hormigas que va a realizar la búsqueda dentro de la gráfica que le entreguen
    /// </summary>
    public class ColoniaHormigas
    {
        /*-----------------------------------Constantes-----------------------------------*/
        /// <summary>
        /// Valor indica feromonas están almacenadas en aristas
        /// </summary>
        public const int ARISTAS_FEROMONAS = 0;
        /// <summary>
        /// Valor indica feromonas están almacenadas en vertices
        /// </summary>
        public const int VERTICES_FEROMONAS = 1;
        /// <summary>
        /// Determina si se quiere encontrar una solución de valor máxima
        /// </summary>
        public const int MAXIMIZAR = 2;
        /// <summary>
        /// Determina si se quiere encontrar una solución de valor mínimo
        /// </summary>
        public const int MINIMIZAR = 3;
        /// <summary>
        /// Mensaje error si el valor para la ubicación de las feormonsa es invalido
        /// </summary>
        public const String ERROR_UBICACION_FEROMONAS = "Valor indicado para ubicación de feromonas invalido";
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Cantidad de hormigas
        /// </summary>
        private int n;
        /// <summary>
        /// Influencia de la cantidad de feromonas
        /// </summary>
        private double alfa;
        /// <summary>
        /// Influencia del atractivo del movimiento
        /// </summary>
        private double beta;
        /// <summary>
        /// Coeficiente de evaporación de las feromonas
        /// </summary>
        private double rho;
        /// <summary>
        /// Cantidad inicial de feromonas depositadas en vertices o aristas
        /// </summary>
        private double inicial_feromonas;
        /// <summary>
        /// Gráfica recorrer las hormigas para construir la solución
        /// </summary>
        private Grafica grafica;
        /// <summary>
        /// Hormigas de la colonia
        /// </summary>
        private List<Hormiga> hormigas;
        /// <summary>
        /// Mejor solución encontrada
        /// </summary>
        private Solucion mejor;
        /// <summary>
        /// Especifica si las feromonas están en las aristas o vertices de la gráfica
        /// </summary>
        private int ubicacion_feromonas;
        /// <summary>
        /// Valor mínimo de porcentaje de hormigas en el mismo camino
        /// </summary>
        private double mismo_camino;
        /// <summary>
        /// Conocedor del problema
        /// </summary>
        private GestorProblema gestor;
        /// <summary>
        /// Tipo optimización maximizar/minimizar
        /// </summary>
        private int tipo_optimizacion;
        /// <summary>
        /// Valor de la semilla
        /// </summary>
        private int semilla;
        /// <summary>
        /// Generador de números aletorios
        /// </summary>
        private Random random;
        /// <summary>
        /// Resultados de las hormigas a traves de las iteraciones fila: iteracion, col: id_hormiga, val[fila,col] = funcion costo solucion hormiga
        /// </summary>
        private int[,] resultados;
        /// <summary>
        /// Tiempo tomo a la simulación encontrar una solución
        /// </summary>
        private TimeSpan tiempo;

        /*-----------------------------------Métodos-----------------------------------*/
        public ColoniaHormigas()
        {
            
        }
        /// <summary>
        /// Busca la mejor solución para el grupo de vértices
        /// </summary>
        /// <param name=param name="tipo_op">indica si las feromonas estan en las aristas o vertices, usar constantes de la presenta clase</param>
        /// <param name="g">Gestor del problema</param>
        /// <param name="vertices">gráfica busqueda  de las hormigas</param>
        /// <param name="n">cantidad de hormigas</param>
        /// <param name="alfa">Influencia sobre nivel de feromonas</param>
        /// <param name="beta">Influencia atractivo movimiento</param>
        /// <param name="rho">Coeficiente evaporacion feromonas</param>
        /// <returns>Mejor solución encontrada</returns>
        public Solucion optimizacion_colonia_hormigas(double mismo_camino,int nSemilla,double inicial_feromonas, int ubicacion_feromonas, int tipo_op,GestorProblema g,Grafica grafica, int n,double alfa, double beta,double rho)
        {
            DateTime inicio = DateTime.Now;
            semilla = nSemilla;
            this.mismo_camino = mismo_camino;
            random = new Random(semilla);
            this.inicial_feromonas = inicial_feromonas;
            this.ubicacion_feromonas = ubicacion_feromonas;
            this.tipo_optimizacion = tipo_op;
            this.gestor = g;
            this.grafica = grafica;
            this.n = n;
            this.alfa = alfa;
            this.beta = beta;
            this.rho = rho;

            crear_hormigas();
            iniciar_feromonas();
            int i = 0;
            do
            {
                gestor.ubicar_posicion_inicial(random,hormigas, grafica);
                foreach (Hormiga k in hormigas)
                {
                    construir_solucion(k);
                    Console.WriteLine(k.ToString());
                }
                    
                seleccionar_mejor_hormiga();
                actualizar_feromonas();
                i++;/*
                Console.WriteLine(mejor.ToString());
                Console.WriteLine(mejor.funcion_costo());*/
                Console.WriteLine("iteracion " + i);
                Console.WriteLine("Porentjae: " + hormigas_mismo_camino());
                
                    
            } while (hormigas_mismo_camino() < mismo_camino);
            DateTime final = DateTime.Now;
            tiempo = final - inicio;
            return mejor;
        }
        /// <summary>
        /// Calcula la desviación estandar de las soluciones de cada hormiga
        /// </summary>
        /// <returns></returns>
        private double hormigas_mismo_camino()
        {
            
            double maximo = 0;
            for(int i = 0; i < hormigas.Count - 1; i++)
            {
                double porcentaje = 0;
                Solucion S1 = hormigas[i].getSolucion();
                for(int j = i+1; j < hormigas.Count;j++)
                {
                    Solucion S2 = hormigas[j].getSolucion();
                    if(S1.Equals(S2))
                    {
                        porcentaje++;
                    }
                }
                porcentaje = porcentaje / (double)(hormigas.Count - 1);
                if (maximo == 0 || maximo < porcentaje)
                    maximo = porcentaje;
            }
            return maximo;
        }
        /// <summary>
        /// Busca la solución de la mejor hormiga y la guarda
        /// </summary>
        private void seleccionar_mejor_hormiga()
        {
            //Si no hay ninguna solución buena aún
            if (mejor == null)
                mejor = hormigas[0].getSolucion();

            for(int k = 1; k < n; k++)
            {
                Solucion actual = hormigas[k].getSolucion();
                if (actual.funcion_costo() < actual.funcion_costo())
                    mejor = actual;
            }
        }
        /// <summary>
        /// Crea las n hormigas de la colonia del problema
        /// </summary>
        private void crear_hormigas()
        {
            hormigas = new List<Hormiga>();
            for (int k = 0; k < n; k++)
                hormigas.Add(new Hormiga(k+1));
        }
        /// <summary>
        /// Inicia las feromonas en las aristas o vértices
        /// </summary>
        private void iniciar_feromonas()
        {
            //Las feromonas están ubicadas en los vértices
            if (ubicacion_feromonas == VERTICES_FEROMONAS)
            {
                List<Componente> vertices = grafica.get_vertices();
                foreach (Componente v in vertices)
                    v.set_feromonas(inicial_feromonas);
            }
            //Las feromonas están ubicadas en las aristas
            else if (ubicacion_feromonas == ARISTAS_FEROMONAS)
            {
                List<Transicion> aristas = grafica.get_aristas();
                foreach (Transicion a in aristas)
                    a.set_feromonas(inicial_feromonas);
            }
            else
                throw new Exception(ERROR_UBICACION_FEROMONAS);
        }
        /// <summary>
        /// Actualiza las feromonas en los vertices o aristas
        /// </summary>
        private void actualizar_feromonas()
        {
            //Las feromonas están en las aristas
            if (ubicacion_feromonas == ARISTAS_FEROMONAS)
            {
                List<Transicion> aristas = grafica.get_aristas();
                //Actualiza las feromonas en cada arista de la gráfica
                foreach (Transicion a in aristas)
                {
                    double Txy = a.get_feromonas();
                    Txy = ((1 - rho) * Txy) + sum_deltha_xy(a);
                    a.set_feromonas(Txy);
                }
            }
            else if (ubicacion_feromonas == VERTICES_FEROMONAS)
            {
                List<Componente> vertices = grafica.get_vertices();
                foreach (Componente v in vertices)
                {
                    double Tx = v.get_feromonas();
                    Tx = ((1 - rho) * Tx) + sum_deltha_x(v);
                    v.set_feromonas(Tx);
                }
            }
            else
                throw new Exception(ERROR_UBICACION_FEROMONAS);
        }
        /// <summary>
        /// Calcula la cantidad de feromonas depositadas por cada hormiga en la transición de la arista
        /// </summary>
        /// <param name="arista">transición de la cual se quiere calcular las feromonas por depositar</param>
        /// <returns>cantidad de feromonas depositadas por cada hormiga en la arista</returns>
        private double sum_deltha_xy(Transicion arista)
        {
            double sum_deltha_xy = 0.0;
            foreach(Hormiga k in hormigas)
            {
                if(k.getSolucion().tiene(arista))
                    sum_deltha_xy += k.funcion_feromonas(tipo_optimizacion, rho);
            }
            return sum_deltha_xy;
        }
        /// <summary>
        /// Calcula la cantidad de feromonas depositadas por cada hormiga en el vertice
        /// </summary>
        /// <param name="arista">vertice del cual se quiere calcular las feromonas por depositar</param>
        /// <returns>cantidad de feromonas depositadas por cada hormiga en el vertice</returns>
        private double sum_deltha_x(Componente vertice)
        {
            double sum_deltha_xy = 0.0;
            foreach (Hormiga k in hormigas)
            {
                if (k.getSolucion().tiene(vertice))
                    sum_deltha_xy += k.funcion_feromonas(tipo_optimizacion, rho);
            }
            return sum_deltha_xy;
        }
        /// <summary>
        /// Construye solución de la hormiga
        /// </summary>
        /// <param name="k">hormiga a la cual se le va a construir la solucion</param>
        private void construir_solucion(Hormiga k)
        {
            Grafica g = grafica;
            //Verifica aún hay vecinos para explorar desde la solución actual
            int cont = 0;
            int iteraciones = 200;
            Boolean abortado = false;
            while(!gestor.completo(k.getSolucion()) && !abortado)
            {
                //Console.WriteLine("Iteracion: " + cont + " Coliciones " + k.getSolucion().funcion_costo());
                //Console.WriteLine(k.getSolucion().ToString());
                if (cont == 16634)
                    Console.WriteLine("");
                Componente actual_k = k.getSolucion().get_vertice_actual();
                Componente x = g.buscar(actual_k);
                //Vecinos del vertice actual
                List<Componente> N_v = x.N();
                N_v = gestor.configurar_vecinos(N_v, k);
                if (N_v.Count == 0)
                {
                    abortado = true;
                    break;
                }
                    
                //Probabilidad de cada vertice
                
                double sum = 0;
                IDictionary P,P1;
                if(ubicacion_feromonas == VERTICES_FEROMONAS)
                {
                    P = new Dictionary<Componente, double>();
                    P1 = new Dictionary<Componente, double>();
                    foreach(Componente y in N_v)
                    {
                        double atractivo = y.calcular_atractivo(k.getSolucion());
                        double P_y = Math.Pow(y.get_feromonas(), alfa) * Math.Pow(y.calcular_atractivo(k.getSolucion()), beta);
                        sum += P_y;
                        P.Add(y, P_y);
                    }
                }
                else
                {
                    P = new Dictionary<Transicion, double>();
                    P1 = new Dictionary<Transicion, double>();
                    List<Transicion> aristas = x.get_arista_conecta(N_v);
                    foreach(Transicion y in aristas)
                    {
                        double P_xy = Math.Pow(y.get_feromonas(), alfa) * Math.Pow(y.get_atractivo(), beta);
                        sum += P_xy;
                        P.Add(y, P_xy);
                    }
                }
               
                
                    foreach (DictionaryEntry e in P)
                    {
                        double P_xy = (double)e.Value / sum;
                        //Console.WriteLine(e.Key.ToString()+" "+P_xy);
                        P1.Add(e.Key, P_xy);
                    }
                P = P1;
                Componente siguiente = escoger_vertice(P,x);
                k.getSolucion().cambiar_vertice_actual(siguiente);
                cont++;
            }
        }
        /// <summary>
        /// Escoge el siguiente vertice de acuerdo a la probabilidad de moverse a cada vertice
        /// </summary>
        /// <param name="P">Diccionario (vertice,probabilidad) </param>
        /// <param name="v">Vertice actual de la hormiga</param>
        /// <returns></returns>
        private Componente escoger_vertice(IDictionary P,Componente v)
        {
            double num = random.NextDouble();
            //Console.WriteLine("RAND: " + num);
            double sum = 0.0;
            foreach(DictionaryEntry e in P)
            {
                sum += (double)e.Value;
                //Console.WriteLine("VALUE " + e.Value);
                if (num <= sum)
                {
                    //Console.WriteLine("Prob: " + e.Value);
                    //Console.WriteLine("Vertice escogido: " + e.Key.ToString());
                    if(ubicacion_feromonas == VERTICES_FEROMONAS)
                        return (Componente)e.Key;
                    else
                    {
                        Transicion t = (Transicion)e.Key;
                        return t.get_vecino_de(v);
                    }
                }
                    
            }
            return null;
        }

    }
}
