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
            SimpleFunction mySimpleFunc = new SimpleFunction(1, SimpleFunction.TypeFuncion.LinearFunction);
            SimpleFunction mySimpleFunc2 = new SimpleFunction(2);
            SimpleFunction mySimpleFunc3 = new SimpleFunction(SimpleFunction.E);
            Console.WriteLine($"Type: {mySimpleFunc.GetTypeFunction}\n Kof: {mySimpleFunc.GetKofFunction}");
            Console.WriteLine($"Type: {mySimpleFunc2.GetTypeFunction}\n Kof: {mySimpleFunc2.GetKofFunction}");
            Console.WriteLine($"Type: {mySimpleFunc3.GetTypeFunction}\n Kof: {mySimpleFunc3.GetKofFunction}");
            Console.WriteLine(mySimpleFunc.ToString());
            Console.WriteLine(mySimpleFunc2.ToString());
            Console.WriteLine(mySimpleFunc2.Equals(mySimpleFunc));
            Console.WriteLine(SimpleFunction.Equals(mySimpleFunc, mySimpleFunc2));
            Function f = new Function(1);
            Console.WriteLine(f.GetTypeFunction);
            Console.ReadKey();
        }
    }
}
