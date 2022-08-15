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
    public virtual void Add(IArithmeticOperator @operator, TreeExpression<TEntity> entity) =>
        _root = @operator switch
        {
            { Priority: ArithmeticOperator.NONE_OPERATOR_PRIORITY_VALUE } =>
                throw new ArgumentException($"Given {typeof(ArithmeticOperator)} is None"),
            _ when entity is null => throw new ArgumentNullException(nameof(entity)),
            _ => _root
            .MergeNodes(
                @operator,
                entity._root)
        };

    public virtual void Add(IArithmeticOperator @operator, TEntity? entity) =>
        _root = @operator switch
        {
            { Priority: ArithmeticOperator.NONE_OPERATOR_PRIORITY_VALUE } =>
                throw new ArgumentException($"Given {typeof(ArithmeticOperator)} is None"),
            _ => _root
            .MergeNodes(
                @operator,
                new EntityNode<TEntity>(entity ?? throw new ArgumentNullException($"Given {typeof(TreeExpression<TEntity>)} is null")))
        };

    /// <inheritdoc/>
    public override string ToString() => _root.ToString()!;

    public string GetStringView()
    {

    }
}