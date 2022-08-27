using QuickMaths.General.Abstractions;
using QuickMaths.General.DataStructure.Nodes;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure;

/// <summary xml:lang = "ru">
/// Дерево выражений, хранящее в себе устройство произвольного математического выражения.
/// </summary>
/// <typeparam name="TEntity" xml:lang = "ru">
/// Тип сущности, которыми будет наполнено дерево.
/// </typeparam>
public class TreeExpression<TEntity> where TEntity : notnull
{
    /// <summary xml:lang="ru">
    /// Создает экземпляр дерева и назанчаени переданную сущность и оператор в качестве корня.
    /// </summary>
    /// <param name="rootEntity" xml:lang="ru">Сущность, которая будет храниться в корне дерева.</param>
    /// <param name="rootUnaryOperator" xml:lang="ru">Математический унарный опретор, связанный с корневой сущностью</param>
    public TreeExpression(TEntity rootEntity, IArithmeticOperator? rootUnaryOperator = null)
    {
        SetRoot(rootEntity, rootUnaryOperator);
    }

    /// <summary xml:lang = "ru">
    /// Корень дерева выражений.
    /// </summary>
    public INodeExpression Root { get; private set; }

    /// <summary xml:lang="ru">
    /// Назначает в качестве корня дерева новый узел, созданный из сущности и её оператора.
    /// </summary>
    /// <param name="rootEntity" xml:lang="ru">
    /// Сущность, которая будет храниться в корне дерева.
    /// </param>
    /// <param name="rootUnaryOperator" xml:lang="ru">
    /// Математический унарный оператор, связанный с новой корневой сущностью.
    /// </param>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если передан не унарный оператор.
    /// </exception>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если переданная сущность равна <see langword="null"/>.
    /// </exception>
    public virtual void SetRoot(TEntity rootEntity, IArithmeticOperator? rootUnaryOperator = null)
    {
        ArgumentNullException.ThrowIfNull(rootEntity);

        rootUnaryOperator ??= ArithmeticOperator.None;

        Root = rootUnaryOperator switch
        {
            { IsUnary: false } => throw new ArgumentException("Not unary operator was given."),

            { Priority: ArithmeticOperator.NONE_OPERATOR_PRIORITY_VALUE } => new EntityNode<TEntity>(rootEntity),

            _ => new OperatorNodePrototype(rootUnaryOperator)
                .AppendOperand(rootUnaryOperator, new EntityNode<TEntity>(rootEntity))
        };
    }

    /// <summary xml:lang = "ru">
    /// Присоединяет к дереву выражения другое - аналогичное дерево.
    /// </summary>
    /// <param name="operator" xml:lang = "ru">
    /// Математический оператор, определяющий связь между деревьями.
    /// </param>
    /// <param name="entity" xml:lang = "ru">
    /// Дерево выражений, которое нужно соединить с деревом.
    /// </param>
    /// <exception cref="ArgumentNullException" xml:lang="ru"> 
    /// Если один из параметров метода равен <see langword="null"/>.
    /// </exception>
    public virtual void Add(IArithmeticOperator @operator, TreeExpression<TEntity> entity) => Root = @operator switch
    {
        { Priority: ArithmeticOperator.NONE_OPERATOR_PRIORITY_VALUE } =>
            throw new ArgumentException($"Given {nameof(@operator)} is {nameof(ArithmeticOperator.None)}"),
        _ when entity is null => throw new ArgumentNullException(nameof(entity)),
        _ => Root.MergeNodes(@operator, entity.Root)
    };

    /// <summary xml:lang="ru">
    /// Добавление единичной сущности к дереву.
    /// </summary>
    /// <param name="operator" xml:lang="ru">
    /// Математический оператор, который определяет связь сущности с остальным деревом.
    /// </param>
    /// <param name="entity" xml:lang="ru">
    /// Сущность, которую добавляют в дерево.
    /// </param>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если передан не один из стандартых операторов.
    /// </exception>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если какой-либо из параметров метода <see langword="null"/>.
    /// </exception>
    public virtual void Add(IArithmeticOperator @operator, TEntity entity) => Root = @operator switch
    {
        { Priority: ArithmeticOperator.NONE_OPERATOR_PRIORITY_VALUE } =>
            throw new ArgumentException($"Given {nameof(@operator)} is {nameof(ArithmeticOperator.None)}"),
        _ => Root.MergeNodes(
                @operator,
                new EntityNode<TEntity>(entity ?? throw new ArgumentNullException(nameof(entity))))
    };

    /// <inheritdoc/>
    public override string ToString() => Root.ToString()!;
}