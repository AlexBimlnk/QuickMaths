using QuickMaths.FunctionsBLL.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.FunctionsBLL.Functions
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
    public class LinearFunction : IFunction
    {
        private string _stringFunction = string.Empty;

        public LinearFunction(IFunction argument) => Argument = argument ?? throw new ArgumentNullException(nameof(argument));
        public LinearFunction(IFunction argument, IFunction koef)
        {
            Argument = argument ?? throw new ArgumentNullException(nameof(argument));
            Koef = koef ?? throw new ArgumentNullException(nameof(koef));
        }
        public LinearFunction(string stringFunction, IFunction argument, IFunction? koef = default)
        {
            Argument = argument ?? throw new ArgumentNullException(nameof(argument));
            Koef = koef ?? new NumberFunction(1);
            _stringFunction = stringFunction;
        }


        public IFunction Koef { get; init; } = new NumberFunction(1);
        public IFunction Argument { get; init; }



        public double Calculate()
        {
            throw new NotImplementedException();
        }
        public IFunction Derivative()
        {
            throw new NotImplementedException();
        }
        public override string ToString() //Todo: ToString in LF
        {
            if (_stringFunction == String.Empty)
            {
                StringBuilder strFuncBuilder = new StringBuilder();

                
            }

            return _stringFunction;
        }
    }
}
