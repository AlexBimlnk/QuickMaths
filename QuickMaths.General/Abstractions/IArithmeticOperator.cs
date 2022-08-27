namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Описывает арифметический оператор.
/// </summary>
public interface IArithmeticOperator
{
    /// <summary xml:lang = "ru">
    /// Приоритет оператора, определяющий группу, к которой относится данный оператор.
    /// </summary>
    public int Priority { get; }

    /// <summary xml:lang = "ru">
    /// Является ли оператор унарным.
    /// </summary>
    public bool IsUnary { get; }

    /// <summary xml:lang = "ru">
    /// Является ли оператор бинарным.
    /// </summary>
    public bool IsBinary { get; }

    /// <summary xml:lang = "ru">
    /// Символьное представление оператора.
    /// </summary>
    public char CharView { get; }

    /// <summary xml:lang = "ru">
    /// Пропускается ли данный оператор, если стоит в начале строки.
    /// </summary>
    public bool IsSkipOnBeginInStringView { get; }
}