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

    public TreeExpression(TEntity rootEntity, IArithmeticOperator? rootUnaryOperator = null) => SetRoot(rootEntity, rootUnaryOperator);
        
    public virtual void SetRoot(TEntity rootEntity, IArithmeticOperator? rootUnaryOperator = null)
    {
        _root = (rootUnaryOperator ?? ArithmeticOperator.None) switch
        {
            { IsUnary: false } => throw new ArgumentException(),
            { Priority: ArithmeticOperator.NONE_OPERATOR_PRIORITY_VALUE } =>
                new EntityNode<TEntity>(rootEntity ?? throw new ArgumentNullException()),
            _ => new OperatorNodePrototype(rootUnaryOperator)
                .AppendOperand(rootUnaryOperator, new EntityNode<TEntity>(rootEntity ?? throw new ArgumentNullException()))
        };
    }

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
    public override string ToString() => _root.ToString()!;

    public string GetStringView()
    {

    }
}