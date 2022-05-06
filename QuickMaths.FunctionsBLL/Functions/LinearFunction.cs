using System.Text;

namespace QuickMaths.FunctionsBLL.Functions;

/// <summary xml:lang = "ru">
/// Представляет линейную функцию.
/// </summary>
public class LinearFunction : IFunction
{
    /// <summary xml:lang = "ru">
    /// Конструктор линейной функции.
    /// </summary>
    /// <param name="argument" xml:lang = "ru">
    /// Аргумент в линейной функции.
    /// </param>
    /// <exception cref="ArgumentNullException"></exception>
    public LinearFunction(IFunction argument) => Argument = argument ?? throw new ArgumentNullException(nameof(argument));
    /// <summary xml:lang = "ru">
    /// Конструктор линейной функции.
    /// </summary>
    /// <param name="argument" xml:lang = "ru">
    /// Аргумент в линейной функции.
    /// </param>
    /// <param name="koef" xml:lang = "ru">
    /// Коэффициент в линейной функции.
    /// </param>
    /// <exception cref="ArgumentNullException"></exception>
    public LinearFunction(IFunction argument, IFunction koef)
    {
        Argument = argument ?? throw new ArgumentNullException(nameof(argument));
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
    public bool Equals(IFunction? other) => other is LinearFunction linearFunction && 
        Koef.Equals(linearFunction.Koef) && Argument.Equals(linearFunction.Argument);
    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Koef, Argument, nameof(LinearFunction));
    /// <inheritdoc/>
    public override string ToString() => $"{Koef}*{Argument}";
}
