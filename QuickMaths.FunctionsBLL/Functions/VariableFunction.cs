using QuickMaths.General.Abstractions;

namespace QuickMaths.FunctionsBLL.Functions;

/// <summary xml:lang = "ru">
/// Представляет функцию, являющейся переменной.
/// </summary>
public sealed class VariableFunction : IFunction
{
    /// <summary xml:lang = "ru">
    /// Конструктор функции-переменной.
    /// </summary>
    /// <param name="name" xml:lang = "ru">
    /// Имя переменной.
    /// </param>
    /// <exception cref="ArgumentNullException"></exception>
    public VariableFunction(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name));

        Name = name;
    }
    /// <summary xml:lang = "ru">
    /// Конструктор функции-переменной.
    /// </summary>
    /// <param name="name" xml:lang = "ru">
    /// Имя переменной.
    /// </param>
    /// <param name="value" xml:lang = "ru">
    /// Значение переменной.
    /// </param>
    /// <exception cref="ArgumentNullException"></exception>
    public VariableFunction(string name, double value)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name));

        Name = name;
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
    public bool Equals(IFunction? other) => other is VariableFunction variable && variable.Name == Name && variable.Value == Value;
    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Value, Name, nameof(VariableFunction));
    /// <inheritdoc/>
    public override string ToString() => Name;
}
