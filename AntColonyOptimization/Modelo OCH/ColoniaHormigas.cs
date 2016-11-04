using System;
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
        /// Cantidad iteraciones para la busqueda
        /// </summary>
        private int iteraciones;
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

        /*-----------------------------------Métodos-----------------------------------*/
        public ColoniaHormigas(int nSemilla)
        {
            semilla = nSemilla;
            random = new Random(semilla);
        }
        /// <summary>
        /// Busca la mejor solución para el grupo de vértices
        /// </summary>
        /// <param name="vertices">gráfica busqueda  de las hormigas</param>
        /// <param name="n">cantidad de hormigas</param>
        /// <returns>Mejor solución encontrada</returns>
        public Solucion optimizacion_colonia_hormigas(Grafica grafica, int n)
        {
            this.grafica = grafica;
            this.n = n;

            crear_hormigas();
            int i = 0;
            do
            {
                gestor.ubicar_posicion_inicial(random,hormigas, grafica);
                foreach (Hormiga k in hormigas)
                    construir_solucion(k);
                seleccionar_mejor_hormiga();
                actualizar_feromonas();
                i++;
            } while (i < iteraciones);
            return mejor;
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
                hormigas.Add(new Hormiga());
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
        public void construir_solucion(Hormiga k)
        {
            Grafica g = (Grafica)grafica.Clone();
            while(gestor.completo(k.getSolucion()))
            {
                Componente x = k.getSolucion().get_vertice_actual();
                //Vecinos del vertice actual
                List<Componente> N_v = x.N();

                //Probabilidad de cada vertice
                Hashtable P = new Hashtable();
                double sum = 0;

                if(ubicacion_feromonas == VERTICES_FEROMONAS)
                {
                    foreach(Componente y in N_v)
                    {
                        double P_y = Math.Pow(y.get_feromonas(), alfa) * Math.Pow(y.calcular_atractivo(k.getSolucion()), beta);
                        sum += P_y;
                        P.Add(y, P_y);
                    }
                }
                else
                {
                    List<Transicion> aristas = x.get_arista_conecta(N_v);
                    foreach(Transicion y in aristas)
                    {
                        double P_xy = Math.Pow(y.get_feromonas(), alfa) * Math.Pow(y.get_atractivo(), beta);
                        sum += P_xy;
                        P.Add(y, P_xy);
                    }
                }
                foreach(DictionaryEntry e in P)
                {
                    P[e.Key] = (double) e.Value / sum;
                }
                Componente siguiente = escoger_vertice(P,sum);
                k.getSolucion().cambiar_vertice_actual(siguiente);

                
            }
        }
        /// <summary>
        /// Escoge el siguiente vertice de acuerdo a la probabilidad de moverse a cada vertice
        /// </summary>
        /// <param name="P">Diccionario (vertice,probabilidad) </param>
        /// <param name="sumatoria_P">suma de todas las probabilidades</param>
        /// <returns></returns>
        private Componente escoger_vertice(Hashtable P,double sumatoria_P)
        {
            double num = random.NextDouble();
            double sum = 0.0;
            foreach(DictionaryEntry e in P)
            {
                sum += (double)e.Value;
                if (num <= sum)
                    return (Componente)e.Key;
            }
            return null;
        }

    }
}
