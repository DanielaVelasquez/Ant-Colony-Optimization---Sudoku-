using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyOptimization.Complemento;

namespace AntColonyOptimization.Modelo_OCH
{
    [Serializable]
    public abstract class Solucion : ICloneable
    {
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Solucion propuesta
        /// </summary>
        protected Grafica grafica;
        /// <summary>
        /// Vertice actual de la solución
        /// </summary>
        protected Componente componente_actual;
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
            List<Transicion> t = grafica.get_aristas();
            return t.Contains(a);
        }
        public Grafica get_grafica()
        {
            return grafica;
        }
        public void set_grafica(Grafica g)
        {
            grafica = g;
        }
        /// <summary>
        /// Determina si la solución tiene el vertice v
        /// </summary>
        /// <param name="v">Vertice que se busca en la solucion</param>
        /// <returns>valor de verdad sobre la presencia del vertice en la solución</returns>
        public Boolean tiene(Componente v)
        {
            return grafica.tiene(v);
        }
        public Componente get_vertice_actual()
        {
            return componente_actual;
        }
        /// <summary>
        /// Ubica la solución en el nuevo vertice y lo añade a la solución
        /// </summary>
        /// <param name="v">nuevo vertice de la solucion y se vuelve el vertice actual</param>
        public void cambiar_vertice_actual(Componente v)
        {
            Componente copia = v.clonar_sin_vecinos();
            //copia.remover_vecinos();
            if (componente_actual != null)
            {
                componente_actual.crear_transicion_con(copia);
            }
            Console.WriteLine(copia.ToString());
            grafica.adicionar_vertice(copia);
            componente_actual = copia;
            vertice_actualizado();
        }


        /// <summary>
        /// Acciones adicionales que puede tomar una solución al momento de haber sido actualizado un vertice
        /// </summary>
        public abstract void vertice_actualizado();
        public abstract Object Clone();
    }
}
