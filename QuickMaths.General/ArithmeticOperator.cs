using QuickMaths.General.Abstractions;

namespace QuickMaths.General;

/// <summary xml:lang = "ru">
/// Произвольный математический оператор.
/// </summary>
public static class ArithmeticOperator
{
    private const int PLUS_MINUS_OPERATORS_PRIORITY_VALUE = 1;
    private const int MULTIPLY_DIVIDE_OPERATOR_PRIORITY_VALUE = 2;
    private const int POWER_OPERATOR_PRIORITY_VALUE = 3;

    private const char PLUS_OPERATOR_CHAR_VIEW = '+';
    private const char MINUS_OPERATOR_CHAR_VIEW = '-';
    private const char MULTIPLY_OPERATOR_CHAR_VIEW = '*';
    private const char DIVIDE_OPERATOR_CHAR_VIEW = '/';
    private const char POWER_OPERATOR_CHAR_VIEW = '^';
    private const char NONE_OPERATOR_CHAR_VIEW = '\0';

    /// <summary xml:lang = "ru">
    /// Приоритет пустого оператора.
    /// </summary>
    public const int NONE_OPERATOR_PRIORITY_VALUE = -1;

    static ArithmeticOperator()
    {
        Plus = new CustomOperator(
            operatorPriority: PLUS_MINUS_OPERATORS_PRIORITY_VALUE,
            isOperatorIsBinary: true,
            isOperatorIsUnary: true,
            operatorCharView: PLUS_OPERATOR_CHAR_VIEW,
            isSkipOnBeginInStringView: true);

        Minus = new CustomOperator(
            operatorPriority: PLUS_MINUS_OPERATORS_PRIORITY_VALUE,
            isOperatorIsBinary: true,
            isOperatorIsUnary: true,
            operatorCharView: MINUS_OPERATOR_CHAR_VIEW,
            isSkipOnBeginInStringView: false);

        Multiply = new CustomOperator(
            operatorPriority: MULTIPLY_DIVIDE_OPERATOR_PRIORITY_VALUE,
            isOperatorIsBinary: true,
            isOperatorIsUnary: true,
            operatorCharView: MULTIPLY_OPERATOR_CHAR_VIEW,
            isSkipOnBeginInStringView: true);

        Divide = new CustomOperator(
            operatorPriority: MULTIPLY_DIVIDE_OPERATOR_PRIORITY_VALUE,
            isOperatorIsBinary: true,
            isOperatorIsUnary: false,
            operatorCharView: DIVIDE_OPERATOR_CHAR_VIEW,
            isSkipOnBeginInStringView: false);

        Power = new CustomOperator(
            operatorPriority: POWER_OPERATOR_PRIORITY_VALUE,
            isOperatorIsBinary: true,
            isOperatorIsUnary: false,
            operatorCharView: POWER_OPERATOR_CHAR_VIEW,
            isSkipOnBeginInStringView: false);

        None = new CustomOperator(
            operatorPriority: NONE_OPERATOR_PRIORITY_VALUE,
            isOperatorIsBinary: false,
            isOperatorIsUnary: true,
            operatorCharView: NONE_OPERATOR_CHAR_VIEW,
            isSkipOnBeginInStringView: true);
    }

    /// <summary xml:lang = "ru">
    /// Стандартный математический оператор "Плюс".
    /// </summary>
    public static IArithmeticOperator Plus { get; }

    /// <summary xml:lang = "ru">
    /// Стандартный математический оператор "Минус".
    /// </summary>
    public static IArithmeticOperator Minus { get; }

    /// <summary xml:lang = "ru">
    /// Стандартный математический оператор - "Умножить".
    /// </summary>
    public static IArithmeticOperator Multiply { get; }

    /// <summary xml:lang = "ru">
    /// Стандартный математический оператор "Разделить".
    /// </summary>
    public static IArithmeticOperator Divide { get; }

    /// <summary xml:lang = "ru">
    /// Стандартный математический оператор "Возвести в степень".
    /// </summary>
    public static IArithmeticOperator Power { get; }

    /// <summary xml:lang = "ru">
    /// Пустой математический оператор.
    /// </summary>
    public static IArithmeticOperator None { get; }

    /// <summary xml:lang = "ru">
    /// Объединение двух операторов одного приоритета в один в соответствии с правилами математики.
    /// <list>
    /// <listheader>Правила, по которым происходят слияния:</listheader>
    /// <item>(+,-) -> -</item> 
    /// <item>(-,-) -> +</item> 
    /// <item>(*,/) -> /</item> 
    /// <item>(/,*) -> /</item> 
    /// <item> (/,/) -> *</item> 
    /// </list>
    /// </summary>
    /// <param name="firstOperator" xml:lang = "ru">
    /// Первый оператор для объединения.
    /// </param>
    /// <param name="secondOperator" xml:lang = "ru">
    /// Второй оператор для объединения.
    /// </param>
    /// <returns>
    /// Полученный опретор полсе объединения двух, переданных в метод.
    /// </returns>
    /// <exception cref="ArgumentException" xml:lang = "ru">
    /// Если переданны операторы разного приоритета или пустые или 
    /// не являющиеся стандартными математическими операторами.
    /// </exception>
    public static IArithmeticOperator MergeOperator(IArithmeticOperator firstOperator, IArithmeticOperator secondOperator)
    {
        ArgumentNullException.ThrowIfNull(firstOperator, nameof(firstOperator));
        ArgumentNullException.ThrowIfNull(secondOperator, nameof(secondOperator));

        if (firstOperator.Priority != secondOperator.Priority)
            throw new ArgumentException($"{nameof(firstOperator)} and {nameof(secondOperator)} has different priority");

        return firstOperator switch
        {
            { Priority: NONE_OPERATOR_PRIORITY_VALUE } => throw new ArgumentException($"Given {nameof(firstOperator)} and {secondOperator} are {nameof(None)}"),
            { Priority: PLUS_MINUS_OPERATORS_PRIORITY_VALUE } =>
                firstOperator.CharView == MINUS_OPERATOR_CHAR_VIEW != (secondOperator.CharView == MINUS_OPERATOR_CHAR_VIEW)
                    ? Minus
                    : Plus,
            { Priority: MULTIPLY_DIVIDE_OPERATOR_PRIORITY_VALUE } =>
                firstOperator.CharView == MULTIPLY_OPERATOR_CHAR_VIEW != (secondOperator.CharView == MULTIPLY_OPERATOR_CHAR_VIEW)
                    ? Divide
                    : Multiply,
            { Priority: POWER_OPERATOR_PRIORITY_VALUE } => Power,
            _ => throw new ArgumentException($"Given operators with incorect {nameof(firstOperator.Priority)}"),
        };
    }

    /// <summary xml:lang = "ru">
    /// Получение стандартного оператора для соответвующего приоритета.
    /// </summary>
    /// <param name="operatorPriority" xml:lang = "ru">
    /// Приоритет для опредления группы операторов.
    /// </param>
    /// <returns xml:lang = "ru">
    /// Стандартный оператор для группы соответсвующей данному приоритету.
    /// </returns>
    public static IArithmeticOperator GetDefaultOperator(int operatorPriority) => operatorPriority switch
    {
        PLUS_MINUS_OPERATORS_PRIORITY_VALUE => Plus,
        MULTIPLY_DIVIDE_OPERATOR_PRIORITY_VALUE => Multiply,
        POWER_OPERATOR_PRIORITY_VALUE => Power,
        _ => None,
    };

    private sealed class CustomOperator : IArithmeticOperator
    {
        public CustomOperator(
            int operatorPriority,
            bool isOperatorIsBinary,
            bool isOperatorIsUnary,
            char operatorCharView,
            bool isSkipOnBeginInStringView)
        {
            Priority = operatorPriority;
            IsBinary = isOperatorIsBinary;
            IsUnary = isOperatorIsUnary;
            CharView = operatorCharView;
            IsSkipOnBeginInStringView = isSkipOnBeginInStringView;
        }

        /// <inheritdoc />
        public int Priority { get; }
        /// <inheritdoc />
        public bool IsUnary { get; }
        /// <inheritdoc />
        public bool IsBinary { get; }
        /// <inheritdoc />
        public char CharView { get; }
        /// <inheritdoc />
        public bool IsSkipOnBeginInStringView { get; }
        /// <inheritdoc/>
        public override string ToString() => $"{CharView}";
    }
}