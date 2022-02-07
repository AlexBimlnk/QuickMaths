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
    //internal class ExponentialFunction : SimpleFunction
    //{
    //    public ExponentialFunction() { }
    //    public ExponentialFunction(Variable variable, Tree subTree = null) : base(variable, subTree) { }
    //    public ExponentialFunction(string stringFunction) : base(stringFunction)
    //    {
    //        Variable.Value = Convert.ToDouble(stringFunction.Split('^')[0]);
    //    }


    //    public override double Calculate()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public override IFunction Derivative()
    //    { 
    //        Tree tree = new Tree();

    //        tree.AddNewMultiplier(this);

    //        if (Variable.Value != Math.E)
    //        {
    //            Tree subTree = new Tree();
    //            NumberFunction digit = new NumberFunction(Variable);
    //            subTree.AddNewMultiplier(digit);
    //            LogarithmicFunction logarithmicFunction = new LogarithmicFunction(new Variable(Math.E), subTree);
    //            tree.AddNewMultiplier(logarithmicFunction);
    //        }
    //        if (SubFunctionTree != null)
    //            Tree.MergeMult(tree, SubFunctionTree.GetDerivative());
            
    //        return new CompositeFunction(tree);
    //    }
    //    public override string ToString()
    //    {
    //        if (stringFunction == String.Empty)
    //        {
    //            StringBuilder buildFuncStr = new StringBuilder();

    //            buildFuncStr.Append($"{Variable.Value}^");
    //            if (SubFunctionTree == null)
    //                buildFuncStr.Append('x');
    //            else
    //                buildFuncStr.Append(SubFunctionTree.ToString());
    //            stringFunction = buildFuncStr.ToString();
    //        }

    //        return stringFunction;
    //    }
    //}
}
