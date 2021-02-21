using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public class SimpleFunction
    {
        public enum SimpleFunc
        {
            Unkown,
            LinearFunction,
            PowerFunction
        }

        private static double e = Math.E;
        private static double pi = Math.PI;

        private double kof;
        private string typeFunction;

        //Contructor
        public SimpleFunction(double _kof, SimpleFunc _typeSimpleFunc = SimpleFunc.Unkown)
        {
            kof = _kof;
            typeFunction = _typeSimpleFunc.ToString();
        }

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
    }
}
