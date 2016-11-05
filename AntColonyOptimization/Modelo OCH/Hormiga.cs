using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimization.Modelo_OCH
{
    public class Hormiga
    {
        /*-----------------------------------Atributos-----------------------------------*/ 
        /// <summary>
        /// Solución construida por la hormiga
        /// </summary>
        private Solucion solucion;
        /// <summary>
        /// Número identificador de la hormigas
        /// </summary>
        private int id;

        /*-----------------------------------Métodos-----------------------------------*/
        public Hormiga(int id)
        {
            this.id = id;
            solucion = null;
            //TODO: set la solucion al iniciar las hormigas en las solucion inicial
        }
        public Solucion getSolucion()
        {
            return solucion;
        }
        public void set_solucion(Solucion s)
        {
            solucion = s;
        }
        /// <summary>
        /// Determina la cantidad de feromonas que aplica la hormiga k, con base en la función de costo de su solución
        /// </summary>
        /// <param name="rho">Coeficiente evaporación feromonas</param>
        /// <returns>cantidad de feromonas aplica una hormiga</returns>
        public double funcion_feromonas(int tipo_optimizacion,double rho)
        {
            if (tipo_optimizacion == ColoniaHormigas.MAXIMIZAR)
                return (1 - rho) * solucion.funcion_costo();
            else if (tipo_optimizacion == ColoniaHormigas.MINIMIZAR)
                return (1 - rho) / solucion.funcion_costo();
            else
                throw new Exception("Valor tipo de optimización no válido");

        }

    }
}
