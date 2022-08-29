namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Описывает узлы в дереве выражений.
/// </summary>
public interface INodeExpression
{
    /// <summary xml:lang = "ru">
    /// Возвращает список всех узлов-потомков с соответсующими операторами.
    /// </summary>
    /// <returns xml:lang = "ru">
    /// Список всех узлов-потомков с их операторами.
    /// </returns>
    public ILookup<IArithmeticOperator, INodeExpression> GetChildEntities();

    /// <summary xml:lang = "ru">
    /// Значение определяющее по какой группе операторов строятся связи.
    /// </summary>
    public int Priority { get; }

    /// <summary xml:lang = "ru">
    /// Производит слияние двух узлов по связи задаваемой оператором.
    /// </summary>
    /// <param name="operator" xml:lang = "ru">Оператор, оперделяющий связь между узлами.</param>
    /// <param name="node" xml:lang = "ru">Узел, который будет добавлен к текущему.</param>
    /// <returns xml:lang = "ru"> 
    /// Узел типа <see cref="INodeExpression"/>, являющийся результатом слияния.
    /// </returns>
    public INodeExpression MergeNodes(IArithmeticOperator @operator, INodeExpression node);
}