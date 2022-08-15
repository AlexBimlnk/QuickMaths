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
    private static readonly ArithmeticOperator s_noneOperator;

    private const int PLUS_MINUS_OPERATORS_PRIORITY_VALUE = 1;
    private const int MULTIPLY_DIVIDE_OPERATOR_PRIORITY_VALUE = 2;
    private const int POWER_OPERATOR_PRIORITY_VALUE = 3;

    /// <summary>
    /// 
    /// </summary>
    public const int NONE_OPERATOR_PRIORITY_VALUE = -1;

    private const char PLUS_OPERATOR_CHAR_VIEW = '+';
    private const char MINUS_OPERATOR_CHAR_VIEW = '-';
    private const char MULTIPLY_OPERATOR_CHAR_VIEW = '*';
    private const char DIVIDE_OPERATOR_CHAR_VIEW = '/';
    private const char POWER_OPERATOR_CHAR_VIEW = '^';
    private const char NONE_OPERATOR_CHAR_VIEW = '\0';

    static ArithmeticOperator()
    {
        s_plusOperator = new ArithmeticOperator(PLUS_MINUS_OPERATORS_PRIORITY_VALUE, true, true, PLUS_OPERATOR_CHAR_VIEW);
        s_minusOperator = new ArithmeticOperator(PLUS_MINUS_OPERATORS_PRIORITY_VALUE, true, true, MINUS_OPERATOR_CHAR_VIEW);
        s_multiplyOperator = new ArithmeticOperator(MULTIPLY_DIVIDE_OPERATOR_PRIORITY_VALUE, true, true, MULTIPLY_OPERATOR_CHAR_VIEW);
        s_divideOperator = new ArithmeticOperator(MULTIPLY_DIVIDE_OPERATOR_PRIORITY_VALUE, true, false, DIVIDE_OPERATOR_CHAR_VIEW);
        s_powerOperator = new ArithmeticOperator(POWER_OPERATOR_PRIORITY_VALUE, true, false, POWER_OPERATOR_CHAR_VIEW);
        s_noneOperator = new ArithmeticOperator();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstOperator"></param>
    /// <param name="secondOperator"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static IArithmeticOperator MergeOperator(IArithmeticOperator firstOperator, IArithmeticOperator secondOperator)
    {
        if (firstOperator.Priority != secondOperator.Priority)
            throw new ArgumentException();
        
        return firstOperator switch
        {
            { Priority: NONE_OPERATOR_PRIORITY_VALUE } => throw new ArgumentException(),
            { Priority: PLUS_MINUS_OPERATORS_PRIORITY_VALUE } =>
                firstOperator.CharView == MINUS_OPERATOR_CHAR_VIEW || secondOperator.CharView == MINUS_OPERATOR_CHAR_VIEW
                    ? Minus
                    : Plus,
            { Priority: MULTIPLY_DIVIDE_OPERATOR_PRIORITY_VALUE } =>
                firstOperator.CharView == MULTIPLY_OPERATOR_CHAR_VIEW ^ secondOperator.CharView == MULTIPLY_OPERATOR_CHAR_VIEW
                    ? Multiply
                    : Divide,
            { Priority: POWER_OPERATOR_PRIORITY_VALUE } => Power,
            _ => throw new ArgumentException(),
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="operatorPriority"></param>
    /// <returns></returns>
    public static IArithmeticOperator GetDefaultOperator(int operatorPriority)
    {
        switch(operatorPriority)
        {
            case PLUS_MINUS_OPERATORS_PRIORITY_VALUE:
                return Plus;
            case MULTIPLY_DIVIDE_OPERATOR_PRIORITY_VALUE:
                return Multiply;
            case POWER_OPERATOR_PRIORITY_VALUE:
                return Power;
            default:
                return None;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static IArithmeticOperator Plus => s_plusOperator;
    /// <summary>
    /// 
    /// </summary>
    public static IArithmeticOperator Minus => s_minusOperator;
    /// <summary>
    /// 
    /// </summary>
    public static IArithmeticOperator Multiply => s_multiplyOperator;
    /// <summary>
    /// 
    /// </summary>
    public static IArithmeticOperator Divide => s_divideOperator;
    /// <summary>
    /// 
    /// </summary>
    public static IArithmeticOperator Power => s_powerOperator;

    /// <summary>
    /// 
    /// </summary>
    public static IArithmeticOperator None => s_noneOperator;

    private readonly int _priority = NONE_OPERATOR_PRIORITY_VALUE;
    private readonly bool _isUnary = true;
    private readonly bool _isBinary = false;
    private readonly char _charView = NONE_OPERATOR_CHAR_VIEW;
    
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