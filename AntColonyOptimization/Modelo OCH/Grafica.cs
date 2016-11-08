using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyOptimization.Complemento;

namespace AntColonyOptimization.Modelo_OCH
{
    [Serializable]
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
        public Grafica()
        {
            vertices = new List<Componente>();
            aristas = null;
        }
        public List<Componente> get_vertices()
        {
            return vertices;
        }
        public void set_vertices(List<Componente> vertices)
        {
            this.vertices = vertices;
            aristas = null;
        }
        public List<Transicion> get_aristas()
        {
            if(aristas == null)
            {
                aristas = new List<Transicion>();
                foreach (Componente v in vertices)
                {
                    List<Transicion> aristas_v = v.get_transiciones();
                    foreach (Transicion a in aristas_v)
                    {
                        if (!aristas.Contains(a))
                            aristas.Add(a);
                    }
                }
            }
            return aristas;
        }
        public void set_aristas(List<Transicion>t)
        {
            aristas = t;
        }
        public Boolean tiene(Componente c)
        {
            foreach(Componente comp in vertices)
            {
                if(comp.Equals(c))
                    return true;
            }
            return false;
            /*
            return vertices.Contains(c);
             * */
        }
        public void adicionar_vertice(Componente c)
        {
            vertices.Add(c);
        }
        /// <summary>
        /// Busca componente igual en la gráfica
        /// </summary>
        /// <param name="c">componente busca</param>
        /// <returns>vertice igual a c o null en caso contrario</returns>
        public Componente buscar(Componente c)
        {
            List<Componente> componentes = get_vertices();
            foreach(Componente v in componentes)
            {
                if (v.Equals(c))
                    return v;
            }
            return null;
        }
        public Object Clone()
        {
            return Clonar<Grafica>.Clonacion(this);
        } 
        /// <summary>
        /// Elimina un vértice de la gráfica,junto con las aristas incidentes en el
        /// </summary>
        /// <param name="v">vertice quiere eliminar de la gráfica</param>
        public void eliminar_vertice(Componente v)
        {
            v.remover_vecinos();
        }
        public override bool Equals(object obj)
        {
            Grafica otra = (Grafica)obj;
            if(otra.get_vertices().Count == vertices.Count)
            {
                List<Componente> otros_v = otra.get_vertices();
                for(int i = 0; i<vertices.Count;i++)
                {
                    if (!vertices[i].Equals(otros_v[i]))
                        return false;
                }
            }
            return false;
        }
    }
}
