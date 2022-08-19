using QuickMaths.General.Enums;
using QuickMaths.General.DataStructure.Nodes;

namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Дерево выражений, хранящее в себе устройство произвольного математического выражения.
/// </summary>
/// <typeparam name="TEntity" xml:lang = "ru">
/// Тип сущности, которыми будет наполнено дерево.
/// </typeparam>
public class TreeExpression<TEntity> 
{
    private INodeExpression _root;
    /// <summary xml:lang="ru">
    /// Создает экземпляр дерева и назанчаени переданную сущность и оператор в качестве корня.
    /// </summary>
    /// <param name="rootEntity" xml:lang="ru">Сущность, которая будет храниться в корне дерева.</param>
    /// <param name="rootUnaryOperator" xml:lang="ru">Математический унарный опретор, связанный с корневой сущностью</param>
    public TreeExpression(TEntity rootEntity, IArithmeticOperator? rootUnaryOperator = null) => SetRoot(rootEntity, rootUnaryOperator);

    /// <summary xml:lang="ru">
    /// Назначает в качестве корня дерева новый узел, созданный из сущности и её оператора.
    /// </summary>
    /// <param name="rootEntity" xml:lang="ru">Сущность, которая будет храниться в корне дерева.</param>
    /// <param name="rootUnaryOperator" xml:lang="ru">Математический унарный оператор, связанный с новой корневой сущностью.</param>
    /// <exception cref="ArgumentException" xml:lang="ru">Если передан не унарный оператор.</exception>
    /// <exception cref="ArgumentNullException" xml:lang="ru">Если переданная сущность null.</exception>
    public virtual void SetRoot(TEntity rootEntity, IArithmeticOperator? rootUnaryOperator = null)
    {
        _root = (rootUnaryOperator ?? ArithmeticOperator.None) switch
        {
            { IsUnary: false } => throw new ArgumentException("Not unary operator was given."),
            { Priority: ArithmeticOperator.NONE_OPERATOR_PRIORITY_VALUE } =>
                new EntityNode<TEntity>(rootEntity ?? throw new ArgumentNullException(nameof(rootEntity))),
            _ => new OperatorNodePrototype(rootUnaryOperator)
                .AppendOperand(rootUnaryOperator, new EntityNode<TEntity>(rootEntity ?? throw new ArgumentNullException(nameof(rootEntity))))
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
    /// <exception cref="ArgumentNullException" xml:lang="ru"> Если один из параметров метода null.</exception>
    public virtual void Add(IArithmeticOperator @operator, TreeExpression<TEntity> entity) =>
        _root = @operator switch
        {
            { Priority: ArithmeticOperator.NONE_OPERATOR_PRIORITY_VALUE } =>
                throw new ArgumentException($"Given {nameof(@operator)} is {nameof(ArithmeticOperator.None)}"),
            _ when entity is null => throw new ArgumentNullException(nameof(entity)),
            _ => _root
            .MergeNodes(
                @operator,
                entity._root)
        };
    /// <summary xml:lang="ru">
    /// Добавление единичной сущности к дереву.
    /// </summary>
    /// <param name="operator" xml:lang="ru">Математический оператор, который определяет связь сущности с остальным деревом.</param>
    /// <param name="entity" xml:lang="ru">Сущность, которую добавляют в дерево.</param>
    /// <exception cref="ArgumentException" xml:lang="ru">Если передан не один из стандартых операторов.</exception>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если какой-либо из параметров метода <see langword="null"/>.
    /// </exception>
    public virtual void Add(IArithmeticOperator @operator, TEntity entity) =>
        _root = @operator switch
        {
            { Priority: ArithmeticOperator.NONE_OPERATOR_PRIORITY_VALUE } =>
                throw new ArgumentException($"Given {nameof(@operator)} is {nameof(ArithmeticOperator.None)}"),
            _ => _root
            .MergeNodes(
                @operator,
                new EntityNode<TEntity>(entity ?? throw new ArgumentNullException(nameof(entity))))
        };

    /// <inheritdoc/>
    public override string ToString() => _root.ToString()!;

    /// <summary xml:lang="ru">
    /// Получение строкового представления дерева выражений.
    /// </summary>
    /// <returns xml:lang="ru">Стоковое представление дерева выражений.</returns>
    public string GetStringView() => _root.GetStringView();
}