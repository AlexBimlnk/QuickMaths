namespace QuickMaths.General.Enums;

//ToDo comments
public enum ArithmeticOperator
{
    //None priority using for entity node
    [ArithmeticOperatorMetaData(Priority = 3,IsUnary = false,IsBinary = false)]
    None = 0,
    [ArithmeticOperatorMetaData(Priority = 1, IsUnary = true, IsBinary = true)]
    Plus = '+',
    [ArithmeticOperatorMetaData(Priority = 1, IsUnary = true, IsBinary = true)] 
    Minus = '-',
    [ArithmeticOperatorMetaData(Priority = 2, IsUnary = true, IsBinary = true)] 
    Multiply = '*',
    [ArithmeticOperatorMetaData(Priority = 2, IsUnary = false, IsBinary = true)] 
    Divide = '/',
    [ArithmeticOperatorMetaData(Priority = 2, IsUnary = false, IsBinary = true)] 
    Power = '^'

}

/// <summary>
/// Дополнительные методы для перечесления <see cref="ArithmeticOperator"/>
/// </summary>
public static class ArithmeticOperatorExtensions
{
    /// <summary>
    /// Получение доступа к <see cref="ArithmeticOperatorMetaDataAttribute"/> для кадого значения <see cref="ArithmeticOperator"/>
    /// </summary>
    /// <param name="operator">Арифмитический оператор</param>
    /// <returns>Доступ к полям <see cref="ArithmeticOperatorMetaDataAttribute"/></returns>
    /// <exception cref="NullReferenceException"></exception>
    public static ArithmeticOperatorMetaDataAttribute GetOperatorMetaData(this ArithmeticOperator @operator)
    {
        var type = @operator.GetType();
        var name = Enum.GetName(type, @operator);
        var returnAtributte = type.GetField(name)
            .GetCustomAttributes(false)
            .OfType<ArithmeticOperatorMetaDataAttribute>()
            .SingleOrDefault();
        return returnAtributte ?? throw new NullReferenceException($"{typeof(ArithmeticOperatorMetaDataAttribute)} of {@operator} not found");
    }
}

[System.AttributeUsage(System.AttributeTargets.Field)]
public sealed class ArithmeticOperatorMetaDataAttribute : Attribute
{
    public int Priority { get; set; }
    public bool IsUnary { get; set; }
    public bool IsBinary { get; set; }
    //public bool IsSkippedInBegin { get; set; }
}
