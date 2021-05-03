using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMathsBL;

namespace ConsoleModule
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO
            //text


            Function sm = new Function("3*x^2 + 4*x + 5*(x+3)*log2(x)");
            Function sm2 = new Function("3*x^2*5 + 4*x + x");
            Function sm3 = new Function("3^x+x");

            foreach(var i in sm.FunctionTree.CreatePlusWayList())
            {
                Console.WriteLine(i.Data.FunctionString);
            }

            Console.WriteLine(Derivative.GetDerivative(sm3));

            ConsoleHelper.Start();

            Console.ReadKey();
        }
    }
}
