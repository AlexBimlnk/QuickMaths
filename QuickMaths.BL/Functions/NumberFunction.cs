using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.BL.Functions
{
    //TODO: Особая функция, многие методы что она имплементирует не будут реализованы.
    //Может быть нужно перепроектирование?

    /// <summary>
    /// Числовая функция.
    /// <list type="bullet">
    ///     <item>
    ///         <term>4</term>
    ///         <description>Является числовой функцией.</description>
    ///     </item>
    ///     <item>
    ///         <term>242</term>
    ///         <description>Является числовой функцией.</description>
    ///     </item>
    /// </list>
    /// </summary>
    internal class NumberFunction : SimpleFunction
    {
        public NumberFunction(string stringFunction) : base(stringFunction)
        {
            Value = Convert.ToDouble(stringFunction);
        }
        public NumberFunction(double value) => Value = value;
        


        public double Value { get; }



        public override double Calculate()
        {
            return Value;
        }
        public override IFunction Derivative()
        {
            return null;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
