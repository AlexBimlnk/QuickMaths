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
    private INode _firstNode;
    private INode _secondNode;

    public OperatorNode(ArithmeticOperator @operator, INode firstNode, INode secondNode)
    {
        _firstNode = firstNode ?? throw new ArgumentNullException(nameof(firstNode));
        _secondNode = secondNode ?? throw new ArgumentNullException(nameof(secondNode));
        Operator = @operator;
    }

    public ArithmeticOperator Operator { get; private set; }

    private static int GetOperatorPriority(ArithmeticOperator @operator) => (@operator) switch
    {
        //Todo: Priority -> create enum.
        ArithmeticOperator.Plus => 1,
        ArithmeticOperator.Minus => 1,
        ArithmeticOperator.Multiply => 2,
        ArithmeticOperator.Divide => 2,
        ArithmeticOperator.Power => throw new NotImplementedException(),
        _ => throw new NotSupportedException(nameof(@operator))
    };

    public double Calculate() => throw new NotImplementedException();
    public IArithmeticable GetDerivative() => throw new NotImplementedException();
    public int GetPriority() => GetOperatorPriority(Operator);
    public void SetVariables(Dictionary<string, double> variables) => throw new NotImplementedException();
    public override string ToString()
    {
        var firstNodeAsString = _firstNode.GetPriority() < GetPriority()
                                ? $"({_firstNode}) "
                                : $"{_firstNode}";

        var secondNodeAsString = _secondNode.GetPriority() < GetPriority()
                                 ? $" ({_secondNode})"
                                 : $"{_secondNode}";

        return firstNodeAsString + (char)Operator + secondNodeAsString;
    }
}
