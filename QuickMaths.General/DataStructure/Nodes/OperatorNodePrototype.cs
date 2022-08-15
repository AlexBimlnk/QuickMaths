﻿using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;

using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure.Nodes;

/// <summary xml:lang = "ru">
/// Узел, представляющий математический оператор.
/// </summary>
public sealed class OperatorNodePrototype : IOperatorNode
{
    private readonly List<INodeExpression> _assignedOperands;
    private readonly Dictionary<IArithmeticOperator, List<int>> _operandsConnections;
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
        ArgumentNullException.ThrowIfNull(baseOperator, nameof(baseOperator));
        if (baseOperator.Priority == -1)
            throw new ArgumentException($"Given {nameof(baseOperator)} is {nameof(ArithmeticOperator.None)}");

        _curentOperatorPriority = baseOperator.Priority;

        _assignedOperands = new List<INodeExpression>();
        _operandsConnections = new Dictionary<IArithmeticOperator, List<int>>();
    }

    private OperatorNodePrototype(int curentOperatorPriority, ILookup<IArithmeticOperator, INodeExpression>? assignedOperands = null)
    {
        _curentOperatorPriority = curentOperatorPriority;

        _assignedOperands = new List<INodeExpression>();
        _operandsConnections = new Dictionary<IArithmeticOperator, List<int>>();

        foreach (var elem in assignedOperands ?? Enumerable.Empty<INodeExpression>().ToLookup(x => ArithmeticOperator.None, x => x))
        {
            foreach (var operand in elem)
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
    public INodeExpression MergeNodes(IArithmeticOperator @operator, INodeExpression node) =>
        ((@operator ?? throw new ArgumentNullException($"{nameof(@operator)}")) switch
        {
            { Priority: ArithmeticOperator.NONE_OPERATOR_PRIORITY_VALUE }
                => throw new ArgumentException($"Given {nameof(@operator)} is {nameof(ArithmeticOperator.None)}"),
            _ when Priority.Equals(@operator.Priority) => this,
            _ => new OperatorNodePrototype(@operator.Priority).AppendOperand(@operator, this)
        }).AppendOperand(@operator, node ?? throw new ArgumentNullException(nameof(node)));

    /// <inheritdoc/>
    public void AddOperand(IArithmeticOperator @operator, INodeExpression operand)
    {
        if (@operator.Priority == -1)
            @operator = ArithmeticOperator.GetDefaultOperator(_curentOperatorPriority);

        ArgumentNullException.ThrowIfNull(operand, nameof(operand));

        if (@operator.Priority != Priority)
            throw new ArgumentException($"Incorrect {nameof(@operator.Priority)} of given {nameof(@operator)}");
        if (!@operator.IsUnary && _assignedOperands.Count == 0)
            throw new ArgumentException($"Given {nameof(@operator)} can't be unary");

        if (operand.Priority == Priority)
        {
            foreach (var elem in operand.GetChildEntities())
            {
                foreach (var node in elem)
                {
                    AddOperand(ArithmeticOperator.MergeOperator(elem.Key, @operator), node);
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

            return ArithmeticOperator.None;
        }
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        var stringBuilder = new System.Text.StringBuilder("_");
        foreach (var operands in _operandsConnections)
        {
            foreach (var operand in operands.Value)
            {
                stringBuilder.Append($" {operands.Key.CharView} {_assignedOperands[operand]}");
            }
        }
        stringBuilder.Append("_");
        return stringBuilder.ToString();
    }

    /// <inheritdoc/>
    public IOperatorNode AppendOperand(IArithmeticOperator @operator, INodeExpression operand)
    {
        AddOperand(@operator, operand);
        return this;
    }

    /// <inheritdoc/>
    public string GetStringView()
    {
        var stringBuilder = new System.Text.StringBuilder(string.Empty);
        bool firstOperNode = true;

        foreach (var operands in _operandsConnections)
        {
            foreach (var operand in operands.Value)
            {
                
                stringBuilder.Append((firstOperNode && operands.Key.IsSkipOnBeginInStringView) ? string.Empty : $" {operands.Key.CharView}");
                firstOperNode = firstOperNode && false;

                var node = _assignedOperands[operand];
                
                stringBuilder.Append(string.Format((node.Priority > 0 && node.Priority < Priority ? " ({0})" : " {0}"), node.GetStringView()));
            }
        }

        return stringBuilder.ToString();
    }
}
