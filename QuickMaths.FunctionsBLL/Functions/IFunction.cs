using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.FunctionsBLL.DataStructure;

namespace QuickMaths.FunctionsBLL.Functions
{
    public interface IFunction 
    {

        /// <summary>
        /// Возвращает результат математической функции. 
        /// </summary>
        /// <returns> Результат типа <see cref="double"/>. </returns>
        public double Calculate();
        /// <summary>
        /// Возвращает производную данной функции.
        /// </summary>
        /// <returns> Функция, являющаяся производной от той, в котором был вызван этот метод. </returns>
        public IFunction Derivative();
    }
}
