using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure.Nodes;

/// <summary xml:lang = "ru">
/// Узел дерева выражений, содержащий сущность.
/// </summary>
/// <typeparam name="TEntity" xml:lang = "ru">
/// Тип сущности, который будет содержать данный узел.
/// </typeparam>
public sealed class EntityNode<TEntity> : IEntityNode<TEntity>
{
    private TEntity _entity;

    /// <summary xml:lang = "ru">
    /// Создает новый экземпляр типа <see cref="EntityNode{TEntity}"/>.
    /// </summary>
    /// <param name="entity" xml:lang = "ru">
    /// Сущность типа <typeparamref name="TEntity"/>, которую будет хранить в себе узел.
    /// </param>
    /// <exception cref="ArgumentNullException"/>
    public EntityNode(TEntity entity) => _entity = entity ?? throw new ArgumentNullException(nameof(entity));

    /// <inheritdoc/>
    public Priority Priority => throw new NotImplementedException();

    /// <inheritdoc/>
    public TEntity Source => _entity;
}
