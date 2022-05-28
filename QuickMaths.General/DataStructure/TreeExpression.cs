using QuickMaths.General.Enums;
using QuickMaths.General.DataStructure.Nodes;

namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Дерево математических выражений.
/// </summary>
/// <typeparam name="TEntity" xml:lang = "ru">
/// Тип сущности, которым будет наполнено дерево.
/// </typeparam>
public class TreeExpression<TEntity> : ITreeExpression<TEntity>
{
    /// <summary xml:lang = "ru">
    /// Создает объект типа <see cref="TreeExpression{TEntity}"/>.
    /// </summary>
    /// <param name="entity" xml:lang = "ru">
    /// Сущность, хранящаяся в дереве.
    /// </param>
    public TreeExpression(TEntity entity) => Root = new EntityNode<TEntity>(entity);

    /// <summary xml:lang = "ru">
    /// Корень дерева.
    /// </summary>
    public INodeExpression Root { get; private set; }

    /// <summary xml:lang = "ru">
    /// Добавляет новую сущность типа <typeparamref name="TEntity"/> в дерево с помощью оператора связи.
    /// </summary>
    /// <param name="operator" xml:lang = "ru">
    /// Математический оператор, опряделяющий связь.
    /// </param>
    /// <param name="entity" xml:lang = "ru">
    /// Сущность, которую нужно добавить в дерево.
    /// </param>
    public virtual void Add(ArithmeticOperator @operator, TEntity entity) => 
        Root = new OperatorNodePrototype(@operator, Root, new EntityNode<TEntity>(entity));

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
    public virtual void Add(ArithmeticOperator @operator, ITreeExpression<TEntity> entity) =>
        Root = new OperatorNodePrototype(@operator, Root, entity?.Root ?? throw new ArgumentNullException(nameof(entity)));
}
