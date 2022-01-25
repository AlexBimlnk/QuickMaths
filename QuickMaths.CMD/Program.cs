using System;
using QuickMaths.BL;

namespace QuickMaths.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            Function sm = new Function("3*x^2 + 4*x + 5*(x+3)*log2(x)");
            Function sm2 = new Function("3*x^2*5 + 4*x + x");
            //Function sm3 = new Function("3^x+x");

            foreach (var i in sm.FunctionTree.CreateMultyWayList(sm.FunctionTree.Head))
            {
                Console.WriteLine(i.Data.FunctionString);
            }

            Console.WriteLine(Derivative.GetDerivative(sm2));

            ConsoleHelper.Start();

            Console.ReadKey();
        }
    }
}
