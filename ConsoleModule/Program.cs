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

            SimpleFunction test = new SimpleFunction(12, SimpleFunction.TypeFuncion.LinearFunction);
            SimpleFunction test2 = new SimpleFunction(5);
            SimpleFunction test3 = new SimpleFunction(1, SimpleFunction.TypeFuncion.NumberFunction);

            Tree tree = new Tree(test);
            Console.WriteLine($"Data root: {tree.DataRoot}");
            Console.WriteLine($"Root node: {tree.RootNode}");
            ConsoleHelper.Start();

            Console.ReadKey();
        }
    }
}
