using QuickMaths.General.Abstractions;

namespace QuickMaths.FunctionsBLL.Functions;

/// <summary xml:lang = "ru">
/// Представляет числовую функцию.
/// </summary>
public sealed class NumberFunction : IFunction
{
    /// <summary xml:lang = "ru">
    /// Создает новый объект типа <see cref="NumberFunction"/>.
    /// </summary>
    /// <param name="stringFunction" xml:lang = "ru"> 
    /// Представление функции в виде строки. 
    /// </param>
    /// <exception cref="ArgumentException">
    /// Когда входная строка была пустой или <see langword="null"/>.
    /// </exception>
    /// <exception cref="FormatException">
    /// Если полученную строку невозможно привести к числу.
    /// </exception>
    public NumberFunction(string stringFunction)
    {
        if (string.IsNullOrWhiteSpace(stringFunction))
            throw new ArgumentException("Input string can't be null, empty or whitespace", nameof(stringFunction));

        if (!double.TryParse(stringFunction, out var number))
            throw new FormatException("Input string has invalid format");

        Value = number;
    }

    /// <summary xml:lang = "ru">
    /// Создает новый объект типа <see cref="NumberFunction"/>.
    /// </summary>
    /// <param name="value" xml:lang = "ru">
    /// Число, представляющее функцию.
    /// </param>
    public NumberFunction(double value)
    {
        Value = value;
    }

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