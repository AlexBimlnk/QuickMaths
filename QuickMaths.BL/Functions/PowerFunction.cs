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

        public PowerFunction(double digit, Tree subTree = null) : base(digit, subTree) { }

        public PowerFunction(string stringFunction) : base(stringFunction)
        {
            string[] arr = stringFunction.Split('^');
            Digit = Convert.ToDouble(arr[arr.Length - 1]);
            
        }
        /// <summary>
        /// n*x^(n-1)
        /// </summary>
        /// <returns></returns>
        public override IFunction Derivative()
        {
            //return new CompositeFunction($"{Digit}*{Variable}^{Digit - 1}");

            Tree SubTree = new Tree();

            IFunction ThisDer;
            if (Digit == 2)
                ThisDer = new LinearFunction(Digit, SubFunctionTree);
            else
                ThisDer = new LinearFunction(Digit, new Tree(new PowerFunction(Digit - 1, SubFunctionTree)));
            SubTree.AddNewMultiplier(ThisDer);

            if (SubFunctionTree != null)
                Tree.MergeMult(SubTree, SubFunctionTree.GetDerivative());

            return new CompositeFunction(SubTree);
        }

        public override string ToString()
        {
            if (stringFunction == String.Empty)
            {
                StringBuilder buildFuncStr = new StringBuilder();

                
                if (SubFunctionTree == null)
                    buildFuncStr.Append('x');
                else
                    buildFuncStr.Append($"({SubFunctionTree})");

                buildFuncStr.Append($"^{Digit}");
                stringFunction = buildFuncStr.ToString();
            }

            return stringFunction;
        }
    }
}
