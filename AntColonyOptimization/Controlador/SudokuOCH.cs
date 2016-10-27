using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimization.Controlador
{
    public class SudokuOCH
    {
        /*-----------------------------------Atributos-----------------------------------*/
        private static SudokuOCH instance = null;
        /*-----------------------------------Métodos-----------------------------------*/
        public static SudokuOCH get_instance()
        {
            if (instance == null)
                instance = new SudokuOCH();
            return instance;
        }

    }
}
