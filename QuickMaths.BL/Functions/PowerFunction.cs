using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    internal class PowerFunction : SimpleFunction, IDerivativable
    {
        public PowerFunction() { }

        public PowerFunction(long digit) : base(digit) { }

        public IFunction Derivative()
        {
            return new Function($"{Digit}*{Variable}^{Digit - 1}");
        }
    }
}
