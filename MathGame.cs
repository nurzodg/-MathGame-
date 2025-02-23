using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathGame
{
    class MathGame
    {
        /// <summary>
        /// содержит список операторов для выборки
        /// </summary>
        static public string[] MyOperators = { "Сложение (+)", "Вычатание (-)", "Умножение (*)", "Деление (÷)" };

        /// <summary>
        /// Рандомные числа для операндов
        /// </summary>
        static public Random _myRandom = new Random();

        /// <summary>
        /// Метод сложение чисел
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns></returns>
        static public int MyAddition(string numberOne, string numberTwo)
        {
           return Convert.ToInt32(numberOne) + Convert.ToInt32(numberTwo);
        }
        /// <summary>
        /// Метод вычитание
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns></returns>
        static public int MySubtraction(string numberOne, string numberTwo)
        {
            return Convert.ToInt32(numberOne) - Convert.ToInt32(numberTwo);
        }
        /// <summary>
        /// Метод умножение
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns></returns>
        static public int MyMultiplication(string numberOne, string numberTwo)
        {
            return Convert.ToInt32(numberOne) * Convert.ToInt32(numberTwo);
        }
        /// <summary>
        /// Метод деление
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns></returns>
        static public int MyDivision(string numberOne, string numberTwo)
        {
            return Convert.ToInt32(numberOne) / Convert.ToInt32(numberTwo);
        }
        /// <summary>
        /// Метод проверки ответа
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns></returns>
        static public bool CheckingActions(int numberInMethod, string numberInTextBox)
        {
            if (numberInMethod == Convert.ToInt32(numberInTextBox))
            
                return true;
            else
                return false;
            
        }

    }
}
