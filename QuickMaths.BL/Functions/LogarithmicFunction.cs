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
    //internal class LogarithmicFunction : SimpleFunction
    //{
    //    public LogarithmicFunction() { }
    //    public LogarithmicFunction(double value, Tree subTree = null) : base(value, subTree) { }
    //    public LogarithmicFunction(Variable variable, Tree subTree = null) : base(variable, subTree) { }
    //    public LogarithmicFunction(Variable variable, double @base, Tree subTree = null ) 
    //        : base(variable,subTree) { Base = @base; }
    //    public LogarithmicFunction(string stringFunction) : base(stringFunction)
    //    {
    //        Variable = new Variable(Convert.ToDouble(stringFunction.Substring(3, stringFunction.IndexOf('(') - 3)));
    //    }


    //    /// <summary>
    //    /// Основание логарифма.
    //    /// </summary>
    //    public double Base { get; private set; }


    //    public override double Calculate()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public override IFunction Derivative()
    //    {
    //        //return new CompositeFunction($"({Variable}*log{Base}({Digit}))^(-1
    //        Tree tree = new Tree();

    //        if (Variable.Value != Math.E)
    //        {
    //            NumberFunction digit = new NumberFunction(Variable.Value);
    //            Tree subTree = new Tree();
    //            subTree.AddNewMultiplier(digit);
    //            LogarithmicFunction logarithmicFunction = new LogarithmicFunction(Math.E, subTree);
    //            tree.AddNewMultiplier(logarithmicFunction);
    //        }
            
    //        if (SubFunctionTree != null)
    //            Tree.MergeMult(tree, SubFunctionTree.GetDerivative());
            
    //        return new PowerFunction(-1, tree);
    //    }
    //    public override string ToString()
    //    {
    //        if (stringFunction == String.Empty)
    //        {
    //            StringBuilder buildFuncStr = new StringBuilder("log");

    //            buildFuncStr.Append($" {Variable.Value}(");
    //            if (SubFunctionTree == null)
    //                buildFuncStr.Append("x)");
    //            else
    //                buildFuncStr.Append($"{SubFunctionTree})");
    //            stringFunction = buildFuncStr.ToString();
    //        }

    //        return stringFunction;
    //    } 
    //}
}
