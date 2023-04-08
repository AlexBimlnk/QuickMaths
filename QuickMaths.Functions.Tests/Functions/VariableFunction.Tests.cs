using System;

using FluentAssertions;

using QuickMaths.Functions.Functions;

using Xunit;

namespace QuickMaths.Functions.Tests.Functions;

public class VariableFunctionTests
{
    [Fact(DisplayName = "Can be created.")]
    [Trait("Category", "Unit")]
    public void CanBeCreated()
    {
        // Arrange
        var name = "x1";
        var value = 24.17;

        VariableFunction variable = null!;

        // Act
        var exception = Record.Exception(() =>
            variable = new VariableFunction(name, value));

        // Assert
        exception.Should().BeNull();
        variable.Name.Should().Be(name);
        variable.Value.Should().Be(value);
    }

    [Fact(DisplayName = "Can be created without value.")]
    [Trait("Category", "Unit")]
    public void CanBeCreatedWithoutValue()
    {
        // Arrange
        var name = "x1";

        VariableFunction variable = null!;

        // Act
        var exception = Record.Exception(() =>
            variable = new VariableFunction(name));

        // Assert
        exception.Should().BeNull();
        variable.Name.Should().Be(name);
    }

    [Theory(DisplayName = "Cannot be created without name.")]
    [InlineData(null!)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(" \r \n \t ")]
    [Trait("Category", "Unit")]
    public void CanNotBeCreatedWithoutName(string name)
    {
        // Arrange
        var value = 14.17;

        // Act
        var exception = Record.Exception(() =>
            _ = new VariableFunction(name));

        // Assert
        exception.Should().NotBeNull()
            .And.BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "Can calulate.")]
    [Trait("Category", "Unit")]
    public void CanCalculate()
    {
        // Arrange
        var expectedValue = 145d;

        // Act
        var result = new VariableFunction("name", 145d).Calculate();

        // Assert
        result.Should().Be(expectedValue);
    }

    [Fact(DisplayName = "Cannot calulate without value.")]
    [Trait("Category", "Unit")]
    public void CanNotCalculateWithoutValue()
    {
        // Act
        var exception = Record.Exception(() =>
            new VariableFunction("name").Calculate());

        // Assert
        exception.Should().BeOfType<InvalidOperationException>();
    }

    [Fact(DisplayName = "Can get derivative.")]
    [Trait("Category", "Unit")]
    public void CanGetDerivative()
    {
        // Act
        var result = new VariableFunction("name", 126).Derivative();

        // Assert
        result.Should().Be(new NumberFunction(1));
    }
}
