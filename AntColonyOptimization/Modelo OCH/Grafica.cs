using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimization.Modelo_OCH
{
    public class Grafica : ICloneable
    {
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Vertices de la gráfica
        /// </summary>
        private List<Componente> vertices;
        /// <summary>
        /// Aristas de la gráfica
        /// </summary>
        private List<Transicion> aristas;

        /*-----------------------------------Métodos-----------------------------------*/

        public List<Componente> get_vertices()
        {
            return vertices;
        }
        public void set_vertices(List<Componente> vertices)
        {
            this.vertices = vertices;
            aristas = null;
        }
        public List<Transicion> getAristas()
        {
            if(aristas == null)
            {
                aristas = new List<Transicion>();
                foreach(Componente v in vertices)
                {
                    List<Transicion> aristas_v = v.get_transiciones();
                    foreach(Transicion a in aristas_v)
                    {
                        if (!aristas.Contains(a))
                            aristas.Add(a);
                    }
                }
            }
            return aristas;
        }

        public Object Clone()
        {
            return MemberwiseClone();
        }
        /// <summary>
        /// Elimina un vértice de la gráfica,junto con las aristas incidentes en el
        /// </summary>
        /// <param name="v">vertice quiere eliminar de la gráfica</param>
        public void eliminar_vertice(Componente v)
        {
            v.remover_vecinos();
        }
    }
}
