namespace QuickMaths.General.Abstractions;

/// <summary>
/// Интерфейс, определяющий контракт поведения для всех узлов
/// хранящих какую либо сущность.
/// </summary>
/// <typeparam name="TEntity">
/// Тип сущности, которую будет хранить узел.
/// </typeparam>
public interface IEntityNode<TEntity> : INodeExpression
{
    /// <summary>
    /// Сущность.
    /// </summary>
    public TEntity Source { get; }
}
