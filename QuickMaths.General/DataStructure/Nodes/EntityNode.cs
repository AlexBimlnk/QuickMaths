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
        new List<INodeExpression>(1).Append(new EntityNode<TEntity>(Source)).ToLookup(o => ArithmeticOperator.None);


    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если какой-либо из параметров метода <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Когда приоритет оператора равен <see cref="ArithmeticOperator.None"/>.
    /// </exception>
    public INodeExpression MergeNodes(IArithmeticOperator @operator, INodeExpression node) =>
        @operator switch
        {
            { Priority: ArithmeticOperator.NONE_OPERATOR_PRIORITY_VALUE } => throw new ArgumentException($"Given {nameof(@operator)} is {nameof(ArithmeticOperator.None)}"),
            null => throw new ArgumentNullException(nameof(node)),
            _ => new OperatorNodePrototype(@operator).AppendOperand(ArithmeticOperator.None, this).AppendOperand(@operator, node)
        };
    /// <inheritdoc/>
    public override string ToString() => Source.ToString()!;

    /// <inheritdoc/>
    public string GetStringView() => Source.ToString()!;
}
