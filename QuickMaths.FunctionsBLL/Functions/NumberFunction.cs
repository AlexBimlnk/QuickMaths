using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.FunctionsBLL.Functions
{
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
    public class NumberFunction : IFunction
    {
        private string _stringFunction = string.Empty;

        public NumberFunction(string stringFunction)
        {
            if (stringFunction == string.Empty)
                throw new ArgumentException("stringFunction");

            _stringFunction = stringFunction ?? throw new ArgumentNullException("stringFunction");
            Value = Convert.ToDouble(stringFunction);
        }
        public NumberFunction(double value) => Value = value;
        


        public double Value { get; }



        public double Calculate()
        {
            return Value;
        }
        IFunction? IFunction.Derivative() => null;
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
