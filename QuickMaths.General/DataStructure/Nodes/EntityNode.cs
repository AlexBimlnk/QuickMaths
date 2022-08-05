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
    public int Priority => ArithmeticOperator.None.GetOperatorMetaData().Priority;

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
        INodeExpression nodeExpr;

        if (node.Priority == @operator.GetOperatorMetaData().Priority)
        {
            nodeExpr = node.MergeNodes(@operator, new EntityNode<TEntity>(Source));
        }
        else
        {
            var nodeExpr1 = new OperatorNodePrototype(@operator);

            nodeExpr1.AddOperand(@operator, node);
            nodeExpr1.AddOperand(@operator, new EntityNode<TEntity>(Source));
            
            return nodeExpr1;
        }

        return nodeExpr;
    }
    /// <inheritdoc/>
    public override string ToString()
    {
        if (Source is not null)
            return Source.ToString();
        return "###null####";
    }
}
