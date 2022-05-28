using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure.Nodes;
public sealed class OperatorNodePrototype : INodeExpression
{
    private INodeExpression _firstNode;
    private INodeExpression _secondNode;

    public OperatorNodePrototype(
        MathOperator @operator, 
        INodeExpression firstNode, 
        INodeExpression secondNode)
    {
        _firstNode = firstNode ?? throw new ArgumentNullException(nameof(firstNode));
        _secondNode = secondNode ?? throw new ArgumentNullException(nameof(secondNode));
        Operator = @operator;
    }

    public MathOperator Operator { get; }
    public Priority Priority => throw new NotImplementedException();
}
