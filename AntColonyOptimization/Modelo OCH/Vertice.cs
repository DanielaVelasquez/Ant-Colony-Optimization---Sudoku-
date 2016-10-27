using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimization.Modelo_OCH
{
    /// <summary>
    /// Representa un vértice de la gráfica
    /// </summary>
    public class Vertice 
    {
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Cantidad de feromonas almacenadas en el vértice
        /// </summary>
        private double feromonas;
        /// <summary>
        /// Aristas conectadas al vertice
        /// </summary>
        private List<Arista> aristas;
        /// <summary>
        /// Atractivo de tomar el vertice n eta
        /// </summary>
        private double atractivo;
        /*-----------------------------------Métodos-----------------------------------*/

        public Vertice()
        {
            feromonas = 0;
            aristas = new List<Arista>();
            atractivo = -1;
        }
        public Vertice(double nAtractivo)
        {
            feromonas = 0;
            aristas = new List<Arista>();
            atractivo = nAtractivo;
        }
        public void setFeromonas(double nFeromonas)
        {
            feromonas = nFeromonas;
        }
        public double getFeromonas()
        {
            return feromonas;
        }
        public List<Arista> getAristas()
        {
            return aristas;
        }
        /// <summary>
        /// Vertices vecinos del vertice
        /// </summary>
        /// <returns>vecinos vertice</returns>
        public List<Vertice> N()
        {
            List<Vertice> vecinos = new List<Vertice>();
            foreach(Arista a in aristas)
            {
                vecinos.Add(a.get_vecino_de(this));
            }
            return vecinos;
        }
        public double getAtractivo()
        {
            return atractivo;
        }
        /// <summary>
        /// Obtiene la arista que conecta al vertice actual con el vertice y
        /// </summary>
        /// <param name="y">arista a conectar</param>
        /// <returns>arista que une al vertice actual con vertice y</returns>
        public Arista getAristaConecta(Vertice y)
        {
            foreach(Arista a in aristas)
            {
                //Si el vecino de dicha arista es el vertice que se tomo se retorna la arista
                if (a.get_vecino_de(this) == y)
                    return a;
            }
            return null;
        }
        /// <summary>
        /// Busca las aristas que conectan al vertice actual con los vertices entregados
        /// </summary>
        /// <param name="vertices">vertices a los cuales se quiere encontrar la arista</param>
        /// <returns>lista aristas conectan al vertice con los vertices entregados</returns>
        public List<Arista> getAristasConecta(List<Vertice> vertices)
        {
            List<Arista> aristas = new List<Arista>();
            foreach (Arista a in aristas)
            {
                Vertice v = a.get_vecino_de(this);
                if (vertices.Contains(v))
                    aristas.Add(a);
            }
            return aristas;
        }
        public void eliminar_arista(Arista a)
        {
            Vertice vecino = a.get_vecino_de(this);
            //Elimina la arista de cada uno de los vertices
            vecino.getAristas().Remove(a);
            aristas.Remove(a);
            a.setVertices(null, null);
        }
    }
}
