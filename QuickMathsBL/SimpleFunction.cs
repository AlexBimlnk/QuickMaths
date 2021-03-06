using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public class SimpleFunction
    {
        //Расставить веса?
        public enum TypeFuncion
        {
            Unkown,
            NumberFunction,         //Числовая
            LinearFunction,         //Линейная
            PowerFunction,          //Степенная
            ExponentialFunction,    //Показательная
            LogarithmicFunction     //Логарифмическая
        }

        private static double e = Math.E;
        private static double pi = Math.PI;



        public string functionString = "";

        private TypeFuncion typeFunction;

        //Contructor
        public SimpleFunction(string function, TypeFuncion _typeSimpleFunc = TypeFuncion.Unkown)
        {
            functionString = function;
            SetTypeFunction();
        }

        #region Функции
        //public static List<SimpleFunction> SplitOnSimpleFunction(Function function)
        //{
        //    List<SimpleFunction> functionsList = new List<SimpleFunction>();
        //    //TODO

        //    //a = function.ToString().Split();

        //    SimpleFunction sim = new SimpleFunction("x");       //(a[i])
        //    SimpleFunction sim2 = new SimpleFunction("4");
        //    SimpleFunction sim3 = new SimpleFunction("x^2");
        //    SimpleFunction sim4 = new SimpleFunction("32^x");
        //    SimpleFunction sim5 = new SimpleFunction("log_2_x");

        //    SimpleFunction.SetTypeFunction(sim);
        //    SimpleFunction.SetTypeFunction(sim2);
        //    SimpleFunction.SetTypeFunction(sim3);
        //    SimpleFunction.SetTypeFunction(sim4);
        //    SimpleFunction.SetTypeFunction(sim5);

        //    Console.WriteLine($"Type sim = {sim.GetTypeFunction}");
        //    Console.WriteLine($"Type sim2 = {sim2.GetTypeFunction}");
        //    Console.WriteLine($"Type sim3 = {sim3.GetTypeFunction}");
        //    Console.WriteLine($"Type sim4 = {sim4.GetTypeFunction}");
        //    Console.WriteLine($"Type sim5 = {sim5.GetTypeFunction}");

        //    return functionsList;
        //}

        //private static void SetTypeFunction(SimpleFunction function)
        //{
        //    int result;
        //    string name = function.ToString();
        //    if(int.TryParse(name, out result))
        //        function.typeFunction = TypeFuncion.NumberFunction.ToString();

        //    else if (name.Contains("^"))
        //    {
        //        if (int.TryParse(name[name.IndexOf("^") - 1].ToString(), out result))
        //            function.typeFunction = TypeFuncion.ExponentialFunction.ToString();
        //        else
        //            function.typeFunction = TypeFuncion.PowerFunction.ToString();
        //    }

        //    else if (name.Contains("log"))
        //        function.typeFunction = TypeFuncion.LogarithmicFunction.ToString();

        //    else
        //        function.typeFunction = TypeFuncion.LinearFunction.ToString();
        //}

        public void SetTypeFunction()
        {
            
            if (functionString[functionString.Length - 1] == ')' && functionString[0] == '(')
                this.typeFunction = TypeFuncion.LinearFunction;

            else if (functionString.Length >= 3 && functionString.Substring(0, 3) == "log")
                this.typeFunction = TypeFuncion.LogarithmicFunction;

            else if (functionString[0] == 'e')
                this.typeFunction = TypeFuncion.ExponentialFunction;

            else if (functionString.Contains('^') == true)
                this.typeFunction = TypeFuncion.PowerFunction;

            else if (functionString[0] >= '0' && functionString[0] <= '9')
                this.typeFunction = TypeFuncion.NumberFunction;

            else if (functionString[0] == 'x')
                this.typeFunction = TypeFuncion.LinearFunction;

            else
                this.typeFunction = TypeFuncion.Unkown;
        }

        public override string ToString()
        {
            return functionString;
        }

        public static bool Equals(SimpleFunction obj1, SimpleFunction obj2)
        {
            if (obj1.ToString() == obj2.ToString())
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            if (ToString() == obj.ToString())
                return true;
            return false;
        }

        //?
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Свойства

        public TypeFuncion GetTypeFunction
        {
            get { return typeFunction; }
        }


        #endregion
    }
}
