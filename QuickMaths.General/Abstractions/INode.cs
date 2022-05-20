namespace QuickMaths.General.Abstractions;

internal interface INode
{
    public double Calculate();

    public IArithmeticable GetDerivative();

    public void SetVariables(Dictionary<string, double> variables);

    public int GetPriority();
}
