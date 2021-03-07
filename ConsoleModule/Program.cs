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
            //Tree tree = new Tree(test);
            //Console.WriteLine($"Data root: {tree.DataRoot}");
            //Console.WriteLine($"Root node: {tree.RootNode}");

            ConsoleHelper.Start();

            Console.ReadKey();
        }
    }
}
