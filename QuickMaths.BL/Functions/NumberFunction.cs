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
        public NumberFunction() { }
        public NumberFunction(double value) => Variable = new Variable(value);
        public NumberFunction(Variable variable) : base(variable) { }
        public NumberFunction(string stringFunction) : base(stringFunction)
        {
            Variable = new Variable(Convert.ToDouble(stringFunction));
        }


        public override double Calculate()
        {
            return Variable.Value;
        }
        public override IFunction Derivative()
        {
            return null;
        }
        public override string ToString()
        {
            return Variable.Value.ToString();
        }
    }
}
