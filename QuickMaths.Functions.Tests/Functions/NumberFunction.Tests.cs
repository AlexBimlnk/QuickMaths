using FluentAssertions;

using QuickMaths.Functions.Functions;

using Xunit;

namespace QuickMaths.Functions.Tests.Functions;

public class NumberFunctionTests
{
    [Fact(DisplayName = "Can be created.")]
    [Trait("Category", "Unit")]
    public void CanBeCreated()
    {
        // Arrange
        var value = 128d;
        NumberFunction number = new();

        // Act
        var exception1 = Record.Exception(() =>
            number = new NumberFunction(value));

        // Assert
        exception1.Should().BeNull();
        number.Value.Should().Be(value);
    }

    [Fact(DisplayName = "Can be created without value.")]
    [Trait("Category", "Unit")]
    public void CanBeCreatedWithoutValue()
    {
        // Arrange
        NumberFunction number = new();

        // Act
        var exception1 = Record.Exception(() =>
            number = new NumberFunction());

        // Assert
        exception1.Should().BeNull();
        number.Value.Should().Be(0);
    }

    [Fact(DisplayName = "Can calulate.")]
    [Trait("Category", "Unit")]
    public void CanCalculate()
    {
        // Arrange
        var value = 145;
        var expectedValue = 145;

        // Act
        var result = new NumberFunction(value).Calculate();

        // Assert
        result.Should().Be(expectedValue);
    }

    [Fact(DisplayName = "Cannot get derivative.")]
    [Trait("Category", "Unit")]
    public void CanGetDerivative()
    {
        // Act
        var result = ((IFunction)new NumberFunction(145)).Derivative();

        // Assert
        result.Should().NotBeNull()
            .And.BeOfType<NumberFunction>();

        ((NumberFunction)result).Value.Should().Be(0);
    }
}
