using QuickMaths.General.Enums;

namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Интерфейс, описывающий узлы-операторы в дереве выражений.
/// </summary>
public interface IOperatorNode : INodeExpression
{
    /// <summary>
    /// Добавление новго операнда
    /// </summary>
    /// <param name="operand">Операнд</param>
    /// <param name="operator">Оператор</param>
    /// <exception cref="ArgumentNullException"></exception>
    public void AddOperand(IArithmeticOperator @operator, INodeExpression operand);
}
