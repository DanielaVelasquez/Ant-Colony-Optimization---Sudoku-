using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimization.Modelo_OCH
{
    /// <summary>
    /// Componente problema
    /// </summary>
    public abstract class Componente:ICloneable 
    {
        /*-----------------------------------Atributos-----------------------------------*/
        /// <summary>
        /// Cantidad de feromonas almacenadas en el vértice
        /// </summary>
        protected double feromonas;
        /// <summary>
        /// Componentes vecinos del componente, es decir aquellos componentes a los cuales puede alcanzar el componente actual
        /// </summary>
        private Dictionary<Componente, Transicion> vecinos;
        /// <summary>
        /// Atractivo de tomar el vertice n eta
        /// </summary>
        protected double atractivo;
        /*-----------------------------------Métodos-----------------------------------*/

        public Componente()
        {
            feromonas = 0;
            vecinos = new Dictionary<Componente, Transicion>();
            atractivo = -1;
        }
        public Componente(double nAtractivo)
        {
            feromonas = 0;
            vecinos = new Dictionary<Componente, Transicion>();
            atractivo = nAtractivo;
        }

        public void set_feromonas(double nFeromonas)
        {
            feromonas = nFeromonas;
        }
        public double get_feromonas()
        {
            return feromonas;
        }
        public List<Transicion> get_transiciones()
        {
            List<Transicion> transiciones = new List<Transicion>();
            foreach(KeyValuePair<Componente,Transicion> t in vecinos)
            {
                transiciones.Add(t.Value);
            }
            return transiciones;
        }
        
        /// <summary>
        /// Obtiene los componentes vecinos
        /// </summary>
        /// <returns>vecinos vertice</returns>
        public List<Componente> N()
        {
            List<Componente> v = new List<Componente>();
            foreach (KeyValuePair<Componente, Transicion> t in vecinos)
            {
                v.Add(t.Key);
            }
            return v;
        }
        /// <summary>
        /// Obtiene la transicion que conecta al componente actual con el componente y
        /// </summary>
        /// <param name="y">componente a conectar</param>
        /// <returns>arista que une al vertice actual con vertice y</returns>
        public Transicion get_transicion_con(Componente y)
        {
            if (vecinos.ContainsKey(y))
                return vecinos[y];
            return null;
        }
        /// <summary>
        /// Busca las transiciones que conectan al componente actual con los componentes entregados
        /// </summary>
        /// <param name="componentes">componentes a los cuales se quiere encontrar la transicion</param>
        /// <returns>lista transiciones conectan al vertice con los vertices entregados</returns>
        public List<Transicion> get_arista_conecta(List<Componente> componentes)
        {
            List<Transicion> t = new List<Transicion>();
            foreach (Componente c in componentes)
            {
                if (vecinos.ContainsKey(c))
                    t.Add(vecinos[c]);
                else
                    throw new Exception("El componente " + c.ToString() + " no es vecino de " + this.ToString());
            }
            return t;
        }
        /// <summary>
        /// Elimina la transicion entre el componente actual y el componente de la transicion a
        /// </summary>
        /// <param name="a"></param>
        public void eliminar_transicion(Transicion a)
        {
            Componente vecino = null;
            if(vecinos.Values.Contains(a))
            {
                foreach (KeyValuePair<Componente, Transicion> t in vecinos)
                {
                    if (t.Value == a)
                        vecino = t.Key;
                }
            }
            //Elimina la arista de cada uno de los vertices
            vecino.remover_transicion_con(this);
            this.remover_transicion_con(vecino);
            a.set_componentes(null, null);
        }
        /// <summary>
        /// Elimina del diccionario de vecinos el componente c
        /// </summary>
        /// <param name="c">componente que ya no hace parte de los vecinos</param>
        public void remover_transicion_con(Componente c)
        {
            vecinos.Remove(c);
        }
        /// <summary>
        /// Elimina todos los vecinos del componente
        /// </summary>
        public void remover_vecinos()
        {
            int i = 0;
            while (vecinos.Count != 0)
            {
                KeyValuePair<Componente, Transicion> v = vecinos.ElementAt(i);
                Componente vecino = v.Key;
                Transicion a = v.Value;
                vecino.remover_transicion_con(this);
                this.remover_transicion_con(vecino);
                a.set_componentes(null, null);
            }
        }
        /// <summary>
        /// Crea la transicion entre el componente actual y el componente indicado
        /// </summary>
        /// <param name="c">componente con el cual se quiere establecer la transicion</param>
        public void crear_transicion_con(Componente c)
        {
            if (vecinos.ContainsKey(c))
                throw new Exception("Transición con " + c.ToString() + " establecida previamente");
            else
            {
                Transicion t = new Transicion(this, c);
                this.establecer_transicion(t);
                c.establecer_transicion(t);

            }
        }
        /// <summary>
        /// Crea la transicion
        /// </summary>
        /// <param name="t">Transicion que se desea establecer</param>
        public void establecer_transicion(Transicion t)
        {
            if(vecinos.ContainsKey(t.get_vecino_de(this)))
                throw new Exception("Transición con " + t.get_vecino_de(this).ToString() + " establecida previamente");
            vecinos.Add(t.get_vecino_de(this), t);
        }

        public Object Clone()
        {
            return MemberwiseClone();
        } 

        /// <summary>
        /// Calcula el atractivo del componente
        /// </summary>
        /// <param name="s">solución sobre la cual se quiere ver el atractivo</param>
        /// <returns></returns>
        public abstract double calcular_atractivo(Solucion s);
    }
}
