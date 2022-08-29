using System;
using System.Collections.Generic;

using QuickMaths.CMD.Cmd;
using QuickMaths.FunctionsBLL.Functions;
using QuickMaths.General;
using QuickMaths.General.Abstractions;
using QuickMaths.General.DataStructure;
using QuickMaths.General.DataStructure.Nodes;

namespace QuickMaths.CMD;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Hello World!");

        var a = new VariableFunction("a");
        var b = new VariableFunction("b");
        var c = new VariableFunction("c");
        var d = new VariableFunction("d");
        var e = new VariableFunction("e");
        var f = new VariableFunction("f");

        /*var treea = new TreeExpression<IFunction>(a);
        treea.Add(ArithmeticOperator.Multiply, a);


        var treeb = new TreeExpression<IFunction>(b);
        treeb.Add(ArithmeticOperator.Multiply, b);
        treeb.Add(ArithmeticOperator.Multiply, b);

        Console.WriteLine(treea);
        Console.WriteLine(treeb);

        treea.Add(ArithmeticOperator.Multiply, treeb);

        Console.WriteLine(treea);
        Console.WriteLine(treeb);

        treeb.Add(ArithmeticOperator.Multiply, b);

        Console.WriteLine(treea);
        Console.WriteLine(treeb);

        Console.WriteLine(treea.GetStringView());*/

        /*var treea = new TreeExpression<IFunction>(a);
        //treea.Add(ArithmeticOperator.Multiply, a);


        var treeb = new TreeExpression<IFunction>(b);
        //.Add(ArithmeticOperator.Multiply, b);

        treea.Add(ArithmeticOperator.Plus, treeb);

        Console.WriteLine(treea);
        Console.WriteLine(treeb);

        treea.Add(ArithmeticOperator.Multiply, a);
        treeb.Add(ArithmeticOperator.Multiply, b);
        Console.WriteLine(treea);
        Console.WriteLine(treeb);


        Console.WriteLine();
        Console.WriteLine(treea.GetStringView());
        Console.WriteLine();
        Console.WriteLine(treeb.GetStringView());
        Console.WriteLine();*/

        //a + b + c

        var tree1 = new TreeExpression<IFunction>(a);
        //tree1.Add(ArithmeticOperator.Plus, a);
        tree1.Add(ArithmeticOperator.Plus, b);
        tree1.Add(ArithmeticOperator.Plus, c);


        var tree4 = new TreeExpression<IFunction>(a);
        //tree4.Add(ArithmeticOperator.Multiply, a);
        tree4.Add(ArithmeticOperator.Multiply, c);



        var tree3 = new TreeExpression<IFunction>(a);
        //tree3.Add(ArithmeticOperator.Plus, a);
        tree3.Add(ArithmeticOperator.Plus, b);
        tree3.Add(ArithmeticOperator.Plus, c);



        //b * c * d + d * a

        var tree2 = new TreeExpression<IFunction>(b);
        tree2.Add(ArithmeticOperator.Multiply, c);
        tree2.Add(ArithmeticOperator.Multiply, d);

        var tree21 = new TreeExpression<IFunction>(d);
        tree21.Add(ArithmeticOperator.Multiply, a);

        tree2.Add(ArithmeticOperator.Plus, tree21);

        tree1.Add(ArithmeticOperator.Plus, tree3);
        tree3.Add(ArithmeticOperator.Plus, a);
        tree3.Add(ArithmeticOperator.Plus, b);
        tree3.Add(ArithmeticOperator.Plus, c);
        tree3.Add(ArithmeticOperator.Multiply, c);

        Console.WriteLine(tree3);
        Console.WriteLine(tree1);


        Console.ReadLine();


        //CompositeFunction sm1 = new CompositeFunction("15*x^2+4*x+x");
        //Console.WriteLine(sm1.ToString());
        //CompositeFunction sm2 = new CompositeFunction("15*x+4*x+x");
        //Console.WriteLine(sm2.ToString());


        //IFunction sm2 = new CompositeFunction("x");
        //Console.WriteLine(sm2.ToString());

        //IFunction sm3 = new CompositeFunction("4*x");
        //Console.WriteLine(sm3.ToString());

        //IFunction sm4 = new CompositeFunction("4*(4 + x)");
        //Console.WriteLine(sm4.ToString());

        //IFunction sm5 = new CompositeFunction("4*(4 + 4*x)");
        //Console.WriteLine(sm5.ToString());

        //IFunction sm6 = new CompositeFunction("(4 + 4*x)*(4 + 4*x)");
        //Console.WriteLine(sm6.ToString());

        //IFunction sm7 = new CompositeFunction("15*x+4*x+x");
        //Console.WriteLine(sm7.ToString());


        ConsoleHelper.Start();

        Console.ReadKey();
    }
}
