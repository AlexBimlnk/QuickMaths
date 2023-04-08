namespace QuickMaths.Functions.Functions;

/// <summary>
/// Представляет числовую функцию.
/// </summary>
public readonly record struct NumberFunction : IFunction
{
    /// <summary>
    /// Создает новый объект типа <see cref="NumberFunction"/>.
    /// </summary>
    /// <param name="value">
    /// Число, представляющее функцию.
    /// </param>
    public NumberFunction(double value)
    {
        Value = value;
    }

    /// <summary>
    /// Возвращает числовую функцию с нулевым значением.
    /// </summary>
    public static NumberFunction Zero => new();

    /// <summary>
    /// Значение числовой функции.
    /// </summary>
    public double Value { get; } = 0;

    #region Operators

    public static NumberFunction operator +(NumberFunction other) => other;
    public static NumberFunction operator -(NumberFunction other) => new(-other.Value);
    public static NumberFunction operator +(NumberFunction first, NumberFunction second) => 
        new(first.Value + second.Value);
    public static NumberFunction operator -(NumberFunction first, NumberFunction second) =>
        new(first.Value - second.Value);
    public static NumberFunction operator *(NumberFunction first, NumberFunction second) =>
        new(first.Value * second.Value);
    public static NumberFunction operator /(NumberFunction first, NumberFunction second) =>
        new(first.Value / second.Value);
    
    #endregion

    /// <inheritdoc/>
    public double Calculate() => Value;

    /// <inheritdoc/>
    IFunction IFunction.Derivative() => Zero;

    /// <inheritdoc/>
    public bool Equals(IFunction? other) => 
        other is NumberFunction numberFunction &&
        numberFunction.Value == Value;
    
    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Value, nameof(NumberFunction));
}
