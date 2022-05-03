namespace QuickMaths.FunctionsBLL.Functions;

/// <summary>
/// Числовая функция.
/// <list type="bullet">
///     <item>
///         <term>4</term>
///         <description>Является числовой функцией.</description>
///     </item>
///     <item>
///         <term>242</term>
///         <description>Является числовой функцией.</description>
///     </item>
/// </list>
/// </summary>
public class NumberFunction : IFunction
{
    private string _stringFunction = string.Empty;


    public NumberFunction(string stringFunction)
    {
        if (string.IsNullOrEmpty(stringFunction))
            throw new ArgumentException(null, nameof(stringFunction));

        _stringFunction = stringFunction;
        Value = Convert.ToDouble(stringFunction);
    }
    public NumberFunction(double value) => Value = value;


    public double Value { get; }


    public double Calculate() => Value;
    IFunction IFunction.Derivative() => throw new NotImplementedException();
    public override bool Equals(object? obj)
    {
        if (obj is IFunction function)
            return Equals(function);
        return false;
    }
    public bool Equals(IFunction? other) => other is NumberFunction numberFunction && numberFunction.Value == Value;
    public override int GetHashCode() => HashCode.Combine(Value);
    public override string ToString() => Value.ToString();
}
