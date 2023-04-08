using QuickMaths.General.Enums;

namespace QuickMaths.General.Abstractions;

/// <summary>
/// Интерфейс, описывающий узлы-операторы в дереве выражений.
/// </summary>
public interface IOperatorNode : INodeExpression
{
    /// <summary>
    /// Арифметический оператор.
    /// </summary>
    public ArithmeticOperator Operator { get; }
}
