using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimization.Modelo_OCH
{
    public abstract class Solucion
    {
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Vertices parte de la solución
        /// </summary>
        private List<Vertice> vertices;
        /// <summary>
        /// Vertice actual de la solución
        /// </summary>
        private Vertice vertice_actual;
        /*-----------------------------------Métodos-----------------------------------*/
        /// <summary>
        /// Determina la calidad de la solución
        /// </summary>
        /// <returns></returns>
        public abstract double funcion_costo();
        /// <summary>
        /// Determina si la solución tiene la arista a
        /// </summary>
        /// <param name="a">Arista que se busca en la solución</param>
        /// <returns>valor de verdad sobre la presencia de la arista en la solución</returns>
        public abstract Boolean tiene(Arista a);
        /// <summary>
        /// Determina si la solución tiene el vertice v
        /// </summary>
        /// <param name="v">Vertice que se busca en la solucion</param>
        /// <returns>valor de verdad sobre la presencia del vertice en la solución</returns>
        public abstract Boolean tiene(Vertice v);

        public Vertice getVerticeActual()
        {
            return vertice_actual;
        }
        /// <summary>
        /// Ubica la solución en el nuevo vertice y lo añade a la solución
        /// </summary>
        /// <param name="v">nuevo vertice de la solucion y se vuelve el vertice actual</param>
        public abstract void cambiar_vertice_actual(Vertice v);
    }
}
