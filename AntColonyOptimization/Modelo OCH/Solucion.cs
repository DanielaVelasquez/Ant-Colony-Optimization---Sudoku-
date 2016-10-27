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
        private List<Componente> componentes;
        /// <summary>
        /// Vertice actual de la solución
        /// </summary>
        private Componente componente_actual;
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
        public Boolean tiene(Transicion a)
        {
            foreach(Componente v in componentes)
            {
                List<Transicion> aristas = v.getAristas();
                foreach(Transicion arista in aristas)
                {
                    if (arista == a)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Determina si la solución tiene el vertice v
        /// </summary>
        /// <param name="v">Vertice que se busca en la solucion</param>
        /// <returns>valor de verdad sobre la presencia del vertice en la solución</returns>
        public Boolean tiene(Componente v)
        {
            return componentes.Contains(v);
        }
        public Componente getVerticeActual()
        {
            return componente_actual;
        }
        /// <summary>
        /// Ubica la solución en el nuevo vertice y lo añade a la solución
        /// </summary>
        /// <param name="v">nuevo vertice de la solucion y se vuelve el vertice actual</param>
        public void cambiar_vertice_actual(Componente v)
        {
            componentes.Add(v);
            componente_actual = v;
        }
    }
}
