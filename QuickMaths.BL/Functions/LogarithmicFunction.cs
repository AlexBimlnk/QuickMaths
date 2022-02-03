using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.DataStructure;

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

        public LogarithmicFunction(double digit, Tree subTree = null) : base(digit, subTree) { }
        public LogarithmicFunction(double digit, double @base, Tree subTree = null ) 
            : base(digit,subTree) { Base = @base; }

        public LogarithmicFunction(string stringFunction) : base(stringFunction)
        {
            Digit = Convert.ToDouble(stringFunction.Substring(3, stringFunction.IndexOf('(') - 3));
        }

        /// <summary>
        /// 1 / (x * ln a)
        /// </summary>
        /// <returns></returns>
        public override IFunction Derivative()
        {
            //return new CompositeFunction($"({Variable}*log{Base}({Digit}))^(-1
            Tree tree = new Tree();

            if (Digit != Math.E)
            {
                NumberFunction digit = new NumberFunction(Digit);
                Tree subTree = new Tree();
                subTree.AddNewMultiplier(digit);
                LogarithmicFunction logarithmicFunction = new LogarithmicFunction(Math.E, subTree);
                tree.AddNewMultiplier(logarithmicFunction);
            }
            
            if (SubFunctionTree != null)
                Tree.MergeMult(tree, SubFunctionTree.GetDerivative());
            
            return new PowerFunction(-1, tree);
        }

        public override string ToString()
        {
            if (stringFunction == String.Empty)
            {
                StringBuilder buildFuncStr = new StringBuilder("log");

                buildFuncStr.Append($" {Digit}(");
                if (SubFunctionTree == null)
                    buildFuncStr.Append("x)");
                else
                    buildFuncStr.Append($"{SubFunctionTree})");
                stringFunction = buildFuncStr.ToString();
            }

            return stringFunction;
        }
    }
}
