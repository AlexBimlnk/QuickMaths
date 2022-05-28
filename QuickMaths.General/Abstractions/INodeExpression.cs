using QuickMaths.General.Enums;

namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Интерфейс, определяющий контракт поведения всех узлов в дереве выражений.
/// </summary>
public interface INodeExpression : IArithmeticable
{
    /// <summary xml:lang = "ru">
    /// Приоритет узла.
    /// </summary>
    public Priority Priority { get; }
}
