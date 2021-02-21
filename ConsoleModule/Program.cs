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
            SimpleFunction mySimpleFunc = new SimpleFunction(1, SimpleFunction.SimpleFunc.LinearFunction);
            SimpleFunction mySimpleFunc2 = new SimpleFunction(2);
            SimpleFunction mySimpleFunc3 = new SimpleFunction(SimpleFunction.E);
            Console.WriteLine($"Type: {mySimpleFunc.GetTypeFunction}\n Kof: {mySimpleFunc.GetKofFunction}");
            Console.WriteLine($"Type: {mySimpleFunc2.GetTypeFunction}\n Kof: {mySimpleFunc2.GetKofFunction}");
            Console.WriteLine($"Type: {mySimpleFunc3.GetTypeFunction}\n Kof: {mySimpleFunc3.GetKofFunction}");
            Console.ReadKey();
        }
    }
}
