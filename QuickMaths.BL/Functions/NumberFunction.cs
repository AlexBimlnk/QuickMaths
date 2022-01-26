using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.BL.Functions
{
    //TODO: Проблема в том, что она никогда не будет иметь переменных
    //что как бы уже проблема в проектировании, правильной иерархии, возможно
    //будет достаточно что она имлпементирует интерфейс IFunction. Ну короче надо будет подумать
    //насчет неё

    /// <summary>
    /// Числовая функция.
    /// <list type="bullet">
    ///     <item>
    ///         <term>4</term>
    ///         <description>Является числовой функцией.</description>
    ///     </item>
    ///     <item>
    ///         <term>242</term>
    ///         <description>Является числовой функцией.</description>
    ///     </item>
    /// </list>
    /// </summary>
    internal class NumberFunction : SimpleFunction
    {
        public NumberFunction() { }

        public NumberFunction(double digit) : base(digit) { }

        public NumberFunction(string _FuncString):base(_FuncString)
        {
            Digit = Convert.ToDouble(_FuncString);
        }

        public override IFunction Derivative()
        {
            return null;
        }
    }
}
