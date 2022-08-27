using QuickMaths.General.Abstractions;

namespace QuickMaths.General.DataStructure.Nodes;

internal class ArithmeticNode : INode
{
    private IArithmeticable _arithmeticElement;

    public ArithmeticNode(IArithmeticable arithmeticElement) =>
        _arithmeticElement = arithmeticElement ?? throw new ArgumentNullException(nameof(arithmeticElement));

    public double Calculate() => throw new NotImplementedException();
    public IArithmeticable GetDerivative() => throw new NotImplementedException();
    public int GetPriority() => 3;
    public void SetVariables(Dictionary<string, double> variables) => throw new NotImplementedException();

    public override string? ToString() => _arithmeticElement.ToString();
}
