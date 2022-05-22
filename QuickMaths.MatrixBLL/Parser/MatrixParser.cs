using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickMaths.General.Abstractions;
using QuickMaths.General.DataStructure;

namespace QuickMaths.MatrixBLL.Parser;

/// <summary xml:lang = "ru">
/// Парсер для матриц.
/// </summary>
public class MatrixParser : ParserBase<IArithmeticable>
{
    /// <inheritdoc/>
    public override IArithmeticable Parse(string inputString) => throw new NotImplementedException();
    /// <inheritdoc/>
    public override bool TryParse(string inputString, out IArithmeticable result) => throw new NotImplementedException();
}
