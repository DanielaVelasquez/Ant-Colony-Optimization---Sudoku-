using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimization.Modelo_OCH
{
    public interface GestorProblema
    {
        /// <summary>
        /// Ubica las hormigas en una posición inicial
        /// </summary>
        /// <param name="r">objeto genera numeros aleatorios</param>
        /// <param name="hormigas">hormigas del algoritmo</param>
        /// <param name="grafica">gráfica del problema</param>
        void ubicar_posicion_inicial(Random r, List<Hormiga> hormigas, Grafica grafica);
        /// <summary>
        /// Determina si una solución ya está completa
        /// </summary>
        /// <param name="solucion">verdadero si la solución es completa, falso caso contrario</param>
        /// <returns></returns>
        Boolean completo(Solucion solucion);
        /// <summary>
        /// Si el problema es dinámico, se configura los vecinos a los que tiene alcance un vertice de acuerdo a la solucion que lleva la hormiga
        /// </summary>
        /// <param name="g">gráfica problema</param>
        /// <param name="k">hormiga está construyendo una solucion sobre la gráfica</param>
        /// <rereturns>vecinos acomodados</rereturns>
        List<Componente> configurar_vecinos(List<Componente> N, Hormiga k);
        /// <summary>
        /// Determina si se cumplió la condición de parada implícita del problema
        /// </summary>
        /// <param name="mejor">mejor solucion encontrada</param>
        /// <returns>verdadero si la condición de parada ya se cumplió, falso en caso contrario</returns>
        Boolean cumple_condicion_parada(Solucion mejor);
        /// <summary>
        /// Determina si la condición de parada durante la creación del recorrido de
        /// las hormigas se cumplió
        /// </summary>
        /// <param name="s_k">solución de la hormiga k</param>
        /// <returns>verdadero si cumplió la condicion de parada, falso en caso contrario</returns>
        Boolean condicion_parada_hormigas(Solucion s_k);
    }
}
