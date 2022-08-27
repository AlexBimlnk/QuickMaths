using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure.Nodes;

/// <summary xml:lang = "ru">
/// Узел, представляющий математический оператор.
/// </summary>
public sealed class OperatorNodePrototype : IOperatorNode
{
    private readonly List<INodeExpression> _assignedOperands = new();
    private readonly Dictionary<IArithmeticOperator, List<int>> _operandsConnections = new();

    /// <summary xml:lang = "ru">
    /// Создает новый экземпляр типа <see cref="OperatorNodePrototype"/>.
    /// </summary>
    /// <param name="baseOperator" xml:lang = "ru">
    /// Арифметический оператор, оперделяющий группу операторов с использованием которой будут строиться все новый связи между узлами-потомками.
    /// </param>
    /// <exception cref="ArgumentNullException" xml:lang = "ru">
    /// Когда <paramref name="baseOperator"/> равен <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException" xml:lang = "ru">
    /// Когда приоритет базового оператора равен -1.
    /// </exception>
    public OperatorNodePrototype(IArithmeticOperator baseOperator)
    {
        ArgumentNullException.ThrowIfNull(baseOperator, nameof(baseOperator));

        if (baseOperator.Priority == -1)
            throw new ArgumentException($"Given {nameof(baseOperator)} is {nameof(ArithmeticOperator.None)}");

        Priority = baseOperator.Priority;
    }

    /// <inheritdoc/>
    public int Priority { get; private set; }


    private string GetStringView()
    {
        var stringBuilder = new System.Text.StringBuilder(string.Empty);
        var firstOperNode = true;

        foreach (var operands in _operandsConnections)
        {
            foreach (var operand in operands.Value)
            {

                _ = stringBuilder.Append(
                    firstOperNode && operands.Key.IsSkipOnBeginInStringView
                        ? string.Empty 
                        : $" {operands.Key.CharView} ");

                firstOperNode = firstOperNode && false;

                var node = _assignedOperands[operand];

                _ = stringBuilder.Append(
                    node.Priority > 0 && node.Priority < Priority 
                        ? $"({node})" 
                        : $"{node}");
            }
        }

        return stringBuilder.ToString();
    }

    private IArithmeticOperator FoundOperatorForNode(INodeExpression node)
    {
        var curNodeIndex = _assignedOperands.IndexOf(node);

        foreach (var elem in _operandsConnections)
        {
            foreach (var nodeIndex in elem.Value)
            {
                if (nodeIndex == curNodeIndex)
                {
                    return elem.Key;
                }
            }
        }

        return ArithmeticOperator.None;
    }

    public INodeExpression MergeNodes(IArithmeticOperator @operator, INodeExpression node)
    {
        ArgumentNullException.ThrowIfNull(node);

        var operatorNode = @operator switch
        {
            { Priority: ArithmeticOperator.NONE_OPERATOR_PRIORITY_VALUE }
                => throw new ArgumentException($"Given {nameof(@operator)} is {nameof(ArithmeticOperator.None)}"),

            null => throw new ArgumentNullException(nameof(@operator)),

            _ when Priority.Equals(@operator.Priority) => new OperatorNodePrototype(Priority, GetChildEntities()),

            _ => new OperatorNodePrototype(@operator.Priority)
                    .AppendOperand(ArithmeticOperator.GetDefaultOperator(@operator.Priority), this)
        };

        return operatorNode.AppendOperand(@operator, node);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentException"></exception>
    public IOperatorNode AppendOperand(IArithmeticOperator @operator, INodeExpression operand)
    {
        if (@operator.Priority == -1)
            @operator = ArithmeticOperator.GetDefaultOperator(Priority);

        ArgumentNullException.ThrowIfNull(operand, nameof(operand));

        if (@operator.Priority != Priority)
            throw new ArgumentException($"Incorrect {nameof(@operator.Priority)} of given {nameof(@operator)}");
        /*if (!@operator.IsUnary && _assignedOperands.Count == 0)
            throw new ArgumentException($"Given {nameof(@operator)} can't be unary");*/

        if (operand.Priority == Priority)
        {
            foreach (var elem in operand.GetChildEntities())
            {
                foreach (var node in elem)
                {
                    _ = AppendOperand(ArithmeticOperator.MergeOperator(elem.Key, @operator), node);
                }
            }
        }
        else
        {
            // Potential compositing

            _assignedOperands.Add(operand);

            if (!_operandsConnections.ContainsKey(@operator))
                _operandsConnections[@operator] = new List<int>();

            _operandsConnections[@operator].Add(_assignedOperands.Count - 1);
        }

        return this;
    }

    /// <inheritdoc/>
    public ILookup<IArithmeticOperator, INodeExpression> GetChildEntities() => _assignedOperands.ToLookup(o => FoundOperatorForNode(o), o => o);

    /// <inheritdoc/>
    public override string ToString() => GetStringView();
}
