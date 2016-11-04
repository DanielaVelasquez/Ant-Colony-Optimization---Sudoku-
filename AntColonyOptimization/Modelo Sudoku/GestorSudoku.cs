using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyOptimization.Modelo_OCH;

namespace AntColonyOptimization.Modelo_Sudoku
{
    public class GestorSudoku: GestorProblema
    {
        /*-----------------------------------Atributos-----------------------------------*/

        /*-----------------------------------Métodos-----------------------------------*/
        public void ubicar_posicion_inicial(Random r, List<Hormiga> hormigas, Grafica grafica)
        {
            List<Componente> componentes = grafica.get_vertices();
            foreach(Hormiga k in hormigas)
            {
                int num = r.Next(0, componentes.Count);
                Componente inicio = componentes[num];
                k.getSolucion().cambiar_vertice_actual(inicio);
            }
            
        }
        public  Boolean completo(Solucion solucion)
        {
            return ((Sudoku)solucion).completo();

        }
        public  void configurar_grafica(Grafica g, Hormiga k)
        {
            Componente c = k.getSolucion().get_vertice_actual();
            g.eliminar_vertice(c);
        }
    }
}
