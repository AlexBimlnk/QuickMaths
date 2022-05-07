namespace QuickMaths.FunctionsBLL.Functions;

/// <summary>
/// Степенная функция.
/// <list type="bullet">
///     <item>
///         <term>x^2</term>
///         <description>Является степенной функцией.</description>
///     </item>
///     <item>
///         <term>y^4</term>
///         <description>Является степенной функцией.</description>
///     </item>
/// </list>
/// </summary>
public class PowerFunction : IFunction
{
    public double Calculate() => throw new NotImplementedException();

    public IFunction Derivative() => throw new NotImplementedException();

    public override bool Equals(object? obj)
    {
        if (obj is IFunction function)
            return Equals(function);
        return false;
    }
    public bool Equals(IFunction? other) => throw new NotImplementedException();
    public override int GetHashCode() => throw new NotImplementedException();
    public override string ToString() => throw new NotImplementedException();
}
