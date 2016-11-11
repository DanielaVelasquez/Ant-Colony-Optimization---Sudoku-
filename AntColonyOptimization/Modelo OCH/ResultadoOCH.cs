using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimization.Modelo_OCH
{
    /// <summary>
    /// Resultados de un simulación, representa la función de costo de la solución encontrada por la hormiga k en una iteración
    /// </summary>
    public class ResultadoOCH
    {
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Iteración a la que pertenece el resultado
        /// </summary>
        private int iteracion;
        /// <summary>
        /// Identificador de la Hormiga que encontró la solución
        /// </summary>
        private int hormiga;
        /// <summary>
        /// Función de costo de la solución encontró la hormiga
        /// </summary>
        private double funcion_costo;

        /*-----------------------------------Métodos-----------------------------------*/
        public ResultadoOCH(int iteracion, int hormiga, double funcion_costo)
        {
            this.iteracion = iteracion;
            this.hormiga = hormiga;
            this.funcion_costo = funcion_costo;
        }

        public int getIteracion()
        {
            return iteracion;
        }
        public int getHormiga()
        {
            return hormiga;
        }
        public double getFuncionCosto()
        {
            return funcion_costo;
        }
    }
}
