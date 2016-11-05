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
        /// Si el problema es dinámico, se configura la gráfica respecto a la solución de la hormiga 
        /// </summary>
        /// <param name="g">gráfica con la cual está trabjando la hormiga</param>
        /// <param name="k">hormiga está construyendo una solucion sobre la gráfica</param>
        void configurar_grafica(Grafica g, Hormiga k);
    }
}
