using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.DataStructure;

namespace QuickMaths.BL.Functions
{
    public interface IFunction 
    {
        public Tree SubFunctionTree { get; }

        public string StringFunction { get; }


        /// <summary>
        /// Рассчитать производную.
        /// </summary>
        public abstract IFunction Derivative();
    }
}
