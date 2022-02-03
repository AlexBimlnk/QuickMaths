﻿using System;
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
            Tree tree = new Tree();

            NumberFunction digit = new NumberFunction(Digit);
            IFunction power = (Digit - 1 == 1) ? new LinearFunction() : new PowerFunction(Digit - 1, SubFunctionTree);

            tree.AddNewMultiplier(digit);
            tree.AddNewMultiplier(power);

            if (SubFunctionTree != null)
                Tree.MergeMult(tree, SubFunctionTree.GetDerivative());

            return new CompositeFunction(tree);
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