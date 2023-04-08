namespace QuickMaths.Functions.Functions;

/// <summary>
/// Логарифмическая функция.
/// <list type="bullet">
///     <item>
///         <term>loge(3)</term>
///         <description>Является логарифмической функцией.</description>
///     </item>
///     <item>
///         <term>log2(x)</term>
///         <description>Является логарифмической функцией.</description>
///     </item>
/// </list>
/// </summary>
public class LogarithmicFunction : IFunction
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
