using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.DataStructure;

namespace QuickMaths.BL.Functions
{
    /// <summary>
    /// Степенная функция.
    /// <list type="bullet">
    ///     <item>
    ///         <term>x^2</term>
    ///         <description>Является степенной функцией.</description>
    ///     </item>
    ///     <item>
    ///         <term>y^4</term>
    ///         <description>Является степенной функцией.</description>
    ///     </item>
    /// </list>
    /// </summary>
    internal class PowerFunction : SimpleFunction
    {
        public PowerFunction() { }

        public PowerFunction(double digit,Tree subtree = null) : base(digit,subtree) { }

        public PowerFunction(string _StringFunction) : base(_StringFunction)
        {
            string[] arr = _StringFunction.Split('^');
            Digit = Convert.ToDouble(arr[arr.Length - 1]);
            
        }
        /// <summary>
        /// n*x^(n-1)
        /// </summary>
        /// <returns></returns>
        public override IFunction Derivative()
        {
            //return new CompositeFunction($"{Digit}*{Variable}^{Digit - 1}");
            Tree _Tree = new Tree();

            NumberFunction digit = new NumberFunction(Digit);
            IFunction power = (Digit - 1 == 1) ? new LinearFunction() : new PowerFunction(Digit - 1, this.SubFunctionTree);

            _Tree.AddNewMultiplier(digit);
            _Tree.AddNewMultiplier(power);

            if (subFunctionTree != null)
                Tree.MergeMult(_Tree, subFunctionTree.GetDerivative());

            return new CompositeFunction(_Tree);
        }

        public override string ToString()
        {
            if (StringFunction == "")
            {
                StringBuilder BuildFuncStr = new StringBuilder();

                
                if (subFunctionTree == null)
                    BuildFuncStr.Append("x");
                else
                    BuildFuncStr.Append($"({SubFunctionTree})");

                BuildFuncStr.Append($"^{Digit}");
                StringFunction = BuildFuncStr.ToString();
            }

            return StringFunction;
        }
    }
}
