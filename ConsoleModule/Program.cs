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

            Function sm = new Function("1");
            SimpleFunction.SplitOnSimpleFunction(sm);
            //Tree tree = new Tree(test);
            //Console.WriteLine($"Data root: {tree.DataRoot}");
            //Console.WriteLine($"Root node: {tree.RootNode}");
            ConsoleHelper.Start();

            Console.ReadKey();
        }
    }
}
