using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimization.Modelo_OCH
{
    /// <summary>
    /// Conexión entre dos vertices
    /// </summary>
    public class Transicion
    {
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Componente 1 de la arista
        /// </summary>
        private Componente componente1;
        /// <summary>
        /// Componente 2 de la arista
        /// </summary>
        private Componente componente2;
        /// <summary>
        /// Cantidad de feromonas almacenadas en transicion
        /// </summary>
        private double feromonas;
        /// <summary>
        /// Atractivo del movimiento 
        /// </summary>
        private double atractivo;

        /*-----------------------------------Métodos-----------------------------------*/
        public Transicion(Componente v1, Componente v2)
        {
            componente1 = v1;
            componente2 = v2;
            feromonas = 0;
            atractivo = -1;
        }
        public Transicion(Componente v1, Componente v2, double nAtractivo)
        {
            componente1 = v1;
            componente2 = v2;
            feromonas = 0;
            atractivo = nAtractivo;
        }
        
        /// <summary>
        /// Obtiene el vertice vecino de v
        /// </summary>
        /// <param name="v">vertice de la arista del cual se quiere saber cual es su vecino en la arista</param>
        /// <returns>vecino en la arista de v</returns>
        public Componente get_vecino_de(Componente v)
        {
            if (componente1 == v)
                return componente2;
            else if (componente2 == v)
                return componente1;
            else
                throw new Exception("Vertice no pertecene arista");
        }
        /// <summary>
        /// Determina si la transicion conecta a v1 y v2
        /// </summary>
        /// <param name="v1">vertice quiere saber si conecta con </param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public Boolean conecta(Componente v1, Componente v2)
        {
            return (componente1 == v1 && componente2 == v2) || (componente1 == v2 && componente2 == v1);
        }
        
        public double get_atractivo()
        {
            return atractivo;
        }
        public void set_componentes(Componente v1, Componente v2)
        {
            componente1 = v1;
            componente2 = v2;
        }
        public void set_feromonas(double nFeromonas)
        {
            feromonas = nFeromonas;
        }
        public double get_feromonas()
        {
            return feromonas;
        }
    }
}
