using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.BL.Functions
{
    /// <summary>
    /// Показательная функция.
    /// <list type="bullet">
    ///     <item>
    ///         <term>e^x</term>
    ///         <description>Является показательной функцией.</description>
    ///     </item>
    ///     <item>
    ///         <term>2^y</term>
    ///         <description>Является показательной функцией.</description>
    ///     </item>
    /// </list>
    /// </summary>
    internal class ExponentialFunction : SimpleFunction, IDerivativable
    {
        public ExponentialFunction() { }

        public ExponentialFunction(long digit) : base(digit) { }

        public IFunction Derivative()
        {
            return new Function($"{Digit}^{Variable}*loge({Digit})");
        }
    }
}
