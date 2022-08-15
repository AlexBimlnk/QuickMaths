using QuickMaths.General.Abstractions;

namespace QuickMaths.General.Enums;

/// <summary>
/// Значимый тип описывающий произвольный математический оператор.
/// </summary>
public struct ArithmeticOperator : IArithmeticOperator
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
    /// Приоритет пустого оператора.
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
        s_plusOperator = new ArithmeticOperator(PLUS_MINUS_OPERATORS_PRIORITY_VALUE, true, true, PLUS_OPERATOR_CHAR_VIEW, true);
        s_minusOperator = new ArithmeticOperator(PLUS_MINUS_OPERATORS_PRIORITY_VALUE, true, true, MINUS_OPERATOR_CHAR_VIEW, false);
        s_multiplyOperator = new ArithmeticOperator(MULTIPLY_DIVIDE_OPERATOR_PRIORITY_VALUE, true, true, MULTIPLY_OPERATOR_CHAR_VIEW, true);
        s_divideOperator = new ArithmeticOperator(MULTIPLY_DIVIDE_OPERATOR_PRIORITY_VALUE, true, false, DIVIDE_OPERATOR_CHAR_VIEW,false);
        s_powerOperator = new ArithmeticOperator(POWER_OPERATOR_PRIORITY_VALUE, true, false, POWER_OPERATOR_CHAR_VIEW, false);
        s_noneOperator = new ArithmeticOperator(NONE_OPERATOR_PRIORITY_VALUE,false, true, NONE_OPERATOR_CHAR_VIEW, true);
    }
    /// <summary>
    /// Объединение двух операторов одного приоритета в один в соответствии с правилами математики.
    /// <list>
    /// <listheader>Правила, по которым происходят слияния:</listheader>
    /// <item>(+,-) -> -</item> 
    /// <item>(-,-) -> +</item> 
    /// <item>(*,/) -> /</item> 
    /// <item>(*,/) -> /</item> 
    /// <item> (/,/) -> *</item> 
    /// </list>
    /// </summary>
    /// <param name="firstOperator">Первый оператор для объединения</param>
    /// <param name="secondOperator">Второй оператор для объединения</param>
    /// <returns>Полученный опретор полсе объединения двух, переданных в метод.</returns>
    /// <exception cref="ArgumentException">Если переданны операторы разного приоритета или пустые или не являющиеся стандартынми математическими операторами.</exception>
    public static IArithmeticOperator MergeOperator(IArithmeticOperator firstOperator, IArithmeticOperator secondOperator)
    {
        ArgumentNullException.ThrowIfNull(firstOperator, nameof(firstOperator));
        ArgumentNullException.ThrowIfNull(secondOperator, nameof(secondOperator));

        if (firstOperator.Priority != secondOperator.Priority)
            throw new ArgumentException($"{nameof(firstOperator)} and {nameof(secondOperator)} has different {nameof(Priority)}");
        
        return firstOperator switch
        {
            { Priority: NONE_OPERATOR_PRIORITY_VALUE } => throw new ArgumentException($"Given {nameof(firstOperator)} and {secondOperator} are {nameof(None)}"),
            { Priority: PLUS_MINUS_OPERATORS_PRIORITY_VALUE } =>
                firstOperator.CharView == MINUS_OPERATOR_CHAR_VIEW ^ secondOperator.CharView == MINUS_OPERATOR_CHAR_VIEW
                    ? Plus
                    : Minus,
            { Priority: MULTIPLY_DIVIDE_OPERATOR_PRIORITY_VALUE } =>
                firstOperator.CharView == MULTIPLY_OPERATOR_CHAR_VIEW ^ secondOperator.CharView == MULTIPLY_OPERATOR_CHAR_VIEW
                    ? Multiply
                    : Divide,
            { Priority: POWER_OPERATOR_PRIORITY_VALUE } => Power,
            _ => throw new ArgumentException($"Given operators with incorect {nameof(Priority)}"),
        };
    }

    /// <summary>
    /// Получение стандартного оператора для соответвующего приоритета.
    /// </summary>
    /// <param name="operatorPriority">Приоритет для опредления группы операторов.</param>
    /// <returns>Стандартный оператор для группы соответсвующей данному приоритету.</returns>
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
    /// Предсталвяет стандартный математический оператор - Плюс.
    /// </summary>
    public static IArithmeticOperator Plus => s_plusOperator;
    /// <summary>
    /// Предсталвяет стандартный математический оператор - Минус.
    /// </summary>
    public static IArithmeticOperator Minus => s_minusOperator;
    /// <summary>
    /// Предсталвяет стандартный математический оператор - Умножить.
    /// </summary>
    public static IArithmeticOperator Multiply => s_multiplyOperator;
    /// <summary>
    /// Предсталвяет стандартный математический оператор - Разделить.
    /// </summary>
    public static IArithmeticOperator Divide => s_divideOperator;
    /// <summary>
    /// Предсталвяет стандартный математический оператор - Возвести в степень.
    /// </summary>
    public static IArithmeticOperator Power => s_powerOperator;

    /// <summary>
    /// Предсталвяет математический пустой математический оператор.
    /// </summary>
    public static IArithmeticOperator None => s_noneOperator;

    private readonly int _priority;
    private readonly bool _isUnary;
    private readonly bool _isBinary;
    private readonly char _charView;
    private readonly bool _isSkipOnBeginInStringView;

    private ArithmeticOperator(int operatorPriority, bool isOperatorIsBinary, bool isOperatorIsUnary, char operatorCharView, bool isSkipOnBeginInStringView)
    {
        _priority = operatorPriority;
        _isBinary = isOperatorIsBinary;
        _isUnary = isOperatorIsUnary;
        _charView = operatorCharView;
        _isSkipOnBeginInStringView = isSkipOnBeginInStringView;
    }

    /// <inheritdoc />
    public int Priority => _priority;
    /// <inheritdoc />
    public bool IsUnary => _isUnary;
    /// <inheritdoc />
    public bool IsBinary => _isBinary;
    /// <inheritdoc />
    public char CharView => _charView;
    /// <inheritdoc />
    public bool IsSkipOnBeginInStringView => _isSkipOnBeginInStringView;
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