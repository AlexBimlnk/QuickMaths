using QuickMaths.General.Enums;

namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Интерфейс, определяющий контракт поведения всех узлов в дереве выражений.
/// </summary>
public interface INodeExpression
{
    /// <summary xml:lang = "ru">
    /// Возвращает список всех узлов-потомков для данного узла
    /// </summary>
    /// <returns>Список всех узлов-потомков с их операторами</returns>
    public IList<Tuple<ArithmeticOperator,INodeExpression>> GetChildEntities();
    /// <summary xml:lang = "ru">
    /// Приоритет узла
    /// </summary>
    public int Priority { get; }

    /// <summary xml:lang = "ru">
    /// Объединяет текущем узел с заданным по оператору
    /// </summary>
    /// <param name="operator">оператор по которому проводится объединение</param>
    /// <param name="node">узел который добавляет к текущему</param>
    /// <returns></returns>
    public INodeExpression MergeNodes(ArithmeticOperator @operator, INodeExpression node);
}
