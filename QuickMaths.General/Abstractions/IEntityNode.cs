namespace QuickMaths.General.Abstractions;
public interface IEntityNode<TEntity> : INodeExpression
{
    /// <summary xml:lang = "ru">
    /// Сущность, которую хранит узел.
    /// </summary>
    public TEntity Source { get; }
}
