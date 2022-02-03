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

        public ExponentialFunction(double digit, Tree subTree = null) : base(digit, subTree) { }

        public ExponentialFunction(string stringFunction) : base(stringFunction)
        {
            Digit = Convert.ToDouble(stringFunction.Split('^')[0]);
        }

        /// <summary>
        /// a^x*log e(a)
        /// e^x
        /// </summary>
        /// <returns></returns>
        public override IFunction Derivative()
        { 
            Tree tree = new Tree();

            tree.AddNewMultiplier(this);

            if (Digit != Math.E)
            {
                Tree subTree = new Tree();
                NumberFunction digit = new NumberFunction(Digit);
                subTree.AddNewMultiplier(digit);
                LogarithmicFunction logarithmicFunction = new LogarithmicFunction(Math.E, subTree);
                tree.AddNewMultiplier(logarithmicFunction);
            }
            if (SubFunctionTree != null)
                Tree.MergeMult(tree, SubFunctionTree.GetDerivative());
            
            return new CompositeFunction(tree);
        }

        public override string ToString()
        {
            if (stringFunction == String.Empty)
            {
                StringBuilder buildFuncStr = new StringBuilder();

                buildFuncStr.Append($"{Digit}^");
                if (SubFunctionTree == null)
                    buildFuncStr.Append('x');
                else
                    buildFuncStr.Append(SubFunctionTree.ToString());
                stringFunction = buildFuncStr.ToString();
            }

            return stringFunction;
        }
    }
}
