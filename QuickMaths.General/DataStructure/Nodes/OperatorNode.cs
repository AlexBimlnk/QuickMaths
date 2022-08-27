namespace QuickMaths.General.DataStructure.Nodes;

internal class OperatorNode
{
    /*private INode _firstNode;
    private INode _secondNode;

    public OperatorNode(ArithmeticOperator @operator, INode firstNode, INode secondNode)
    {
        _firstNode = firstNode ?? throw new ArgumentNullException(nameof(firstNode));
        _secondNode = secondNode ?? throw new ArgumentNullException(nameof(secondNode));
        Operator = @operator;
    }

    //public ArithmeticOperator Operator { get; private set; }
    public double Calculate() => throw new NotImplementedException();
    public IArithmeticable GetDerivative() => throw new NotImplementedException();
    //public int GetPriority() => Operator.GetOperatorMetaData().Priority;
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
    }*/
}
