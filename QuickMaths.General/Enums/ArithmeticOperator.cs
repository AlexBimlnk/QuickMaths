using QuickMaths.General.Abstractions;

namespace QuickMaths.General.Enums;

//ToDo comments
/// <summary>
/// 
/// </summary>
public readonly struct ArithmeticOperator : IArithmeticOperator
{
    private static readonly ArithmeticOperator s_plusOperator;
    private static readonly ArithmeticOperator s_minusOperator;
    private static readonly ArithmeticOperator s_multiplyOperator;
    private static readonly ArithmeticOperator s_divideOperator;
    private static readonly ArithmeticOperator s_powerOperator;
    private static readonly ArithmeticOperator s_emptyOperator;

    /// <summary>
    /// 
    /// </summary>
    public static ArithmeticOperator Plus => s_plusOperator;
    /// <summary>
    /// 
    /// </summary>
    public static ArithmeticOperator Minus => s_minusOperator;
    /// <summary>
    /// 
    /// </summary>
    public static ArithmeticOperator Multiply => s_multiplyOperator;
    /// <summary>
    /// 
    /// </summary>
    public static ArithmeticOperator Divide => s_divideOperator;
    /// <summary>
    /// 
    /// </summary>
    public static ArithmeticOperator Power => s_powerOperator;

    /// <summary>
    /// 
    /// </summary>
    public static ArithmeticOperator Empty => s_emptyOperator;

    static ArithmeticOperator()
    {
        s_plusOperator = new ArithmeticOperator(1, true, true, '+');
        s_minusOperator = new ArithmeticOperator(1, true, true, '-');
        s_multiplyOperator = new ArithmeticOperator(2, true, true, '*');
        s_divideOperator = new ArithmeticOperator(2, true, false, '/');
        s_powerOperator = new ArithmeticOperator(3, true, false, '^');
        s_emptyOperator = new ArithmeticOperator();
    }

    private readonly int _priority = -1;
    private readonly bool _isUnary = false;
    private readonly bool _isBinary = false;
    private readonly char _charView = '\0';
    
    private ArithmeticOperator(int operatorPriority, bool isOperatorIsBinary, bool isOperatorIsUnary, char operatorCharView)
    {
        _priority = operatorPriority;
        _isBinary = isOperatorIsBinary;
        _isUnary = isOperatorIsUnary;
        _charView = operatorCharView;
    }


    /// <inheritdoc />
    public int Priority => _priority;
    /// <inheritdoc />
    public bool IsUnary => _isUnary;
    /// <inheritdoc />
    public bool IsBinary => _isBinary;

    /// <inheritdoc />
    public char CharView => _charView;
}

/*public enum EArithmeticOperator
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
*/