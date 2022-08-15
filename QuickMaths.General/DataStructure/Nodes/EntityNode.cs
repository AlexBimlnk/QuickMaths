using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure.Nodes;

/// <summary xml:lang = "ru">
/// Узел дерева выражений, содержащий сущность.
/// </summary>
/// <typeparam name="TEntity" xml:lang = "ru">
/// Тип сущности, который будет содержать данный узел.
/// </typeparam>
public sealed class EntityNode<TEntity> : IEntityNode<TEntity>
{
    /// <summary xml:lang = "ru">
    /// Создает новый экземпляр типа <see cref="EntityNode{TEntity}"/>.
    /// </summary>
    /// <param name="entity" xml:lang = "ru">
    /// Сущность типа <typeparamref name="TEntity"/>, которую будет хранить в себе узел.
    /// </param>
    /// <exception cref="ArgumentNullException"/>
    public EntityNode(TEntity entity) => Source = entity ?? throw new ArgumentNullException(nameof(entity));

    /// <inheritdoc/>
    public TEntity Source { get; }

    /// <inheritdoc/>
    public int Priority => ArithmeticOperator.None.Priority;

    /// <inheritdoc/>
    public ILookup<IArithmeticOperator, INodeExpression> GetChildEntities() =>
        new List<INodeExpression>(1).Append(new EntityNode<TEntity>(Source)).ToLookup(o => (IArithmeticOperator)ArithmeticOperator.None);
       
    /// <inheritdoc/>
    public INodeExpression MergeNodes(IArithmeticOperator @operator, INodeExpression node)
    {
        if (@operator.Priority == -1)
            throw new ArgumentException($"Given {typeof(ArithmeticOperator)} is None");
        if (node is null)
            throw new ArgumentNullException($"Given node of {typeof(INodeExpression)} is null");

        if (node.Priority == @operator.Priority)
        {
            return node.MergeNodes(@operator, new EntityNode<TEntity>(Source));
        }
        else
        {
            var newOperNode = new OperatorNodePrototype(@operator);

            newOperNode.AddOperand(@operator, node);
            newOperNode.AddOperand(@operator, new EntityNode<TEntity>(Source));
            
            return newOperNode;
        }
    }
    /// <inheritdoc/>
    public override string ToString() =>
        Source.ToString()!;
    
}
