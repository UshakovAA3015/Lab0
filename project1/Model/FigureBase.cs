using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Базовый класс 
    /// для всех объёмных фигур
    /// </summary>
    public abstract class FigureBase
    {
        /// <summary>
        /// Свойство для расчёта объёма
        /// </summary>
        public abstract double Volume { get; }

        /// <summary>
        /// Метод проверки числа
        /// </summary>
        /// <param name="number">Число для проверки</param>
        /// <returns>Корректное число</returns>
        public static double CheckNumber(double number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Величина должна " +
                    "быть положительным числом!");
            }
            else
            {
                return number;
            }
        }
    }
}
