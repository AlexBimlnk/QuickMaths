using QuickMaths.General.Abstractions;

namespace QuickMaths.MatrixBLL.Parser;

/// <summary xml:lang = "ru">
/// Парсер для матриц.
/// </summary>
public class MatrixParser : ParserBase<Matrix>
{
    /// <inheritdoc/>
    public override ITreeExpression<Matrix> BuildExpression(string input) => throw new NotImplementedException();

    /// <inheritdoc/>
    public override Matrix Parse(string inputString) => throw new NotImplementedException();
    /// <inheritdoc/>
    public override bool TryParse(string inputString, out Matrix result) => throw new NotImplementedException();

    /// <inheritdoc/>
    public override Task<Matrix> ParseAsync(string inputString, CancellationToken token) => throw new NotImplementedException();
}
