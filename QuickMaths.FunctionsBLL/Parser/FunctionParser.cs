using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickMaths.General.Abstractions;
using QuickMaths.General.DataStructure;
using System.Text.RegularExpressions;

using QuickMaths.FunctionsBLL.Functions;

namespace QuickMaths.FunctionsBLL.Parser;

/// <summary xml:lang = "ru">
/// Парсер для функций.
/// </summary>
public class FunctionParser : ParserBase<IFunction>
{
    /// <inheritdoc/>
    public override ITreeExpression<IFunction> BuildExpression(string input)
    {
        var expression = new TreeExpression<IFunction>(new NumberFunction(2));



        return expression;
    }

    /// <inheritdoc/>
    public override IFunction Parse(string inputString)
    {
        var var = new VariableFunction(inputString);
        return var;
    }
    /// <inheritdoc/>
    public override bool TryParse(string inputString, out IFunction result) => throw new NotImplementedException();
    /// <inheritdoc/>
    public override Task<IFunction> ParseAsync(string inputString, CancellationToken token) => throw new NotImplementedException();
}
