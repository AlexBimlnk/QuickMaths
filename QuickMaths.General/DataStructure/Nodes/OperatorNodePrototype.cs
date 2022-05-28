using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure.Nodes;

/// <summary xml:lang = "ru">
/// Узел, представляющий математический оператор.
/// </summary>
public sealed class OperatorNodePrototype : INodeExpression
{
    private INodeExpression _firstNode;
    private INodeExpression _secondNode;

    /// <summary xml:lang = "ru">
    /// Создает новый экземпляр типа <see cref="OperatorNodePrototype"/>.
    /// </summary>
    /// <param name="operator" xml:lang = "ru">
    /// Арифметический оператор.
    /// </param>
    /// <param name="firstNode" xml:lang = "ru">
    /// Первый узел, связанный арифметическим оператором.
    /// </param>
    /// <param name="secondNode" xml:lang = "ru">
    /// Второй узел, связанный арифметическим оператором.
    /// </param>
    /// <exception cref="ArgumentNullException"/>
    public OperatorNodePrototype(
        ArithmeticOperator @operator,
        INodeExpression firstNode,
        INodeExpression secondNode)
    {
        _firstNode = firstNode ?? throw new ArgumentNullException(nameof(firstNode));
        _secondNode = secondNode ?? throw new ArgumentNullException(nameof(secondNode));
        Operator = @operator;
    }

    /// <summary xml:lang = "ru">
    /// Арифметический оператор.
    /// </summary>
    public ArithmeticOperator Operator { get; }

    /// <inheritdoc/>
    public Priority Priority => throw new NotImplementedException();
}
