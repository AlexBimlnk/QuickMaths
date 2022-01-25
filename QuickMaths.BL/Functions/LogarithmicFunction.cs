using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.BL.Functions
{
    /// <summary>
    /// Логарифмическая функция.
    /// <list type="bullet">
    ///     <item>
    ///         <term>loge(3)</term>
    ///         <description>Является логарифмической функцией.</description>
    ///     </item>
    ///     <item>
    ///         <term>log2(x)</term>
    ///         <description>Является логарифмической функцией.</description>
    ///     </item>
    /// </list>
    /// </summary>
    internal class LogarithmicFunction : SimpleFunction, IDerivativable
    {
        /// <summary>
        /// Основание логарифма.
        /// </summary>
        public long Base { get; private set; }

        public LogarithmicFunction() { }

        public LogarithmicFunction(long digit) : base(digit) { }
        public LogarithmicFunction(long digit, long @base) : base(digit) { Base = @base; }

        public IFunction Derivative()
        {
            return new Function($"({Variable}*log{Base}({Digit}))^(-1)");
        }
    }
}
