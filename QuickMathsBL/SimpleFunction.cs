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
            NumberFunction,
            LinearFunction,
            PowerFunction
        }

        private static double e = Math.E;
        private static double pi = Math.PI;

        private double kof;
        private string typeFunction;
        private string stringEquals = "1";

        //Contructor
        public SimpleFunction(double _kof, TypeFuncion _typeSimpleFunc = TypeFuncion.Unkown)
        {
            kof = _kof;
            typeFunction = _typeSimpleFunc.ToString();
        }

        #region Функции
        private static List<SimpleFunction> SplitOnSimpleFunction(string function)
        {
            List<SimpleFunction> functionsList = new List<SimpleFunction>();
            //TODO


            return functionsList;
        }


        public override string ToString()
        {
            return stringEquals;
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

        public double GetKofFunction
        {
            get { return kof; }
        }

        public string GetTypeFunction
        {
            get { return typeFunction; }
        }

        public static double E
        {
            get { return e; }
        }
        public static double Pi
        {
            get { return pi; }
        }

        #endregion
    }
}
