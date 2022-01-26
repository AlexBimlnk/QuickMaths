using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.DataStructure;

namespace QuickMaths.BL.Functions
{
    /// <summary>
    /// Степенная функция.
    /// <list type="bullet">
    ///     <item>
    ///         <term>x^2</term>
    ///         <description>Является степенной функцией.</description>
    ///     </item>
    ///     <item>
    ///         <term>y^4</term>
    ///         <description>Является степенной функцией.</description>
    ///     </item>
    /// </list>
    /// </summary>
    internal class PowerFunction : SimpleFunction
    {
        public PowerFunction() { }

        public PowerFunction(double digit) : base(digit) { }

        public PowerFunction(string _FuncString) : base(_FuncString)
        {
            string[] arr = _FuncString.Split('^');
            Digit = Convert.ToDouble(arr[arr.Length - 1]);
            
        }

        public override IFunction Derivative()
        {
            return new CompositeFunction($"{Digit}*{Variable}^{Digit - 1}");
        }
    }
}
