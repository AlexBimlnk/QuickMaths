using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMathsBL
{
    public class Function : SimpleFunction
    {
        //TODO
        private double koef;
        public Function(double _kof) : base(_kof)
        {
            koef = _kof;
        }
        public static void DS()
        {
            Console.WriteLine("REQ");
        }
    }
}
