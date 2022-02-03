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
        protected Tree subFunctionTree;

        public double Digit { get; protected set; }

        public char Variable { get; protected set; }

        public Tree SubFunctionTree { get; protected set; }

        protected string StringFunction;

        public SimpleFunction() { }

        public SimpleFunction(double digit,Tree _SubTree = null)
        {
            Digit = digit;
            SubFunctionTree = _SubTree;
        }

        public SimpleFunction(string _StringFunction)
        {
            StringFunction = _StringFunction;

            if (TreeBuilder.IsComplex(ref _StringFunction))
            {
                SubFunctionTree = TreeBuilder.BuildTree(_StringFunction);
            }
        }

        public abstract IFunction Derivative();

    }
}
