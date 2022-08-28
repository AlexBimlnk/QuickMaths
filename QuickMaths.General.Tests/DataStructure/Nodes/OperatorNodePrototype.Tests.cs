using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickMaths.General.Abstractions;

using FluentAssertions;
using Xunit;

namespace QuickMaths.General.DataStructure.Nodes.Tests;
public class OperatorNodePrototypeTests
{
    #region Constructors

    [Fact(DisplayName = "Can be created.")]
    [Trait("Category", "Constructors")]
    //[MemberData(nameof(OperatorNodePrototypeTestsData.GetToCreateData), MemberType = typeof(OperatorNodePrototypeTestsData))]
    public void CanBeCreated()
    {
        //Arrange
        var baseOperator = ArithmeticOperator.Plus;

        //Act
        var exception = Record.Exception(() => new OperatorNode(baseOperator));

        //Assert
        exception.Should().BeNull();
    }

    [Fact(DisplayName = "Cannot be created when args is null.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenArgumentsIsNull()
    {
        //Arrange
        IArithmeticOperator? nullBaseOperator = null;

        //Act
        var exception = Record.Exception(() => new OperatorNode(nullBaseOperator));

        //Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "Cannot be created when incorrect operator was given.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenIncorrectOperator()
    {
        //Arrange
        IArithmeticOperator incorrectBaseOperator = ArithmeticOperator.None;

        //Act
        var exception = Record.Exception(() => new OperatorNode(incorrectBaseOperator));

        //Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentException>();
    }
    [Theory(DisplayName = "Can create with lookup.")]
    [Trait("Category", "Constructors")]
    [MemberData(nameof(OperatorNodePrototypeTestsData.CanCreateWithLookupData), MemberType = typeof(OperatorNodePrototypeTestsData))]
    public void CanCreateWithLookUp(IArithmeticOperator @operator ,ILookup<IArithmeticOperator, INodeExpression> lookUp)
    {
        //Arrange
        var func = (IArithmeticOperator baseOperator, ILookup<IArithmeticOperator, INodeExpression> baseLookUp) => new OperatorNodePrototype(baseOperator, baseLookUp);

        //Act
        var exception = Record.Exception(() => func(@operator, lookUp));

        //Assert
        exception.Should().BeNull();
    }
    #endregion

    #region Properties

    [Fact(DisplayName = "Can get priority of operator node.")]
    [Trait("Category", "Properties")]
    public void CanGetPriority()
    {
        //Arrange
        var baseOperator = ArithmeticOperator.Plus;
        var operatorNode = new OperatorNode(baseOperator);

        //Act
        var result = operatorNode.Priority;

        //Assert
        result.Should().Be(baseOperator.Priority);
    }

    #endregion

    #region Methods

    [Theory(DisplayName = "Can get child entities.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(OperatorNodePrototypeTestsData.GetChildEntitiesData), MemberType = typeof(OperatorNodePrototypeTestsData))]
    public void CanGetChildEntity(OperatorNode operatorNode, ILookup<IArithmeticOperator, INodeExpression> expectedChildEntities)
    {
        //Arrange
        var func = (INodeExpression node) => node.GetChildEntities();
        var result = Enumerable.Empty<INodeExpression>().ToLookup(x => ArithmeticOperator.None, x => x);

        //Act
        result = func(operatorNode);

        //Assert
        result.Should().BeEquivalentTo(expectedChildEntities);
    }

    [Theory(DisplayName = "Can add operand.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(OperatorNodePrototypeTestsData.GetAddOperandData), MemberType = typeof(OperatorNodePrototypeTestsData))]
    public void CanAddOperand(OperatorNode operatorNode, IArithmeticOperator @operator, INodeExpression toAddOperand, INodeExpression expextedResult)
    {
        //Arrange
        var func = (OperatorNode node, IArithmeticOperator @operator, INodeExpression operand) => node.AppendOperand(@operator, operand);

        var result = default(INodeExpression);

        try
        {
            //Act
            func(operatorNode, @operator, toAddOperand);
            result = operatorNode;

            //Assert
            result.Should().BeEquivalentTo(expextedResult);
            result.GetChildEntities().Should().BeEquivalentTo(expextedResult.GetChildEntities());
        }
        catch
        {
            // Assert
            Assert.Throws<ArgumentException>(() => func(operatorNode, @operator, toAddOperand));
        }
    }

    [Theory(DisplayName = "Can merge entity node with others.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(OperatorNodePrototypeTestsData.GetMergeNodesData), MemberType = typeof(OperatorNodePrototypeTestsData))]
    public void CanMergeNodes(OperatorNode operatorNode, IArithmeticOperator @operator, INodeExpression toMergeNode, INodeExpression epextedMergeResult)
    {
        //Arrange
        var func = (OperatorNode entityNode, IArithmeticOperator @operator, INodeExpression node) => entityNode.MergeNodes(@operator, node);

        var result = default(INodeExpression);

        try
        {
            //Act
            result = func(operatorNode, @operator, toMergeNode);

            //Assert
            result.Should().BeEquivalentTo(epextedMergeResult);
            result.GetChildEntities().Should().BeEquivalentTo(epextedMergeResult.GetChildEntities());
        }
        catch
        {
            // Assert
            Assert.Throws<ArgumentException>(() => func(operatorNode, @operator, toMergeNode));
        }
    }

    [Theory(DisplayName = "Cannot merge nodes with null arguments.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(OperatorNodePrototypeTestsData.GetMergeNodesWithNullData), MemberType = typeof(OperatorNodePrototypeTestsData))]
    public void CanNotMergeNodesWhenArgsIsNull(OperatorNode operatorNode, IArithmeticOperator @operator, INodeExpression toMergeNode)
    {
        //Arrange
        var func = (OperatorNode entityNode, IArithmeticOperator @operator, INodeExpression node) => entityNode.MergeNodes(@operator, node);

        //Act
        var exception = Record.Exception(() => func(operatorNode, @operator, toMergeNode));

        //Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
    }

    #endregion
}
