namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Описывает узлы-операторы в дереве выражений.
/// </summary>
public interface IOperatorNode : INodeExpression
{
    /// <summary xml:lang="ru">
    /// Добавление новго узла потомка по связи устанавливаемой оператором. 
    /// И возращение нового состояния объекта.
    /// </summary>
    /// <param name="operator" xml:lang="ru">
    /// Новый узел потомок.
    /// </param>
    /// <param name="operand" xml:lang="ru">
    /// Оператор устанавливающий связь.
    /// </param>
    /// <returns xml:lang="ru">
    /// Новое состояние после добавления узла потомка.
    /// </returns>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если какой-либо из параметров метода <see langword="null"/>.
    /// </exception>
    public IOperatorNode AppendOperand(IArithmeticOperator @operator, INodeExpression operand);
}