using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.DataStructure;

namespace QuickMaths.BL.Functions
{
    public abstract class SimpleFunction : IFunction
    {
        protected string stringFunction = String.Empty;
        

        public SimpleFunction() { }
        public SimpleFunction(double value, Tree subTree = null)
        {
            Variable = new Variable(value);
            SubFunctionTree = subTree;
        }
        public SimpleFunction(Variable variable, Tree subTree = null)
        {
            Variable = variable;
            SubFunctionTree = subTree;
        }
        //public SimpleFunction(double digit, Tree subTree = null)
        //{
        //    //Digit = digit;
        //    SubFunctionTree = subTree;
        //}
        public SimpleFunction(string strFunction)
        {
            stringFunction = strFunction;

            if (TreeBuilder.IsComplex(ref strFunction))
            {
                SubFunctionTree = TreeBuilder.BuildTree(strFunction);
            }
        }


        //public double Digit { get; protected set; }
        public Variable Variable { get; protected set; }
        public Tree SubFunctionTree { get; protected set; }
        public List<IFunction> Arguments => throw new NotImplementedException();


        public abstract double Calculate();
        public abstract IFunction Derivative();
    }
}
