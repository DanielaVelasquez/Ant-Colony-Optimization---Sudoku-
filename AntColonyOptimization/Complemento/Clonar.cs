using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
            //Verificamos que sea serializable antes de hacer la copia
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("El tipo de dato debe ser serializable.", "fuente");
            }
            if (Object.ReferenceEquals(fuente, null))
            {
                return default(T);
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, fuente);
                stream.Seek(0, SeekOrigin.Begin);
                //Deserializamos la porcón de memoria en el nuevo objeto
                return (T)formatter.Deserialize(stream);
            }   
            /*
            String serializado = JsonConvert.SerializeObject(fuente);
            Console.WriteLine(serializado);
            return JsonConvert.DeserializeObject<T>(serializado);*/
        }
    }
}
