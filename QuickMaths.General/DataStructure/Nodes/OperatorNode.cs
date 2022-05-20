using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure.Nodes;

internal class OperatorNode : INode
{
    private INode _firsNode;
    private INode _secondNode;

    public OperatorNode(MathOperator @operator, INode firstNode, INode secondNode)
    {
        if (firstNode is null || secondNode is null)
        {
            throw new ArgumentNullException("Node is null");
        }

        Operator = @operator;
        _firsNode = firstNode;
        _secondNode = secondNode;
    }

    public MathOperator Operator { get; private set; }

    private static int GetOperatorPriority(MathOperator @operator)
    {
        switch (@operator)
        {
            case MathOperator.Plus: return 1;
            case MathOperator.Minus: return 1;
            case MathOperator.Multiply: return 2;
            case MathOperator.Divide: return 2;
        }

        throw new ArgumentException("Unchecked MathOperator Enum condition");
    }

    public double Calculate() => throw new NotImplementedException();
    public IArithmeticable GetDerivative() => throw new NotImplementedException();
    public int GetPriority() => GetOperatorPriority(Operator);
    public void SetVariables(Dictionary<string, double> variables) => throw new NotImplementedException();
    public override string ToString()
    {
        string firstNodeString = _firsNode.ToString();

        if (_firsNode.GetPriority() < GetPriority())
        {
            firstNodeString = $"({firstNodeString}) ";
        }

        string secondNodeString = _secondNode.ToString();

        if (_firsNode.GetPriority() < GetPriority())
        {
            secondNodeString = $" ({secondNodeString})";
        }

        return firstNodeString + Operator + secondNodeString;
    }
}
