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
        public LinearFunction()
        { }

        public LinearFunction(string _StringFunction) : base(_StringFunction)
        {
            Digit = 1;
        }

        public override IFunction Derivative()
        {
            if (SubFunctionTree == null)
                return new NumberFunction(Digit);
            if (Digit == 1)
                return new CompositeFunction(SubFunctionTree.GetDerivative());

            Tree _Tree = new Tree();

            _Tree.AddNewMultiplier(new NumberFunction(Digit));
            

            Tree.MergeMult(_Tree, SubFunctionTree.GetDerivative());

            return new CompositeFunction(_Tree);
        }

        public override string ToString()
        {
            if (StringFunction == "")
            {
                if (subFunctionTree == null)
                    StringFunction = "x";
                else
                    StringFunction = $"({SubFunctionTree})";
            }

            return StringFunction;
        }
    }
}
