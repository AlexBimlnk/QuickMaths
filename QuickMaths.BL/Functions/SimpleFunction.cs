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

        public string StringFunction { get; protected set; }

        public SimpleFunction() { }

        public SimpleFunction(double digit)
        {
            Digit = digit;
        }

        public SimpleFunction(string _FuncString)
        {
            StringFunction = _FuncString;

            if (TreeBuilder.IsComplex(ref _FuncString))
            {
                SubFunctionTree = TreeBuilder.BuildTree(_FuncString);
            }
        }

        public abstract IFunction Derivative();

    }
}
