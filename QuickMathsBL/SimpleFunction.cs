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


        public string functionString = "";

        private double digit; 

        private TypeFuncion typeFunction;

        //Contructor
        public SimpleFunction(string function, TypeFuncion _typeSimpleFunc = TypeFuncion.Unkown)
        {
            functionString = function;
            SetTypeFunction();
            SetDigit();
        }

        #region Функции

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

        private void SetDigit()
        {
            switch (typeFunction)
            {
                case TypeFuncion.NumberFunction:
                    digit = Convert.ToDouble(functionString);
                    break;
                case TypeFuncion.LinearFunction:
                    digit = 1;
                    break;
                case TypeFuncion.PowerFunction:
                    string[] arr = functionString.Split('^');
                    digit = Convert.ToDouble(arr[arr.Length-1]);
                    break;
                case TypeFuncion.ExponentialFunction:
                    digit = Convert.ToDouble(functionString.Split('^')[0]);
                    break;
                case TypeFuncion.LogarithmicFunction:
                    digit = Convert.ToDouble(functionString.Substring(3, functionString.IndexOf('(') - 3));
                    break;
            }
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
