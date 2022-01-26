using QuickMaths.BL.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.BL.Functions
{
    /// <summary>
    /// Линейная функция.
    /// <list type="bullet">
    ///     <item>
    ///         <term>x</term>
    ///         <description>Является линейной функцией.</description>
    ///     </item>
    ///     <item>
    ///         <term>y</term>
    ///         <description>Является числовой функцией.</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class LinearFunction : SimpleFunction
    {
        public LinearFunction(string _FuncString) : base(_FuncString)
        {
           
        }

        public override IFunction Derivative()
        {
            return new NumberFunction(Digit);
        }
    }
}
