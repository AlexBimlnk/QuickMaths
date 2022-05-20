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
        _firsNode = firstNode ?? throw new ArgumentNullException(nameof(firstNode));
        _secondNode = secondNode ?? throw new ArgumentNullException(nameof(secondNode));
        Operator = @operator;
    }

    public MathOperator Operator { get; }

    private static int GetOperatorPriority(MathOperator @operator) => (@operator) switch
    {
        //Todo: Priority -> create enum.
        MathOperator.Plus => 1,
        MathOperator.Minus => 1,
        MathOperator.Multiply => 2,
        MathOperator.Divide => 2,
        MathOperator.Power => throw new NotImplementedException(),
        _ => throw new NotImplementedException()
    };

    public double Calculate() => throw new NotImplementedException();
    public IArithmeticable GetDerivative() => throw new NotImplementedException();
    public int GetPriority() => GetOperatorPriority(Operator);
    public void SetVariables(Dictionary<string, double> variables) => throw new NotImplementedException();
    public override string ToString()
    {
        var firstNodeAsString = _firsNode.GetPriority() < GetPriority()
                                ? $"({_firsNode}) "
                                : $"{_firsNode}";

        var secondNodeAsString = _secondNode.GetPriority() < GetPriority()
                                 ? $" ({_secondNode})"
                                 : $"{_secondNode}";

        return firstNodeAsString + Operator + secondNodeAsString;
    }
}
