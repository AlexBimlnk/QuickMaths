using QuickMaths.General.Abstractions;

namespace QuickMaths.FunctionsBLL.Functions;

/// <summary xml:lang = "ru">
/// Представляет линейную функцию.
/// </summary>
public class LinearFunction : IFunction
{
    /// <summary xml:lang = "ru">
    /// Создает новый объект типа <see cref="LinearFunction"/>.
    /// </summary>
    /// <param name="argument" xml:lang = "ru">
    /// Аргумент в линейной функции.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Когда любой из параметров равен <see langword="null"/>.
    /// </exception>
    public LinearFunction(IFunction argument)
    {
        Argument = argument ?? throw new ArgumentNullException(nameof(argument));
    }

    /// <summary xml:lang = "ru">
    /// Создает новый объект типа <see cref="LinearFunction"/>.
    /// </summary>
    /// <param name="argument" xml:lang = "ru">
    /// Аргумент в линейной функции.
    /// </param>
    /// <param name="koef" xml:lang = "ru">
    /// Коэффициент в линейной функции.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Когда любой из параметров равен <see langword="null"/>.
    /// </exception>
    public LinearFunction(IFunction argument, IFunction koef) : this(argument)
    {
        Koef = koef ?? throw new ArgumentNullException(nameof(koef));
    }

    /// <summary xml:lang = "ru">
    /// Коэффициент линейной функции.
    /// </summary>
    public IFunction Koef { get; } = new NumberFunction(1);

    /// <summary xml:lang = "ru">
    /// Аргумент линейной функции.
    /// </summary>
    public IFunction Argument { get; }

    /// <inheritdoc/>
    public double Calculate() => throw new NotImplementedException();

    /// <inheritdoc/>
    public IFunction Derivative() => throw new NotImplementedException();

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
        LinearFunction linear => Argument.Equals(linear.Argument) && Koef.Equals(linear.Koef),
        NumberFunction number => Argument.Equals(Koef) && Argument.Equals(number),
        VariableFunction variable => Argument.Equals(variable) && Koef is NumberFunction { Value: 1 },
        _ => false
    };

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Koef, Argument, nameof(LinearFunction));

    /// <inheritdoc/>
    public override string ToString() => $"{Koef}*{Argument}";
}