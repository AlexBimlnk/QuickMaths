using System;
using System.Linq;

using FluentAssertions;

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
        //Arrange
        var entity = "entity";

        //Act
        var exception = Record.Exception(() => new EntityNode<string>(entity));

        //Assert
        exception.Should().BeNull();
    }

    [Fact(DisplayName = "Cannot be created when args is null.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenArgumentsIsNull()
    {
        //Arrange
        string? nullEntity = null;

        //Act
        var exception = Record.Exception(() => new EntityNode<string>(nullEntity));

        //Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
    }

    #endregion

    #region Properties

    [Fact(DisplayName = "Can get source from entity.")]
    [Trait("Category", "Properties")]
    public void CanGetSource()
    {
        //Arrange
        var entity = "entity";
        var entityNode = new EntityNode<string>(entity);

        //Act
        var result = entityNode.Source;

        //Assert
        result.Should().Be(entity);
    }

    [Fact(DisplayName = "Can get priority of entity node.")]
    [Trait("Category", "Properties")]
    public void CanGetPriority()
    {
        //Arrange
        var entity = "entity";
        var entityNode = new EntityNode<string>(entity);

        //Act
        var result = entityNode.Priority;

        //Assert
        result.Should().Be(ArithmeticOperator.None.Priority);
    }

    #endregion

    #region Methods

    [Theory(DisplayName = "Can get child entities.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(EntityNodeTestsData.GetChildEntitiesData), MemberType = typeof(EntityNodeTestsData))]
    public void CanGetChildEntity(EntityNode<string> entityNode, ILookup<IArithmeticOperator, INodeExpression> expectedChildEntity)
    {
        //Arrange
        var func = (INodeExpression node) => node.GetChildEntities();
        var result = Enumerable.Empty<INodeExpression>().ToLookup(x => ArithmeticOperator.None, x => x);

        //Act
        result = func(entityNode);

        //Assert
        result.Should().BeEquivalentTo(expectedChildEntity);
    }

    [Theory(DisplayName = "Can merge entity node with others.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(EntityNodeTestsData.GetMergeNodesData), MemberType = typeof(EntityNodeTestsData))]
    public void CanMergeNodes(EntityNode<string> entityNode, IArithmeticOperator @operator, INodeExpression toMergeNode, INodeExpression epextedMergeResult)
    {
        //Arrange
        var func = (EntityNode<string> entityNode, IArithmeticOperator @operator, INodeExpression node) => entityNode.MergeNodes(@operator, node);

        var result = default(INodeExpression);

        try
        {
            //Act
            result = func(entityNode, @operator, toMergeNode);

            //Assert
            result.Should().BeEquivalentTo(epextedMergeResult);
            result.GetChildEntities().Should().BeEquivalentTo(epextedMergeResult.GetChildEntities());
        }
        catch
        {
            // Assert
            Assert.Throws<ArgumentException>(() => func(entityNode, @operator, toMergeNode));
        }
    }

    [Theory(DisplayName = "Cannot merge nodes with null arguments.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(EntityNodeTestsData.GetMergeNodesWithNullData), MemberType = typeof(EntityNodeTestsData))]
    public void CanNotMergeNodesWhenArgsIsNull(EntityNode<string> entityNode, IArithmeticOperator @operator, INodeExpression toMergeNode)
    {
        //Arrange
        var func = (EntityNode<string> entityNode, IArithmeticOperator @operator, INodeExpression node) => entityNode.MergeNodes(@operator, node);

        //Act
        var exception = Record.Exception(() => func(entityNode, @operator, toMergeNode));

        //Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "Can to string.")]
    [Trait("Category", "Methods")]
    public void CanToString()
    {
        var entity = "entity";
        var entityNode = new EntityNode<string>(entity);

        var result = entityNode.ToString();

        //Assert
        result.Should().BeEquivalentTo(entity.ToString());
    }
    #endregion
}
