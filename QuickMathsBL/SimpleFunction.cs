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


        public string FunctionString { get; private set; }

        public double Digit { get; private set; } 

        public TypeFuncion TypeFunction { get; private set; }

        //Contructor
        public SimpleFunction(string function, TypeFuncion _typeSimpleFunc = TypeFuncion.Unkown)
        {
            FunctionString = function;
            SetTypeFunction();
            SetDigit();
        }

        #region Функции

        private void SetTypeFunction()
        {
            
            if (FunctionString[FunctionString.Length - 1] == ')' && FunctionString[0] == '(')
                this.TypeFunction = TypeFuncion.LinearFunction;

            else if (FunctionString.Length >= 3 && FunctionString.Substring(0, 3) == "log")
                this.TypeFunction = TypeFuncion.LogarithmicFunction;

            else if (FunctionString[0] == 'e')
                this.TypeFunction = TypeFuncion.ExponentialFunction;

            else if (FunctionString.Contains('^') == true)
                this.TypeFunction = TypeFuncion.PowerFunction;

            else if (FunctionString[0] >= '0' && FunctionString[0] <= '9')
                this.TypeFunction = TypeFuncion.NumberFunction;

            else if (FunctionString[0] == 'x')
                this.TypeFunction = TypeFuncion.LinearFunction;

            else
                this.TypeFunction = TypeFuncion.Unkown;
        }

        private void SetDigit()
        {
            switch (TypeFunction)
            {
                case TypeFuncion.NumberFunction:
                    Digit = Convert.ToDouble(FunctionString);
                    break;
                case TypeFuncion.LinearFunction:
                    Digit = 1;
                    break;
                case TypeFuncion.PowerFunction:
                    string[] arr = FunctionString.Split('^');
                    Digit = Convert.ToDouble(arr[arr.Length-1]);
                    break;
                case TypeFuncion.ExponentialFunction:
                    Digit = Convert.ToDouble(FunctionString.Split('^')[0]);
                    break;
                case TypeFuncion.LogarithmicFunction:
                    Digit = Convert.ToDouble(FunctionString.Substring(3, FunctionString.IndexOf('(') - 3));
                    break;
            }
        }


        //Сравнение объектов (возможно будет не нужен)
        //Наверное такое сравнение лучше реализовать в классе function
        #region Сравнение
        public static bool Equals(SimpleFunction obj1, SimpleFunction obj2)
        {
            if (obj1.FunctionString == obj2.FunctionString)
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            if (FunctionString == obj.ToString())
                return true;
            return false;
        }

        //?
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion 
        
        #endregion

        #region Свойства


        #endregion
    }
}
