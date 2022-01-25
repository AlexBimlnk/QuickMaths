using System;
using QuickMaths.BL;
using QuickMaths.BL.Functions;

namespace QuickMaths.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            CompositeFunction sm = new CompositeFunction("3*x^2 + 4*x + 5*(x+3)*log2(x)");
            CompositeFunction sm2 = new CompositeFunction("3*x^2*5 + 4*x + x");
            //Function sm3 = new Function("3^x+x");

            foreach (var i in sm.SubFunctionTree.CreateMultyWayList(sm.SubFunctionTree.Head))
            {
                Console.WriteLine(i.Data.ToString());
            }

            //Console.WriteLine(Derivative.GetDerivative(sm2));

            ConsoleHelper.Start();

            Console.ReadKey();
        }
    }
}
