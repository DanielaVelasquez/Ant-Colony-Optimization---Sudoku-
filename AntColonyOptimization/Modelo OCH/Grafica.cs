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
        private List<Vertice> vertices;
        /// <summary>
        /// Aristas de la gráfica
        /// </summary>
        private List<Arista> aristas;

        /*-----------------------------------Métodos-----------------------------------*/

        public List<Vertice> getVertices()
        {
            return vertices;
        }
        public void setVertices(List<Vertice> vertices)
        {
            this.vertices = vertices;
            aristas = null;
        }
        public List<Arista> getAristas()
        {
            if(aristas == null)
            {
                aristas = new List<Arista>();
                foreach(Vertice v in vertices)
                {
                    List<Arista> aristas_v = v.getAristas();
                    foreach(Arista a in aristas_v)
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
    }
}
