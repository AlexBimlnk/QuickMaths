using System;
using System.Xml.Linq;

using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure.Nodes;

/// <summary xml:lang = "ru">
/// Узел, представляющий математический оператор.
/// </summary>
public sealed class OperatorNodePrototype : IOperatorNode
{
    private List<INodeExpression> _assignedOperands;
    private Dictionary<IArithmeticOperator, List<int>> _operandsConnections;
    
    private readonly int _curentOperatorPriority;

    /// <summary xml:lang = "ru">
    /// Создает новый экземпляр типа <see cref="OperatorNodePrototype"/>.
    /// </summary>
    /// <param name="baseOperator" xml:lang = "ru">
    /// Арифметический оператор.
    /// </param>
    /// <exception cref="ArgumentNullException"/>
    public OperatorNodePrototype(IArithmeticOperator baseOperator)
    {
        if (baseOperator.Priority == -1)
            throw new ArgumentException($"Given {typeof(ArithmeticOperator)} is None");

        _curentOperatorPriority = baseOperator.Priority;

        _assignedOperands = new List<INodeExpression>();
        _operandsConnections = new Dictionary<IArithmeticOperator, List<int>>();
    }

    private OperatorNodePrototype(int curentOperatorPriority, ILookup<IArithmeticOperator, INodeExpression> assignedOperands = null)
    {
        _curentOperatorPriority = curentOperatorPriority;

        _assignedOperands = new List<INodeExpression>();
        _operandsConnections = new Dictionary<IArithmeticOperator, List<int>>();

        foreach (var elem in assignedOperands ?? Enumerable.Empty<INodeExpression>().ToLookup(x => (IArithmeticOperator)ArithmeticOperator.Empty,x => x))
        {
            foreach(var operand in elem)
            {
                _assignedOperands.Add(operand);

                if (!_operandsConnections.ContainsKey(elem.Key))
                {
                    _operandsConnections[elem.Key] = new List<int>();
                }

                _operandsConnections[elem.Key].Add(_assignedOperands.Count - 1);
            }
        }
    }

    /// <inheritdoc/>
    public int Priority => _curentOperatorPriority;
    
    /// <inheritdoc/>
    public INodeExpression MergeNodes(IArithmeticOperator @operator, INodeExpression node)
    {
        if (@operator.Priority == -1)
            throw new ArgumentException($"Given {typeof(ArithmeticOperator)} is None");
        if (node is null)
            throw new ArgumentNullException($"Given node of {typeof(INodeExpression)} is null");

        var newOperNode = new OperatorNodePrototype(@operator.Priority, @operator.Priority == node.Priority ? node.GetChildEntities() : null);

        if (node.Priority != @operator.Priority)
            newOperNode.AddOperand(@operator,new OperatorNodePrototype(node.Priority,node.GetChildEntities()));

        if (Priority == @operator.Priority)
        {
            foreach(var elem in _operandsConnections)
            {
                foreach (var operandId in elem.Value)
                {
                    newOperNode.AddOperand(elem.Key, _assignedOperands[operandId]);
                }
            }
        }
        else
        {
            newOperNode.AddOperand(@operator, this);
        }

        return newOperNode;
    }

    /// <inheritdoc/>
    public void AddOperand(IArithmeticOperator @operator, INodeExpression operand)
    {
        if (@operator.Priority == -1)
            throw new ArgumentException($"Given {typeof(ArithmeticOperator)} is None");
        if (operand is null)
            throw new ArgumentNullException($"Given operand of {typeof(INodeExpression)} is null");
        if (@operator.Priority < Priority)
            throw new ArgumentException($"Incorrect given {typeof(ArithmeticOperator)} priority");

        if (@operator.Priority == Priority)
        {
            _assignedOperands.Add(operand);

            if (!_operandsConnections.ContainsKey(@operator))
            {
                _operandsConnections[@operator] = new List<int>();
            }
            _operandsConnections[@operator].Add(_assignedOperands.Count);

            return;
        }

        var lastNode = _assignedOperands.Last();

        if (lastNode is IOperatorNode node)
            node.AddOperand(@operator, operand);
        else
            lastNode = lastNode.MergeNodes(@operator, operand);

        _assignedOperands[_assignedOperands.Count - 1] = lastNode;
    }

    /// <inheritdoc/>
    public ILookup<IArithmeticOperator, INodeExpression> GetChildEntities()
    {
        return _assignedOperands.ToLookup(o => foundOperator(o), o => o);

        IArithmeticOperator foundOperator(INodeExpression node)
        {
            int curNodeIndex = _assignedOperands.IndexOf(node);

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

            return ArithmeticOperator.Empty;
        }
    }
    
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
