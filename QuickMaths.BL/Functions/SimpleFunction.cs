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
        public SimpleFunction(string strFunction)
        {
            stringFunction = strFunction;
        }



        public abstract double Calculate();
        public abstract IFunction Derivative();
    }
}
