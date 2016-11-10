using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimization.Modelo_OCH
{
    /// <summary>
    /// Recibe información de los cambios de la colonia
    /// </summary>
    public interface ObservadorColonia
    {
        /// <summary>
        /// Invocado cuando una nueva hormiga inicia la construcción de su solución
        /// </summary>
        /// <param name="id_hormiga">identificador de la hormiga que inició la construcción de su solución</param>
        void inicia_construir_nueva_hormiga(int id_hormiga);
        /// <summary>
        /// Invocado cuando un nuevo componente se agrega a la solución de la hormiga
        /// </summary>
        /// <param name="c">Nuevo componente adicionado</param>
        void nuevo_componente_seleccionado(Componente c);
    }
}
