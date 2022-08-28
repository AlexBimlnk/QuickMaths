using System;
using System.Linq;

using FluentAssertions;

using Moq;

using QuickMaths.General.Abstractions;

using Xunit;

namespace QuickMaths.General.DataStructure.Nodes.Tests;

//ToDo: tests operator node
public class OperatorNodeTests
{
    #region Constructors

    [Fact(DisplayName = "Can be created.")]
    [Trait("Category", "Constructors")]
    public void CanBeCreated()
    {
        // Arrange
        var baseOperator = new Mock<IArithmeticOperator>(MockBehavior.Strict);
        OperatorNode node = null!;

        baseOperator.Setup(x => x.Priority)
            .Returns(It.IsAny<int>());

        // Act
        var exception = Record.Exception(() => node = new OperatorNode(baseOperator.Object));

        // Assert
        exception.Should().BeNull();
        node.Priority.Should().Be(baseOperator.Object.Priority);
    }

    [Fact(DisplayName = "Cannot be created when args is null.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWithoutOperator()
    {
        // Act
        var exception = Record.Exception(() => new OperatorNode(null!));

        // Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "Cannot be created when incorrect operator was given.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenIncorrectOperator()
    {
        // Arrange
        var baseOperator = new Mock<IArithmeticOperator>(MockBehavior.Strict);
        OperatorNode node = null!;

        baseOperator.Setup(x => x.Priority)
            .Returns(-1);

        // Act
        var exception = Record.Exception(() => node = new OperatorNode(baseOperator.Object));

        // Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentException>();
    }
    #endregion

    #region Methods

    [Fact(DisplayName = "Can append operand.")]
    [Trait("Category", "Methods")]
    public void CanAppendOperand()
    {
        // Arrange
        var @operator = new Mock<IArithmeticOperator>(MockBehavior.Strict);
        var operand = new Mock<INodeExpression>(MockBehavior.Strict);
        var node = new OperatorNode(@operator.Object);

        var childEntities = Enumerable.Empty<INodeExpression>()
            .ToLookup(x => Mock.Of<IArithmeticOperator>(MockBehavior.Strict), x => x);

        @operator.Setup(x => x.Priority)
            .Returns(2);

        operand.Setup(x => x.Priority)
            .Returns(2);
        operand.Setup(x => x.GetChildEntities())
            .Returns(childEntities);

        // ToDo
        var expectedResult = new OperatorNode(@operator.Object);

        // Act
        var result = node.AppendOperand(@operator.Object, operand.Object);

        // Assert
        result.Should().Be(node).And.BeEquivalentTo(expectedResult);
    }
    #endregion
}
