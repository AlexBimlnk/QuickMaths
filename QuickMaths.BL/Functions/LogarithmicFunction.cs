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
    internal class LogarithmicFunction : SimpleFunction
    {
        /// <summary>
        /// Основание логарифма.
        /// </summary>
        public double Base { get; private set; }

        public LogarithmicFunction() { }

        public LogarithmicFunction(double digit) : base(digit) { }
        public LogarithmicFunction(double digit, double @base) : base(digit) { Base = @base; }

        public LogarithmicFunction(string _FuncString) : base(_FuncString)
        {
            Digit = Convert.ToDouble(_FuncString.Substring(3, _FuncString.IndexOf('(') - 3));
        }

        public override IFunction Derivative()
        {
            return new CompositeFunction($"({Variable}*log{Base}({Digit}))^(-1)");
        }
    }
}
