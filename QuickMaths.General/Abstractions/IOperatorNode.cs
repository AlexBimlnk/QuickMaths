using QuickMaths.General.Enums;

namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Интерфейс, описывающий узлы-операторы в дереве выражений.
/// </summary>
public interface IOperatorNode : INodeExpression
{
    /// <summary xml:lang = "ru">
    /// Арифметический оператор.
    /// </summary>
    public ArithmeticOperator Operator { get; }
}
