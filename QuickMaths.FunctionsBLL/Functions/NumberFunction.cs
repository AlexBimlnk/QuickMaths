using QuickMaths.General.Abstractions;

namespace QuickMaths.FunctionsBLL.Functions;

/// <summary xml:lang = "ru">
/// Представляет числовую функцию.
/// </summary>
public sealed class NumberFunction : IFunction
{
    /// <summary xml:lang = "ru">
    /// Конструктор числовой функции.
    /// </summary>
    /// <param name="stringFunction" xml:lang = "ru"> 
    /// Представление функции в виде строки. 
    /// </param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
    public NumberFunction(string stringFunction)
    {
        if (string.IsNullOrEmpty(stringFunction))
            throw new ArgumentNullException(nameof(stringFunction));

        if (!double.TryParse(stringFunction, out double number))
            throw new FormatException($"Input string has invalid format");

        Value = number;
    }
    /// <summary xml:lang = "ru">
    /// Конструктор числовой функции.
    /// </summary>
    /// <param name="value" xml:lang = "ru">
    /// Число, представляющее функцию.
    /// </param>
    public NumberFunction(double value) => Value = value;


    /// <summary xml:lang = "ru">
    /// Значение числовой функции.
    /// </summary>
    public double Value { get; }


    /// <inheritdoc/>
    public double Calculate() => Value;
    /// <inheritdoc/>
    IFunction IFunction.Derivative() => null!;
    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is IFunction function)
            return Equals(function);
        return false;
    }
    /// <inheritdoc/>
    public bool Equals(IFunction? other) => other is NumberFunction numberFunction && numberFunction.Value == Value;
    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Value, nameof(NumberFunction));
    /// <inheritdoc/>
    public override string ToString() => Value.ToString();
}
