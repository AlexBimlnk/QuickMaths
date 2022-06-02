namespace QuickMaths.General.Abstractions;

/// <summary xml:lang = "ru">
/// Интерфейс, определяющий контракт поведения для всех узлов
/// хранящих какую либо сущность.
/// </summary>
/// <typeparam name="TEntity" xml:lang = "ru">
/// Тип сущности, которую будет хранить узел.
/// </typeparam>
public interface IEntityNode<TEntity> : INodeExpression
{
    /// <summary xml:lang = "ru">
    /// Сущность.
    /// </summary>
    public TEntity Source { get; }
}
