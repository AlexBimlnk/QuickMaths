using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure.Nodes;

/// <summary>
/// Узел, представляющий математический оператор.
/// </summary>
public sealed class OperatorNodePrototype : IOperatorNode
{
    private INodeExpression _firstNode;
    private INodeExpression _secondNode;

    /// <summary>
    /// Создает новый экземпляр типа <see cref="OperatorNodePrototype"/>.
    /// </summary>
    /// <param name="operator">
    /// Арифметический оператор.
    /// </param>
    /// <param name="firstNode">
    /// Первый узел, связанный арифметическим оператором.
    /// </param>
    /// <param name="secondNode">
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

    /// <inheritdoc/>
    public Priority Priority => throw new NotImplementedException();

    /// <inheritdoc/>
    public ArithmeticOperator Operator { get; }
}
