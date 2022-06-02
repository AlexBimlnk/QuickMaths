using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickMaths.General.Abstractions;
using QuickMaths.General.DataStructure;

namespace QuickMaths.FunctionsBLL.Parser;

/// <summary xml:lang = "ru">
/// Парсер для функций.
/// </summary>
public class FunctionParser : ParserBase<IFunction>
{
    /// <inheritdoc/>
    public override ITreeExpression<IFunction> BuildExpression(string input) => throw new NotImplementedException();

    /// <inheritdoc/>
    public override IFunction Parse(string inputString) => throw new NotImplementedException();
    /// <inheritdoc/>
    public override bool TryParse(string inputString, out IFunction result) => throw new NotImplementedException();
    /// <inheritdoc/>
    public override Task<IFunction> ParseAsync(string inputString, CancellationToken token) => throw new NotImplementedException();
}
