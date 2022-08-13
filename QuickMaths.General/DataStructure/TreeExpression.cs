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
    private INodeExpression _root;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rootEntity"></param>
    public TreeExpression(TEntity rootEntity) => _root = new EntityNode<TEntity>(rootEntity ?? throw new ArgumentNullException());

/// <summary xml:lang = "ru">
/// Добавляет новую сущность типа <typeparamref name="TEntity"/> в дерево с помощью оператора связи.
/// </summary>
/// <param name="operator" xml:lang = "ru">
/// Математический оператор, опряделяющий связь.
/// </param>
/// <param name="entity" xml:lang = "ru">
/// Сущность, которую нужно добавить в дерево.
/// </param>
/// <exception cref="NullReferenceException"></exception>
/// <exception cref="ArgumentNullException"></exception>
public virtual void Add(ArithmeticOperator @operator, TEntity entity)
    {
        if (entity is null)
            throw new ArgumentNullException($"Given entity to add of {typeof(TEntity)} is null");
        if (@operator.Priority == -1)
            throw new ArgumentException($"Given {typeof(ArithmeticOperator)} is None");

        if (_root is IEntityNode<TEntity>)
            _root = _root.MergeNodes(@operator, new EntityNode<TEntity>(entity));
        else
            ((IOperatorNode)_root).AddOperand(@operator, new EntityNode<TEntity>(entity));
    }
    /// <summary>
    /// Установка корневого узла в дереве
    /// </summary>
    /// <param name="rootEntity">сущность</param>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public virtual void SetRoot(TEntity rootEntity) => 
        _root = new EntityNode<TEntity>(
            rootEntity ?? throw new ArgumentNullException($"Given root entity of {typeof(TEntity)} is null"));

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
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public virtual void Add(ArithmeticOperator @operator, TreeExpression<TEntity> entity)
    {
        if (@operator.Priority == -1)
            throw new ArgumentException($"Given {typeof(ArithmeticOperator)} is None");
        if (entity is null)
            throw new ArgumentNullException($"Given {typeof(TreeExpression<TEntity>)} is null");

        _root = _root
            .MergeNodes(
                @operator,
                entity._root);
    }
        
    
    /// <inheritdoc/>
    public override string ToString() => _root.ToString();
}