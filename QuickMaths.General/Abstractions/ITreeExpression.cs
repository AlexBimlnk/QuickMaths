namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Интерфейс, описывающий контракт любых деревьев выражений.
/// </summary>
/// <typeparam name="TEntity" xml:lang = "ru">
/// Сущность из которых будет состоять дерево выражений.
/// </typeparam>
public interface ITreeExpression<TEntity>
{

    /*/// <summary xml:lang = "ru">
    /// Добавляет новую сущность типа <typeparamref name="TEntity"/> в дерево с помощью оператора связи.
    /// </summary>
    /// <param name="operator" xml:lang = "ru">
    /// Математический оператор, опряделяющий связь.
    /// </param>
    /// <param name="entity" xml:lang = "ru">
    /// Сущность, которую нужно добавить в дерево.
    /// </param>
    public void Add(ArithmeticOperator @operator, TEntity entity);

    /// <summary xml:lang = "ru">
    /// Добавляет дерево выражений, наполненное сущностями типа <typeparamref name="TEntity"/>
    /// в существующее дерево с помощью оператора связи.
    /// </summary>
    /// <param name="operator" xml:lang = "ru">
    /// Математический оператор, определяющий связь.
    /// </param>
    /// <param name="entity" xml:lang = "ru">
    /// Дерево выражений, которое нужно соединить с деревом.
    /// </param>
    public void Add(ArithmeticOperator @operator, ITreeExpression<TEntity> entity);

    public void SetRoot(TEntity rootEntity);

    public INodeExpression Root { get; }*/
}
