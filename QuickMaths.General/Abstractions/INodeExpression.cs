using QuickMaths.General.Enums;

namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Интерфейс, определяющий контракт поведения всех узлов в дереве выражений.
/// </summary>
public interface INodeExpression
{
    /// <summary xml:lang = "ru">
    /// Возвращает список всех узлов-потомков с соответсующими операторами.
    /// </summary>
    /// <returns>Список всех узлов-потомков с их операторами</returns>
    public ILookup<IArithmeticOperator,INodeExpression> GetChildEntities();
    /// <summary xml:lang = "ru">
    /// Значение определяющее по какой группе операторов строятсят связи.
    /// </summary>
    public int Priority { get; }

    /// <summary xml:lang = "ru">
    /// Производит слияние двух узлов по связи задаваемой оператором.
    /// </summary>
    /// <param name="operator">Оператор, оперделяющий связь между узлами.</param>
    /// <param name="node">Узел, который будет добавлен к текущему.</param>
    /// <returns></returns>
    public INodeExpression MergeNodes(IArithmeticOperator @operator, INodeExpression node);

    /// <summary>
    /// Получение строкового представления узла и всех хранящихся внутри него узлов потомков.
    /// </summary>
    /// <returns>Строковое представление.</returns>
    public string GetStringView();
}
