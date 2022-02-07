using System;
using QuickMaths.BL;
using QuickMaths.BL.Functions;
using QuickMaths.BL.Matrix;

namespace QuickMaths.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            //CompositeFunction sm1 = new CompositeFunction("15*x^2+4*x+x");
            //Console.WriteLine(sm1.ToString());
            //CompositeFunction sm2 = new CompositeFunction("15*x+4*x+x");
            //Console.WriteLine(sm2.ToString());


            IFunction sm2 = new CompositeFunction("x");
            Console.WriteLine(sm2.ToString());

            IFunction sm3 = new CompositeFunction("4*x");
            Console.WriteLine(sm3.ToString());

            IFunction sm4 = new CompositeFunction("4*(4 + x)");
            Console.WriteLine(sm4.ToString());

            IFunction sm5 = new CompositeFunction("4*(4 + 4*x)");
            Console.WriteLine(sm5.ToString());

            IFunction sm6 = new CompositeFunction("(4 + 4*x)*(4 + 4*x)");
            Console.WriteLine(sm6.ToString());

            IFunction sm7 = new CompositeFunction("15*x+4*x+x");
            Console.WriteLine(sm7.ToString());

            //CompositeFunction sm = new CompositeFunction("3*x^2+4*x+5*(x+3)*log2(9)");
            //Console.WriteLine(sm.ToString());
            //Function sm3 = new Function("3^x+x");


            //IFunction der_sm2 = sm.Derivative();
            //Console.WriteLine(der_sm2.ToString());


            Console.ReadKey();
        }
    }
}
