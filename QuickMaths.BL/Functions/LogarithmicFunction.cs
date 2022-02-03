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

        public LogarithmicFunction(double digit,Tree subtree = null) : base(digit,subtree) { }
        public LogarithmicFunction(double digit, double @base,Tree subtree = null ) : base(digit,subtree) { Base = @base; }

        public LogarithmicFunction(string _StringFunction) : base(_StringFunction)
        {
            Digit = Convert.ToDouble(_StringFunction.Substring(3, _StringFunction.IndexOf('(') - 3));
        }
        /// <summary>
        /// 1 / (x * ln a)
        /// </summary>
        /// <returns></returns>
        public override IFunction Derivative()
        {
            //return new CompositeFunction($"({Variable}*log{Base}({Digit}))^(-1
            Tree _Tree = new Tree();

            if (Digit != Math.E)
            {
                NumberFunction digit = new NumberFunction(Digit);
                Tree _SubTree = new Tree();
                _SubTree.AddNewMultiplier(digit);
                LogarithmicFunction logarithmicFunction = new LogarithmicFunction(Math.E, _SubTree);
                _Tree.AddNewMultiplier(logarithmicFunction);
            }
            
            if (SubFunctionTree != null)
                Tree.MergeMult(_Tree, SubFunctionTree.GetDerivative());
            
            return new PowerFunction(-1, _Tree);
        }

        public override string ToString()
        {
            if (StringFunction == "")
            {
                StringBuilder BuildFuncStr = new StringBuilder("log");

                BuildFuncStr.Append($" {Digit}(");
                if (subFunctionTree == null)
                    BuildFuncStr.Append("x)");
                else
                    BuildFuncStr.Append($"{SubFunctionTree})");
                StringFunction = BuildFuncStr.ToString();
            }

            return StringFunction;
        }
    }
}
