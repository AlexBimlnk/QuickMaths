namespace QuickMaths.General.Abstractions;

/// <summary>
/// 
/// </summary>
public interface IArithmeticOperator
{
    /// <summary>
    /// Приоритет оператора, определяющий группу, к которой относится данный оператор.
    /// </summary>
    public int Priority { get; }
    /// <summary>
    /// Являетсяли ли оператор унарным.
    /// </summary>
    public bool IsUnary { get; }
    /// <summary>
    /// Являетсяли ли оператор бинарным.
    /// </summary>
    public bool IsBinary { get; }

    /// <summary>
    /// Получение символьного представления оператора.
    /// </summary>
    public char CharView { get; }

    /// <summary>
    /// Пропускается ли данный оператор если стоит в начале строки.
    /// </summary>
    public bool IsSkipOnBeginInStringView { get; }

}
