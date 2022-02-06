﻿using System;
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

            CompositeFunction sm2 = new CompositeFunction("15*x^2+4*x+x");
            Console.WriteLine(sm2.ToString());
            CompositeFunction sm = new CompositeFunction("3*x^2+4*x+5*(x+3)*log2(9)");
            Console.WriteLine(sm.ToString());
            //Function sm3 = new Function("3^x+x");


            //IFunction der_sm2 = sm.Derivative();
            //Console.WriteLine(der_sm2.ToString());


            Console.ReadKey();
        }
    }
}
