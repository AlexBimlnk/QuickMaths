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

            CompositeFunction sm = new CompositeFunction("3*x^2 + 4*x + 5*(x+3)*log2(x)");
            CompositeFunction sm2 = new CompositeFunction("3*x^2*5 + 4*x + x");
            //Function sm3 = new Function("3^x+x");

            foreach (var i in sm.SubFunctionTree.CreateMultyWayList(sm.SubFunctionTree.Head))
            {
                Console.WriteLine(i.Data.ToString());
            }

            //Console.WriteLine(Derivative.GetDerivative(sm2));

            //ConsoleHelper.Start();

            double[,] tb = { { 1, 2, 3},
                             { 4, 5, 6},
                             { 7, 8, 9}};

            Matrix matrix1 = new Matrix(tb);
            Matrix matrix2 = new Matrix(tb);
            Matrix matrix3 = matrix1 + matrix2*-1;

            Console.WriteLine(matrix3[0,0]);

            Console.ReadKey();
        }
    }
}
