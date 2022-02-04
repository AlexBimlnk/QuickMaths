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

        public LinearFunction(double digit, Tree subTree = null):base(digit, subTree)
        {

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
                StringBuilder StrFuncBuilder = new StringBuilder();

                if (Digit != 1)
                    StrFuncBuilder.Append($"{Digit}*");

                if (SubFunctionTree == null)
                    StrFuncBuilder.Append('x');
                else
                { 
                    if (SubFunctionTree.Size == 1)
                        StrFuncBuilder.Append($"{SubFunctionTree}");
                    else
                        StrFuncBuilder.Append($"({SubFunctionTree})");
                }

                stringFunction = StrFuncBuilder.ToString();
            }

            return stringFunction;
        }
    }
}
