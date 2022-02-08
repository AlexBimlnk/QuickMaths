using QuickMaths.BL.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.BL.Functions
{
    /// <summary>
    /// Линейная функция.
    /// <list type="bullet">
    ///     <item>
    ///         <term>x</term>
    ///         <description>Является линейной функцией.</description>
    ///     </item>
    ///     <item>
    ///         <term>4*y</term>
    ///         <description>Является линейной функцией.</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class LinearFunction : SimpleFunction
    {
        public LinearFunction(string stringFunction, IFunction argument, 
                              IFunction koef = null) : base(stringFunction)
        {
            if (koef != null)
                Koef = koef;
            Argument = argument;
        }
        public LinearFunction(IFunction argument,
                              IFunction koef = null)
        {
            if (koef != null)
                Koef = koef;
            Argument = argument;
        }




        public IFunction Koef { get; set; } = new NumberFunction(1);
        public IFunction Argument { get; set; }



        public override double Calculate()
        {
            throw new NotImplementedException();
        }
        public override IFunction Derivative()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            if (stringFunction == String.Empty)
            {
                StringBuilder strFuncBuilder = new StringBuilder();

                //Todo: ToString in LF
            }

            return stringFunction;
        }
    }
}
