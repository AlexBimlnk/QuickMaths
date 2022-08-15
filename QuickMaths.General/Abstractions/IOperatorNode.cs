using QuickMaths.General.Enums;

namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Интерфейс, описывающий узлы-операторы в дереве выражений.
/// </summary>
public interface IOperatorNode : INodeExpression
{
    /// <summary>
    /// Добавление новго узла потомка по связи устанавливаемой операторм.
    /// </summary>
    /// <param name="operand">Новый узел потомок.</param>
    /// <param name="operator">Оператор устанавливающий связь.</param>
    /// <exception cref="ArgumentNullException">Если какой-либо из параметров метода null.</exception>
    public void AddOperand(IArithmeticOperator @operator, INodeExpression operand);


    /// <summary>
    /// Добавление новго узла потомка по связи устанавливаемой операторм. И возращение нового состояния объекта.
    /// </summary>
    /// <param name="operator">Новый узел потомок.</param>
    /// <param name="operand">Оператор устанавливающий связь.</param>
    /// <returns>Новое состоряние после добавления узла потомка.</returns>
    public IOperatorNode AppendOperand(IArithmeticOperator @operator, INodeExpression operand);

}
