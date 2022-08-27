using System;

using FluentAssertions;

using QuickMaths.FunctionsBLL.Functions;
using QuickMaths.General.Abstractions;

using Xunit;

namespace QuickMaths.FunctionsBLL.Tests.Functions;

public class LinearFunctionTests
{
    #region Конструкторы

    [Fact(DisplayName = "Can be created.")]
    [Trait("Category", "Constructors")]
    public void CanBeCreated()
    {
        // Arrange
        var argument = new VariableFunction("x");
        var koef = new NumberFunction(12);
        LinearFunction func = null!;

        // Act
        var exception = Record.Exception(() => func = new LinearFunction(argument, koef));

        // Assert
        exception.Should().BeNull();
        func.Argument.Should().Be(argument);
        func.Koef.Should().Be(koef);
    }

    [Fact(DisplayName = "Can be created without koef.")]
    [Trait("Category", "Constructors")]
    public void CanBeCreatedWithoutKoef()
    {
        // Arrange
        var argument = new VariableFunction("x");
        LinearFunction func = null!;

        // Act
        var exception = Record.Exception(() => func = new LinearFunction(argument));

        // Assert
        exception.Should().BeNull();
        func.Argument.Should().Be(argument);
        func.Koef.Should().BeEquivalentTo(new NumberFunction(1));
    }

    [Fact(DisplayName = "Cannot be created when arguments is null.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenArgumentsIsNull()
    {
        // Act
        var exception = Record.Exception(() => new LinearFunction(null!));

        // Assert
        exception.Should().BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "Cannot be created when arguments is null.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenKoefIsNull()
    {
        // Arrange
        var argument = new VariableFunction("x");

        // Act
        var exception = Record.Exception(() => new LinearFunction(argument, null!));

        // Assert
        exception.Should().BeOfType<ArgumentNullException>();
    }
    #endregion

    #region Методы

    [Theory(DisplayName = "Equals LF and other function works.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(LinearFunctionTestsData.EqualsLFAndOtherFunctionData), MemberType = typeof(LinearFunctionTestsData))]
    public void EqualsLFAndOtherFunctionWork(LinearFunction function, IFunction other, bool expectedValue)
    {
        // Act
        var result = function.Equals(other);

        // Assert
        result.Should().Be(expectedValue);
    }

    [Fact(DisplayName = "GetHashCode works.")]
    [Trait("Category", "Methods")]
    public void GetHashCodeWork()
    {
        // Arrange
        var argument = new VariableFunction("x");
        var koef = new NumberFunction(3);
        var linear = new LinearFunction(argument, koef);
        var expectedHashCode = HashCode.Combine(koef, argument, nameof(LinearFunction));

        // Act
        var result = linear.GetHashCode();

        // Assert
        result.Should().Be(expectedHashCode);
    }

    [Fact(DisplayName = "ToString works.")]
    [Trait("Category", "Methods")]
    public void ToStringWork()
    {
        // Arrange
        var linear = new LinearFunction(new VariableFunction("x"), new NumberFunction(3));
        var expectedString = "3*x";

        // Act
        var result = linear.ToString();

        // Assert
        result.Should().Be(expectedString);
    }
    #endregion
}
