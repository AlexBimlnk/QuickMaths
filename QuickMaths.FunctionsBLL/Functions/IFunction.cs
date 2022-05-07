namespace QuickMaths.FunctionsBLL.Functions;

/// <summary xml:lang = "ru">
/// Интерфейс функции.
/// </summary>
public interface IFunction : IEquatable<IFunction>
{
    /// <summary xml:lang = "ru">
    /// Возвращает результат математической функции. 
    /// </summary>
    /// <returns xml:lang = "ru"> 
    /// Результат типа <see cref="double"/>. 
    /// </returns>
    /// <exception cref="InvalidOperationException"></exception>
    public double Calculate();
    /// <summary xml:lang = "ru">
    /// Возвращает производную данной функции.
    /// </summary>
    /// <returns xml:lang = "ru"> 
    /// Объект типа <see cref="IFunction"/>, являющийся производной функцией.
    /// </returns>
    public IFunction Derivative();
}
