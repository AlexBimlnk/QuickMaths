using System;
using System.Collections.Generic;
using QuickMaths.BL;
using QuickMaths.BL.Functions;
using QuickMaths.BL.Matrix;
using QuickMaths.CMD.Cmd;

namespace QuickMaths.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            List<IFunction> list = new List<IFunction>()
            {
                new NumberFunction(1),
                new CompositeFunction("4*x")
            };

            //NumberFunction numberFunction = new NumberFunction(1);
            //numberFunction.Derivative() -> Ошибка, метод скрыт.
            //Но так метод вызвать можно
            foreach (var i in list)
                Console.WriteLine($"Deravative {i} = {i.Derivative()}"); 
            

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


            ConsoleHelper.Start();

            Console.ReadKey();
        }
    }
}
