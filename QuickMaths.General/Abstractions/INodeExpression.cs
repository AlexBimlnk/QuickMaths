using QuickMaths.General.Enums;

namespace QuickMaths.General.Abstractions;

/// <summary>
/// Интерфейс, определяющий контракт поведения всех узлов в дереве выражений.
/// </summary>
public interface INodeExpression
{
    /// <summary>
    /// Приоритет узла.
    /// </summary>
    public Priority Priority { get; }
}
