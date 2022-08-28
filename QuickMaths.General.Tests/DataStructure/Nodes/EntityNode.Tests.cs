using System;
using System.Linq;

using FluentAssertions;

using Moq;

using QuickMaths.General.Abstractions;

using Xunit;

namespace QuickMaths.General.DataStructure.Nodes.Tests;
public class EntityNodeTests
{
    #region Constructors

    [Fact(DisplayName = "Can be created.")]
    [Trait("Category", "Constructors")]
    public void CanBeCreated()
    {
        // Arrange
        var entity = new FakeEntity();
        EntityNode<FakeEntity> node = null!;

        // Act
        var exception = Record.Exception(() => node = new EntityNode<FakeEntity>(entity));

        // Assert
        exception.Should().BeNull();
        node.Source.Should().Be(entity);
        node.Priority.Should().Be(ArithmeticOperator.None.Priority);
    }

    [Fact(DisplayName = "Cannot be created when args is null.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenArgumentsIsNull()
    {
        // Act
        var exception = Record.Exception(() => new EntityNode<FakeEntity>(null!));

        // Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
    }

    #endregion

    #region Methods

    [Fact(DisplayName = "Can get child entities.")]
    [Trait("Category", "Methods")]
    public void CanGetChildEntity()
    {
        // Arrange
        var entity = new FakeEntity();
        var node = new EntityNode<FakeEntity>(entity);
        var expectedResult = Enumerable.Empty<INodeExpression>().ToLookup(x => ArithmeticOperator.None, x => x);

        // Act
        var result = node.GetChildEntities();

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact(DisplayName = "Can merge entity node with others.")]
    [Trait("Category", "Methods")]
    public void CanMergeNodes()
    {
        // Arrange
        var node = new EntityNode<FakeEntity>(new FakeEntity());
        var @operator = Mock.Of<IArithmeticOperator>(MockBehavior.Strict);
        var toMergeNode = Mock.Of<INodeExpression>(MockBehavior.Strict);

        var expectedResult = new OperatorNode(@operator)
            .AppendOperand(ArithmeticOperator.None, node)
            .AppendOperand(@operator, toMergeNode);

        // Act
        var result = node.MergeNodes(@operator, toMergeNode);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact(DisplayName = "Cannot merge nodes without operator.")]
    [Trait("Category", "Methods")]
    public void CanNotMergeNodesWithoutOperator()
    {
        // Arrange
        var node = new EntityNode<FakeEntity>(new FakeEntity());

        // Act
        var exception = Record.Exception(() => 
            node.MergeNodes(null!, Mock.Of<INodeExpression>(MockBehavior.Strict)));

        // Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "Cannot merge nodes without other node.")]
    [Trait("Category", "Methods")]
    public void CanNotMergeNodesWithoutOtherNode()
    {
        // Arrange
        var node = new EntityNode<FakeEntity>(new FakeEntity());

        // Act
        var exception = Record.Exception(() => 
            node.MergeNodes(Mock.Of<IArithmeticOperator>(MockBehavior.Strict), null!));

        // Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "ToString works.")]
    [Trait("Category", "Methods")]
    public void ToStringWorks()
    {
        var entity = new FakeEntity();
        var entityNode = new EntityNode<FakeEntity>(entity);

        var result = entityNode.ToString();

        // Assert
        result.Should().BeEquivalentTo(entity.ToString());
    }
    #endregion

    public record class FakeEntity();
}
