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
    private static readonly int s_allEntityNodesPriority = ArithmeticOperator.None.GetOperatorMetaData().Priority;

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
    public int Priority => s_allEntityNodesPriority;

    /// <inheritdoc/>
    public IList<Tuple<ArithmeticOperator, INodeExpression>> GetChildEntities()
    {
        var entityList = new List<Tuple<ArithmeticOperator, INodeExpression>>(1);
        entityList.Add(new Tuple<ArithmeticOperator, INodeExpression>(ArithmeticOperator.None, new EntityNode<TEntity>(Source)));
        return entityList;
    }
       
    /// <inheritdoc/>
    public INodeExpression MergeNodes(ArithmeticOperator @operator, INodeExpression node)
    {
        if (@operator == ArithmeticOperator.None)
            throw new ArgumentException($"Given {typeof(ArithmeticOperator)} is None");
        if (node is null)
            throw new ArgumentNullException($"Given node of {typeof(INodeExpression)} is null");

        if (node.Priority == @operator.GetOperatorMetaData().Priority)
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
