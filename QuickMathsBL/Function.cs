using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public class Function : SimpleFunction
    {
        //TODO
        private string stringEquals = "1";
        public Function(string _function) : base(_function)
        {
            stringEquals = _function;
        }
        public static void DS()
        {
            Console.WriteLine("REQ");
        }
    }
}
