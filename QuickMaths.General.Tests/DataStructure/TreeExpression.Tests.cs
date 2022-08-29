using System;

using FluentAssertions;

using QuickMaths.General.Abstractions;

using Xunit;

namespace QuickMaths.General.DataStructure.Tests;

//ToDo: refactor tree expression tests
public class TreeExpressionTests
{
    #region Constructor

    [Theory(DisplayName = "Can be created.")]
    [Trait("Category", "Constructors")]
    [MemberData(nameof(TreeExpressionTestsData.CanCreateData), MemberType = typeof(TreeExpressionTestsData))]
    public void CanBeCreated(IArithmeticOperator @operator, string rootEntity)
    {
        // Arrange
        var func = (string root, IArithmeticOperator @operator) => new TreeExpression<string>(root, @operator);

        // Act
        var exception = Record.Exception(() => func(rootEntity, @operator));

        // Assert
        exception.Should().BeNull();
    }

    [Theory(DisplayName = "Cannot be created when args is null.")]
    [Trait("Category", "Constructors")]
    [MemberData(nameof(TreeExpressionTestsData.CanNotBeCreatedWithNullData), MemberType = typeof(TreeExpressionTestsData))]
    public void CanNotBeCreatedWhenArgumentsIsNull(IArithmeticOperator @operator, string rootEntity)
    {
        // Arrange
        var func = (string root, IArithmeticOperator @operator) => new TreeExpression<string>(root, @operator);

        // Act
        var exception = Record.Exception(() => func(rootEntity, @operator));

        // Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
    }

    #endregion

    #region Methods

    //set root

    [Theory(DisplayName = "Can set root.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(TreeExpressionTestsData.CanSetRootData), MemberType = typeof(TreeExpressionTestsData))]
    public void CanSetRoot(TreeExpression<string> tree, IArithmeticOperator @operator, string rootEntity, TreeExpression<string> expectedResult)
    {
        // Arrange
        var func = (TreeExpression<string> tree, IArithmeticOperator rootOperator, string rootEntity) => tree.SetRoot(rootEntity, rootOperator);
        var result = default(TreeExpression<string>);

        try
        {
            // Act
            func(tree, @operator, rootEntity);
            result = tree;

            // Assert
            result.Root.Should().BeEquivalentTo(expectedResult.Root);
        }
        catch
        {
            // Assert
            Assert.Throws<ArgumentException>(() => func(tree, @operator, rootEntity));
        }
    }

    [Theory(DisplayName = "Cannot set root when args is null.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(TreeExpressionTestsData.CanNotSetRootWithNullData), MemberType = typeof(TreeExpressionTestsData))]
    public void CannotSetRootWithNullArgs(TreeExpression<string> tree, IArithmeticOperator @operator, string rootEntity)
    {
        // Arrange
        var func = (TreeExpression<string> tree, IArithmeticOperator rootOperator, string rootEntity) => tree.SetRoot(rootEntity, rootOperator);

        // Act
        var exception = Record.Exception(() => func(tree, @operator, rootEntity));

        // Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
    }


    //add entity

    [Theory(DisplayName = "Can add entity.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(TreeExpressionTestsData.CanAddEntityData), MemberType = typeof(TreeExpressionTestsData))]
    public void CanAddEntity(TreeExpression<string> tree, IArithmeticOperator @operator, string entity, TreeExpression<string> expectedResult)
    {
        // Arrange
        var func = (TreeExpression<string> tree, IArithmeticOperator @operator, string entity) => tree.Add(@operator, entity);
        var result = default(TreeExpression<string>);

        try
        {
            // Act
            func(tree, @operator, entity);
            result = tree;

            // Assert
            result.Root.Should().BeEquivalentTo(expectedResult.Root);
        }
        catch
        {
            // Assert
            Assert.Throws<ArgumentException>(() => func(tree, @operator, entity));
        }
    }

    [Theory(DisplayName = "Cannot add entity when args in null.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(TreeExpressionTestsData.CanAddEntityWithNullData), MemberType = typeof(TreeExpressionTestsData))]
    public void CannotAddEntityWithNullArgs(TreeExpression<string> tree, IArithmeticOperator @operator, string entity)
    {
        // Arrange
        var func = (TreeExpression<string> tree, IArithmeticOperator @operator, string entity) => tree.Add(@operator, entity);

        // Act
        var exception = Record.Exception(() => func(tree, @operator, entity));

        // Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
    }

    //add tree

    [Theory(DisplayName = "Can add tree.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(TreeExpressionTestsData.CanAddTreeData), MemberType = typeof(TreeExpressionTestsData))]
    public void CanAddTree(TreeExpression<string> tree, IArithmeticOperator @operator, TreeExpression<string> entityTree, TreeExpression<string> expectedResult)
    {
        // Arrange
        var func = (TreeExpression<string> tree, IArithmeticOperator @operator, TreeExpression<string> entityTree) => tree.Add(@operator, entityTree);
        var result = default(TreeExpression<string>);

        try
        {
            // Act
            func(tree, @operator, entityTree);
            result = tree;

            // Assert
            result.Root.Should().BeEquivalentTo(expectedResult.Root);
        }
        catch
        {
            // Assert
            Assert.Throws<ArgumentException>(() => func(tree, @operator, entityTree));
        }
    }

    [Theory(DisplayName = "Cannot add tree when args in null.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(TreeExpressionTestsData.CanAddTreeWithNullData), MemberType = typeof(TreeExpressionTestsData))]
    public void CannotAddTreeWithNullArgs(TreeExpression<string> tree, IArithmeticOperator @operator, TreeExpression<string> entityTree)
    {
        // Arrange
        var func = (TreeExpression<string> tree, IArithmeticOperator @operator, TreeExpression<string> entityTree) => tree.Add(@operator, entityTree);

        // Act
        var exception = Record.Exception(() => func(tree, @operator, entityTree));

        // Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
    }

    #endregion
}
