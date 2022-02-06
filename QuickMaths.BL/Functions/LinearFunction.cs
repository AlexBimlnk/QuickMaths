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
    ///         <term>4*y</term>
    ///         <description>Является линейной функцией.</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class LinearFunction : SimpleFunction
    {
        public LinearFunction() { }
        public LinearFunction(double value, Tree subTree = null) : base(value, subTree) { }
        public LinearFunction(Variable variable, Tree subTree = null) : base(variable, subTree) { }
        public LinearFunction(string stringFunction) : base(stringFunction)
        {
            Variable = new Variable(1);
        }


        public override double Calculate()
        {
            throw new NotImplementedException();
        }
        public override IFunction Derivative()
        {
            if (SubFunctionTree == null)
                return new NumberFunction(Variable.Value);
            if (Variable.Value == 1)
                return new CompositeFunction(SubFunctionTree.GetDerivative());

            Tree tree = new Tree();

            tree.AddNewMultiplier(new NumberFunction(Variable.Value));
            

            Tree.MergeMult(tree, SubFunctionTree.GetDerivative());

            return new CompositeFunction(tree);
        }
        public override string ToString()
        {
            if (stringFunction == String.Empty)
            {
                StringBuilder strFuncBuilder = new StringBuilder();

                if (Variable.Value != 1)
                    strFuncBuilder.Append($"{Variable.Value}*");

                if (SubFunctionTree == null)
                    strFuncBuilder.Append('x');
                else
                { 
                    if (SubFunctionTree.Size == 1)
                        strFuncBuilder.Append($"{SubFunctionTree}");
                    else
                        strFuncBuilder.Append($"({SubFunctionTree})");
                }

                stringFunction = strFuncBuilder.ToString();
            }

            return stringFunction;
        }
    }
}
