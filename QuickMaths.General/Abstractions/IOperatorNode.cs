namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Интерфейс, описывающий узлы-операторы в дереве выражений.
/// </summary>
public interface IOperatorNode : INodeExpression
{
    /// <summary xml:lang = "ru">
    /// Добавление новго узла потомка по связи устанавливаемой операторм.
    /// </summary>
    /// <param name="operand" xml:lang = "ru">Новый узел потомок.</param>
    /// <param name="operator" xml:lang = "ru">Оператор устанавливающий связь.</param>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если какой-либо из параметров метода <see langword="null"/>.
    /// </exception>
    public void AddOperand(IArithmeticOperator @operator, INodeExpression operand);


    /// <summary xml:lang="ru">
    /// Добавление новго узла потомка по связи устанавливаемой операторм. И возращение нового состояния объекта.
    /// </summary>
    /// <param name="operator" xml:lang="ru">Новый узел потомок.</param>
    /// <param name="operand" xml:lang="ru">Оператор устанавливающий связь.</param>
    /// <returns xml:lang="ru">Новое состоряние после добавления узла потомка.</returns>
    public IOperatorNode AppendOperand(IArithmeticOperator @operator, INodeExpression operand);

}
