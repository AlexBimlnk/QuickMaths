namespace QuickMaths.Functions.Functions;

/// <summary>
/// Представляет функцию, являющейся переменной.
/// </summary>
public sealed record class VariableFunction : IFunction
{
    /// <summary>
    /// Создает новый объект типа <see cref="VariableFunction"/>.
    /// </summary>
    /// <param name="name">
    /// Имя переменной.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Если <paramref name="name"/> был пустым или содержал только пробельные символы.
    /// </exception>
    public VariableFunction(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        Name = name;
    }

    /// <summary>
    /// Конструктор функции-переменной.
    /// </summary>
    /// <param name="name">
    /// Имя переменной.
    /// </param>
    /// <param name="value">
    /// Значение переменной.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Если <paramref name="name"/> был пустым или содержал только пробельные символы.
    /// </exception>
    public VariableFunction(string name, double value) : this(name)
    {
        Value = value;
    }

    /// <summary>
    /// Имя функции-переменной.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Значение функции-переменной.
    /// </summary>
    public double? Value { get; set; }

    /// <inheritdoc/>
    public double Calculate() => Value ?? throw new InvalidOperationException("Value is missing.");

    /// <inheritdoc/>
    public IFunction Derivative() => new NumberFunction(1);

    /// <inheritdoc/>
    public bool Equals(IFunction? other) => 
        other is VariableFunction variable &&
        variable.Name == Name &&
        variable.Value == Value;
    
    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Value, Name, nameof(VariableFunction));
}
