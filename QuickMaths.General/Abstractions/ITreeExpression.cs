using QuickMaths.General.Enums;

namespace QuickMaths.General.Abstractions;

/// <summary>
/// Интерфейс, описывающий контракт любых деревьев выражений.
/// </summary>
/// <typeparam name="TEntity">
/// Сущность из которых будет состоять дерево выражений.
/// </typeparam>
public interface ITreeExpression<TEntity> 
{
    /// <summary>
    /// Корень дерева.
    /// </summary>
    public INodeExpression Root { get; }

    /// <summary>
    /// Добавляет новую сущность типа <typeparamref name="TEntity"/> в дерево с помощью оператора связи.
    /// </summary>
    /// <param name="operator">
    /// Математический оператор, опряделяющий связь.
    /// </param>
    /// <param name="entity">
    /// Сущность, которую нужно добавить в дерево.
    /// </param>
    public void Add(ArithmeticOperator @operator, TEntity entity);

    /// <summary>
    /// Добавляет дерево выражений, наполненное сущностями типа <typeparamref name="TEntity"/>
    /// в существующее дерево с помощью оператора связи.
    /// </summary>
    /// <param name="operator">
    /// Математический оператор, определяющий связь.
    /// </param>
    /// <param name="entity">
    /// Дерево выражений, которое нужно соединить с деревом.
    /// </param>
    public void Add(ArithmeticOperator @operator, ITreeExpression<TEntity> entity);
}
