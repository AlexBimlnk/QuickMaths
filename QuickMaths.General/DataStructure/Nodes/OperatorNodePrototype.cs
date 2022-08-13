using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure.Nodes;

/// <summary xml:lang = "ru">
/// Узел, представляющий математический оператор.
/// </summary>
public sealed class OperatorNodePrototype : IOperatorNode
{
    private IList<Tuple<ArithmeticOperator, INodeExpression>> _assignedOpersnds;
    private readonly int _curentOperatorPriority;
    private Lookup<ArithmeticOperator, INodeExpression> _assignedOp;
    /// <summary xml:lang = "ru">
    /// Создает новый экземпляр типа <see cref="OperatorNodePrototype"/>.
    /// </summary>
    /// <param name="baseOperator" xml:lang = "ru">
    /// Арифметический оператор.
    /// </param>
    /// <exception cref="ArgumentNullException"/>
    /// 
    public OperatorNodePrototype(ArithmeticOperator baseOperator)
    {
        if (baseOperator.Priority == -1)
            throw new ArgumentException($"Given {typeof(ArithmeticOperator)} is None");

        _curentOperatorPriority = baseOperator.Priority;
        _assignedOpersnds = new List<Tuple<ArithmeticOperator, INodeExpression>>();
    }

    private OperatorNodePrototype(int curentOperatorPriority, IList<Tuple<ArithmeticOperator, INodeExpression>>? assignedOpersnds = null)
    {
        _assignedOpersnds = assignedOpersnds ?? new List<Tuple<ArithmeticOperator, INodeExpression>>();
        _curentOperatorPriority = curentOperatorPriority;
    }

    /// <inheritdoc/>
    public int Priority => _curentOperatorPriority;
    
    /// <inheritdoc/>
    public INodeExpression MergeNodes(ArithmeticOperator @operator, INodeExpression node)
    {
        if (@operator.Priority == -1)
            throw new ArgumentException($"Given {typeof(ArithmeticOperator)} is None");
        if (node is null)
            throw new ArgumentNullException($"Given node of {typeof(INodeExpression)} is null");

        int operatorPriority = @operator.Priority;
        
        var newOperNode = (operatorPriority == node.Priority 
            ? new OperatorNodePrototype(node.Priority,node.GetChildEntities()) 
            : new OperatorNodePrototype(operatorPriority));

        if (node.Priority != operatorPriority)
            newOperNode.AddOperand(@operator,new OperatorNodePrototype(node.Priority,node.GetChildEntities()));

        if (Priority == operatorPriority)
        {
            foreach(var elem in _assignedOpersnds)
            {
                newOperNode.AddOperand(elem.Item1, elem.Item2);
                
            }
        }
        else
        {
            newOperNode.AddOperand(@operator, new OperatorNodePrototype(Priority,_assignedOpersnds));
        }

        return newOperNode;
    }

    /// <inheritdoc/>
    public void AddOperand(ArithmeticOperator @operator, INodeExpression operand)
    {
        if (@operator.Priority == -1)
            throw new ArgumentException($"Given {typeof(ArithmeticOperator)} is None");
        if (operand is null)
            throw new ArgumentNullException($"Given operand of {typeof(INodeExpression)} is null");
        if (@operator.Priority < Priority)
            throw new ArgumentException($"Incorrect given {typeof(ArithmeticOperator)} priority");

        if (@operator.Priority == Priority)
        {
            _assignedOpersnds.Add(new Tuple<ArithmeticOperator, INodeExpression>(@operator, operand));
            return;
        }
        var lastNode = _assignedOpersnds.Last().Item2;
        var lastOperator = _assignedOpersnds.Last().Item1;
        _assignedOpersnds.RemoveAt(_assignedOpersnds.Count - 1);

        if (lastNode is IOperatorNode node)
            node.AddOperand(@operator, operand);
        else
            lastNode = lastNode.MergeNodes(@operator, operand);

        _assignedOpersnds.Add(new Tuple<ArithmeticOperator, INodeExpression>(lastOperator, lastNode));
    }

    /// <inheritdoc/>
    public IList<Tuple<ArithmeticOperator, INodeExpression>> GetChildEntities() => _assignedOpersnds;
    
    /// <inheritdoc/>
    public override string ToString()
    {
        var stringBuilder = new System.Text.StringBuilder(" ");
        foreach(var op in _assignedOpersnds)
        {
            stringBuilder.Append($"_{op.Item1.CharView}_{op.Item2}_");
        }
        stringBuilder.Append(" ");
        return stringBuilder.ToString();
    }
}
