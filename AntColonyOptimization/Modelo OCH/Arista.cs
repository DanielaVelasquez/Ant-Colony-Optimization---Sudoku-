using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimization.Modelo_OCH
{
    /// <summary>
    /// Representa conexión entre dos vertices
    /// </summary>
    public class Arista
    {
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Vertice 1 de la arista
        /// </summary>
        private Vertice vertice1;
        /// <summary>
        /// Vertice 2 de la arista
        /// </summary>
        private Vertice vertice2;
        /// <summary>
        /// Cantidad de feromonas almacenadas en el vértice
        /// </summary>
        private double feromonas;
        /// <summary>
        /// Atractivo del movimiento n eta
        /// </summary>
        private double atractivo;

        /*-----------------------------------Métodos-----------------------------------*/
        public Arista(Vertice v1,Vertice v2)
        {
            vertice1 = v1;
            vertice2 = v2;
            feromonas = 0;
            atractivo = -1;
        }
        public Arista(Vertice v1, Vertice v2,double nAtractivo)
        {
            vertice1 = v1;
            vertice2 = v2;
            feromonas = 0;
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
        /// <summary>
        /// Obtiene el vertice vecino de v
        /// </summary>
        /// <param name="v">vertice de la arista del cual se quiere saber cual es su vecino en la arista</param>
        /// <returns>vecino en la arista de v</returns>
        public Vertice get_vecino_de(Vertice v)
        {
            if (vertice1 == v)
                return vertice2;
            else if (vertice2 == v)
                return vertice1;
            else
                throw new Exception("Vertice no pertecene arista");
        }
        /// <summary>
        /// Determina si la arista conecta a v1 y v2
        /// </summary>
        /// <param name="v1">vertice quiere saber si conecta con </param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public Boolean conecta(Vertice v1, Vertice v2)
        {
            return (vertice1 == v1 && vertice2 == v2) || (vertice1 == v2 && vertice2 == v1);
        }
        public double getAtractivo()
        {
            return atractivo;
        }
        public void setVertices(Vertice v1,Vertice v2)
        {
            vertice1 = v1;
            vertice2 = v2;
        }
    }
}
