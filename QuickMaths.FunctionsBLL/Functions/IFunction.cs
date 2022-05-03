namespace QuickMaths.FunctionsBLL.Functions;

public interface IFunction : IEquatable<IFunction>
{

    /// <summary>
    /// Возвращает результат математической функции. 
    /// </summary>
    /// <returns> Результат типа <see cref="double"/>. </returns>
    public double Calculate();
    /// <summary>
    /// Возвращает производную данной функции.
    /// </summary>
    /// <returns> Функция, являющаяся производной от той, в котором был вызван этот метод. </returns>
    public IFunction Derivative();
}
