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
        _curentOperatorPriority = baseOperator.GetOperatorMetaData().Priority;
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
        int operatorPriority = @operator.GetOperatorMetaData().Priority;
        
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
        //ToDo exceptions
        if (@operator.GetOperatorMetaData().Priority < Priority)
        {
            throw new ArgumentException("Wrond operator");
        }
        if (@operator.GetOperatorMetaData().Priority == Priority)
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
    public IList<Tuple<ArithmeticOperator, INodeExpression>> GetChildEntities() => new List<Tuple<ArithmeticOperator, INodeExpression>>(_assignedOpersnds);
    
    /// <inheritdoc/>
    public override string ToString()
    {
        var stringBuilder = new System.Text.StringBuilder(" ");
        foreach(var op in _assignedOpersnds)
        {
            stringBuilder.Append($"_{(char)op.Item1}_{op.Item2}_");
        }
        stringBuilder.Append(" ");
        return stringBuilder.ToString();
    }
}
