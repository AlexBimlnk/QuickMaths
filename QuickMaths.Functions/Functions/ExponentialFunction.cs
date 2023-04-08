namespace QuickMaths.Functions.Functions;

/// <summary>
/// Показательная функция.
/// <list type="bullet">
///     <item>
///         <term>e^x</term>
///         <description>Является показательной функцией.</description>
///     </item>
///     <item>
///         <term>2^y</term>
///         <description>Является показательной функцией.</description>
///     </item>
/// </list>
/// </summary>
public class ExponentialFunction : IFunction
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
