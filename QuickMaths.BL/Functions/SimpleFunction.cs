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

        public double Digit { get; protected set; }

        public char Variable { get; protected set; }

        public Tree SubFunctionTree { get; protected set; }

        public SimpleFunction() { }

        public SimpleFunction(double digit, Tree subTree = null)
        {
            Digit = digit;
            SubFunctionTree = subTree;
        }

        public SimpleFunction(string strFunction)
        {
            stringFunction = strFunction;

            if (TreeBuilder.IsComplex(ref strFunction))
            {
                SubFunctionTree = TreeBuilder.BuildTree(strFunction);
            }
        }

        public abstract IFunction Derivative();

    }
}
