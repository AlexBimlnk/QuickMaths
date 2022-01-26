using QuickMaths.BL.DataStructure;
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
    internal class ExponentialFunction : SimpleFunction
    {
        public ExponentialFunction() { }

        public ExponentialFunction(double digit) : base(digit) { }

        public ExponentialFunction(string _FuncString): base(_FuncString)
        {
            Digit = Convert.ToDouble(_FuncString.Split('^')[0]);
        }

        public override IFunction Derivative()
        {
            return new CompositeFunction($"{Digit}^{Variable}*loge({Digit})");
        }
    }
}
