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

        public LinearFunction(string stringFunction) : base(stringFunction)
        {
            Digit = 1;
        }

        public override IFunction Derivative()
        {
            if (SubFunctionTree == null)
                return new NumberFunction(Digit);
            if (Digit == 1)
                return new CompositeFunction(SubFunctionTree.GetDerivative());

            Tree tree = new Tree();

            tree.AddNewMultiplier(new NumberFunction(Digit));
            

            Tree.MergeMult(tree, SubFunctionTree.GetDerivative());

            return new CompositeFunction(tree);
        }

        public override string ToString()
        {
            if (stringFunction == String.Empty)
            {
                if (SubFunctionTree == null)
                    stringFunction = "x";
                else
                    stringFunction = $"({SubFunctionTree})";
            }

            return stringFunction;
        }
    }
}
