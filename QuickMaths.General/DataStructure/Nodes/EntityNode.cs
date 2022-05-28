using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickMaths.General.Abstractions;
using QuickMaths.General.Enums;

namespace QuickMaths.General.DataStructure.Nodes;
public sealed class EntityNode<TEntity> : INodeExpression, IArithmeticable
{
    private TEntity _entity;

    public EntityNode(TEntity entity) => _entity = entity ?? throw new ArgumentNullException(nameof(entity));

    public Priority Priority => throw new NotImplementedException();
}
