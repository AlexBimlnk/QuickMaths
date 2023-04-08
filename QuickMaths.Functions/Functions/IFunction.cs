using QuickMaths.General.Abstractions;

namespace QuickMaths.Functions.Functions;

/// <summary>
/// Описывает функцию.
/// </summary>
public interface IFunction : IEquatable<IFunction>, IArithmeticable
{
    /// <summary>
    /// Возвращает результат математической функции. 
    /// </summary>
    /// <returns> 
    /// Результат типа <see cref="double"/>. 
    /// </returns>
    /// <exception cref="InvalidOperationException"></exception>
    public double Calculate();

    /// <summary>
    /// Возвращает производную данной функции.
    /// </summary>
    /// <returns> 
    /// Объект типа <see cref="IFunction"/>, являющийся производной функцией.
    /// </returns>
    public IFunction Derivative();
}
