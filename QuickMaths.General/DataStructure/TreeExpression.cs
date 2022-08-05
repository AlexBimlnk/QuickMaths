using QuickMaths.General.Enums;
using QuickMaths.General.DataStructure.Nodes;

namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Дерево математических выражений.
/// </summary>
/// <typeparam name="TEntity" xml:lang = "ru">
/// Тип сущности, которым будет наполнено дерево.
/// </typeparam>
public class TreeExpression<TEntity> 
{
    private INodeExpression? _root;

    /// <summary xml:lang = "ru">
    /// Добавляет новую сущность типа <typeparamref name="TEntity"/> в дерево с помощью оператора связи.
    /// </summary>
    /// <param name="operator" xml:lang = "ru">
    /// Математический оператор, опряделяющий связь.
    /// </param>
    /// <param name="entity" xml:lang = "ru">
    /// Сущность, которую нужно добавить в дерево.
    /// </param>
    public virtual void Add(ArithmeticOperator @operator, TEntity entity)
    {
        if (_root is null)
            _root = new OperatorNodePrototype(@operator);

        if (_root is IEntityNode<TEntity>)
            _root = _root.MergeNodes(@operator, new EntityNode<TEntity>(entity));
        else
            ((IOperatorNode)_root).AddOperand(@operator, new EntityNode<TEntity>(entity));
    }

    public virtual void SetRoot(TEntity rootEntity) => 
        _root = new EntityNode<TEntity>(rootEntity ?? throw new NullReferenceException("Entity is null"));

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
    public virtual void Add(ArithmeticOperator @operator, TreeExpression<TEntity> entity) => 
        _root = (_root ?? throw new NullReferenceException("Tree"))
            .MergeNodes(
                @operator, 
                entity._root ?? throw new NullReferenceException("Given entity tree is null"));

    public override string ToString() => _root.ToString();
}