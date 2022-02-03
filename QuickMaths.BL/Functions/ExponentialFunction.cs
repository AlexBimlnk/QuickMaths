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

        public ExponentialFunction(double digit,Tree subtree = null) : base(digit,subtree) { }

        public ExponentialFunction(string _StringFunction) : base(_StringFunction)
        {
            Digit = Convert.ToDouble(_StringFunction.Split('^')[0]);
        }

        /// <summary>
        /// a^x*log e(a)
        /// e^x
        /// </summary>
        /// <returns></returns>
        public override IFunction Derivative()
        { 
            Tree _Tree = new Tree();

            _Tree.AddNewMultiplier(this);

            if (Digit != Math.E)
            {
                Tree _SubTree = new Tree();
                NumberFunction digit = new NumberFunction(Digit);
                _SubTree.AddNewMultiplier(digit);
                LogarithmicFunction logarithmicFunction = new LogarithmicFunction(Math.E, _SubTree);
                _Tree.AddNewMultiplier(logarithmicFunction);
            }
            if (SubFunctionTree != null)
                Tree.MergeMult(_Tree, SubFunctionTree.GetDerivative());
            
            return new CompositeFunction(_Tree);
        }

        public override string ToString()
        {
            if (StringFunction == "")
            {
                StringBuilder BuildFuncStr = new StringBuilder();

                BuildFuncStr.Append($"{Digit}^");
                if (subFunctionTree == null)
                    BuildFuncStr.Append("x");
                else
                    BuildFuncStr.Append(SubFunctionTree.ToString());
                StringFunction = BuildFuncStr.ToString();
            }

            return StringFunction;
        }
    }
}
