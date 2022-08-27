using QuickMaths.General.Abstractions;

namespace QuickMaths.FunctionsBLL.Functions;

/// <summary xml:lang = "ru">
/// Представляет функцию, являющейся переменной.
/// </summary>
public sealed class VariableFunction : IFunction
{
    /// <summary xml:lang = "ru">
    /// Создает новый объект типа <see cref="VariableFunction"/>.
    /// </summary>
    /// <param name="name" xml:lang = "ru">
    /// Имя переменной.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Когда входная строка была пустой или <see langword="null"/>.
    /// </exception>
    public VariableFunction(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Input string can't be null, empty or whitespace", nameof(name));

        Name = name;
    }

    /// <summary xml:lang = "ru">
    /// Создает новый объект типа <see cref="VariableFunction"/>.
    /// </summary>
    /// <param name="name" xml:lang = "ru">
    /// Имя переменной.
    /// </param>
    /// <param name="value" xml:lang = "ru">
    /// Значение переменной.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Когда входная строка была пустой или <see langword="null"/>.
    /// </exception>
    public VariableFunction(string name, double value) : this(name)
    {
        Value = value;
    }

    /// <summary xml:lang = "ru">
    /// Имя функции-переменной.
    /// </summary>
    public string Name { get; }

    /// <summary xml:lang = "ru">
    /// Значение функции-переменной.
    /// </summary>
    public double? Value { get; set; }

    /// <inheritdoc/>
    public double Calculate() => Value ?? throw new InvalidOperationException("Value is missing.");

    /// <inheritdoc/>
    public IFunction Derivative() => new NumberFunction(1);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is IFunction function)
            return Equals(function);
        return false;
    }

    /// <inheritdoc/>
    public bool Equals(IFunction? other) => other switch
    {
        VariableFunction variable => Name == variable.Name && Value == variable.Value,
        LinearFunction linear => linear.Koef is NumberFunction { Value: 1 } && linear.Argument.Equals(this),
        _ => false
    };
    
    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Value, Name, nameof(VariableFunction));
    
    /// <inheritdoc/>
    public override string ToString() => Name;
}