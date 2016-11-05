using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AntColonyOptimization.Complemento
{
    public static class Clonar<T>
    {
        /// <summary>
        /// Clona un objeto en forma profunda
        /// </summary>
        /// <typeparam name="T">Tipo objeto</typeparam>
        /// <param name="fuente">Objeto a clonar</param>
        /// <returns>copia profunda de fuente</returns>
        public static T Clonacion(T fuente)
        {
            String serializado = JsonConvert.SerializeObject(fuente);
            return JsonConvert.DeserializeObject<T>(serializado);
        }
    }
}
