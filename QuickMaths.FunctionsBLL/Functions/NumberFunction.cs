namespace QuickMaths.FunctionsBLL.Functions;

/// <summary>
/// Представляет числовую функцию.
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
    public NumberFunction(string stringFunction)
    {
        if (string.IsNullOrEmpty(stringFunction))
            throw new ArgumentException(null, nameof(stringFunction));

        if (!double.TryParse(stringFunction, out double number))
            throw new FormatException($"Input string has invalid format");

        Value = number;
    }
    public NumberFunction(double value) => Value = value;


    public double Value { get; }


    public double Calculate() => Value;
    IFunction IFunction.Derivative() => null!;
    public override bool Equals(object? obj)
    {
        if (obj is IFunction function)
            return Equals(function);
        return false;
    }
    public bool Equals(IFunction? other) => other is NumberFunction numberFunction && numberFunction.Value == Value;
    public override int GetHashCode() => HashCode.Combine(Value, nameof(NumberFunction));
    public override string ToString() => Value.ToString();
}
