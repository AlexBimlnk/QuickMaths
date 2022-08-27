using System;

using FluentAssertions;

using QuickMaths.FunctionsBLL.Functions;
using QuickMaths.General.Abstractions;

using Xunit;

namespace QuickMaths.FunctionsBLL.Tests.Functions;

public class NumberFunctionTests
{
    #region Конструкторы

    [Fact(DisplayName = "Can be created.")]
    [Trait("Category", "Constructors")]
    public void CanBeCreated()
    {
        // Arrange
        var inputNumber = 128d;
        NumberFunction func1 = null!;
        NumberFunction func2 = null!;

        // Act
        var exception1 = Record.Exception(() => func1 = new NumberFunction(inputNumber));
        var exception2 = Record.Exception(() => func2 = new NumberFunction($"{inputNumber}"));

        // Assert
        exception1.Should().BeNull();
        exception2.Should().BeNull();
        func1.Value.Should().Be(inputNumber);
        func2.Value.Should().Be(inputNumber);
    }

    [Theory(DisplayName = "Cannot be created when string is null or empty.")]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(" \n  \r")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenStringIsNullOrEmpty(string value)
    {
        // Act
        var exception = Record.Exception(() => new NumberFunction(value));

        // Assert
        exception.Should().NotBeNull().And.BeOfType<ArgumentException>();
    }

    [Fact(DisplayName = "Cannot be created when string be in invalid format.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenFormatStringIsInvalid()
    {
        // Arrange
        var invalidString = "sda 144 f";

        // Act
        var exception = Record.Exception(() => new NumberFunction(invalidString));

        // Assert
        exception.Should().NotBeNull().And.BeOfType<FormatException>();
    }
    #endregion

    #region Методы

    [Fact(DisplayName = "Can calulate.")]
    [Trait("Category", "Methods")]
    public void CanCalculate()
    {
        // Arrange
        var expectedValue = 145;

        // Act
        var result = new NumberFunction(expectedValue).Calculate();

        // Assert
        result.Should().Be(expectedValue);
    }

    [Fact(DisplayName = "Cannot get derivative.")]
    [Trait("Category", "Methods")]
    public void CanNotGetDerivative()
    {
        // Act
        IFunction result = ((IFunction)new NumberFunction(145)).Derivative();

        // Assert
        result.Should().BeNull();
    }

    [Theory(DisplayName = "Equals NF and other function works.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(NumberFunctionTestsData.EqualsNFAndOtherFunctionData), MemberType = typeof(NumberFunctionTestsData))]
    public void EqualsNFAndOtherFunctionWork(NumberFunction function, IFunction other, bool expectedValue)
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
        var expectedValue = HashCode.Combine(14d, nameof(NumberFunction));

        // Act
        var result = new NumberFunction(14d).GetHashCode();

        // Assert
        result.Should().Be(expectedValue);
    }

    [Fact(DisplayName = "ToString works.")]
    [Trait("Category", "Methods")]
    public void ToStringWork()
    {
        // Arrange
        var expectedResult = "14";

        // Act
        var result = new NumberFunction(14).ToString();

        // Assert
        result.Should().Be(expectedResult);
    }
    #endregion
}
