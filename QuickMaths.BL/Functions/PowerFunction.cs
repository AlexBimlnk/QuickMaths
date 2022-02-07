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
    //internal class PowerFunction : SimpleFunction
    //{
    //    public PowerFunction() { }
    //    public PowerFunction(double value, Tree subTree = null) : base(value, subTree) { }
    //    public PowerFunction(Variable variable, Tree subTree = null) : base(variable, subTree) { }
    //    public PowerFunction(string stringFunction) : base(stringFunction)
    //    {
    //        string[] arr = stringFunction.Split('^');
    //        Variable = new Variable(Convert.ToDouble(arr[arr.Length - 1]));
            
    //    }


    //    public override double Calculate()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public override IFunction Derivative()
    //    {
    //        //return new CompositeFunction($"{Digit}*{Variable}^{Digit - 1}");

    //        Tree SubTree = new Tree();

    //        IFunction ThisDer;
    //        if (Variable.Value == 2)
    //            ThisDer = new LinearFunction(Variable, SubFunctionTree);
    //        else
    //            ThisDer = new LinearFunction(Variable, new Tree(new PowerFunction(new Variable(Variable.Value - 1), SubFunctionTree)));
    //        SubTree.AddNewMultiplier(ThisDer);

    //        if (SubFunctionTree != null)
    //            Tree.MergeMult(SubTree, SubFunctionTree.GetDerivative());

    //        return new CompositeFunction(SubTree);
    //    }
    //    public override string ToString()
    //    {
    //        if (stringFunction == String.Empty)
    //        {
    //            StringBuilder buildFuncStr = new StringBuilder();

                
    //            if (SubFunctionTree == null)
    //                buildFuncStr.Append('x');
    //            else
    //                buildFuncStr.Append($"({SubFunctionTree})");

    //            buildFuncStr.Append($"^{Variable.Value}");
    //            stringFunction = buildFuncStr.ToString();
    //        }

    //        return stringFunction;
    //    }
    //}
}
