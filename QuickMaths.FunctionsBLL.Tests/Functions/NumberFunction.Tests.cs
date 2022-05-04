using System;

using FluentAssertions;
using QuickMaths.FunctionsBLL.Functions;

using Xunit;

namespace QuickMaths.FunctionsBLL.Tests.Functions;

public class NumberFunctionTests
{
    public static TheoryData<NumberFunction, IFunction, bool> EqualsNFAndOtherFunctionData
    {
        get
        {
            var data = new TheoryData<NumberFunction, IFunction, bool>();

            data.Add(new NumberFunction(14), new NumberFunction(14), true);
            data.Add(new NumberFunction(14), new NumberFunction("14"), true);
            data.Add(new NumberFunction(14), new NumberFunction(1), false);
            data.Add(new NumberFunction(14), new NumberFunction("1"), false);
            data.Add(new NumberFunction(14), new Variable("name"), false);
            data.Add(new NumberFunction(14), new LinearFunction(new Variable("name")), false);

            return data;
        }
    }

    public static TheoryData<NumberFunction, object, bool> EqualsNFAndObjectData
    {
        get
        {
            var data = new TheoryData<NumberFunction, object, bool>();

            data.Add(new NumberFunction(14), new NumberFunction(14), true);
            data.Add(new NumberFunction(14), new NumberFunction("14"), true);
            data.Add(new NumberFunction(14), new NumberFunction(1), false);
            data.Add(new NumberFunction(14), new NumberFunction("1"), false);
            data.Add(new NumberFunction(14), new Variable("name"), false);
            data.Add(new NumberFunction(14), new LinearFunction(new Variable("name")), false);
            data.Add(new NumberFunction(14), null!, false);
            data.Add(new NumberFunction(14), "123", false);

            return data;
        }
    }


    #region Конструкторы

    [Fact(DisplayName = "Can be created.")]
    [Trait("Category", "Unit")]
    public void CanBeCreated()
    {
        // Arrange
        var inputNumber = 128;
        var inputString = "1756";

        // Act
        var exeption1 = Record.Exception(() => new NumberFunction(inputNumber));
        var exeption2 = Record.Exception(() => new NumberFunction(inputString));

        // Assert
        exeption1.Should().BeNull();
        exeption2.Should().BeNull();
    }

    [Fact(DisplayName = "Cannot be created when string is null or empty.")]
    [Trait("Category", "Unit")]
    public void CanNotBeCreatedWhenStringIsNullOrEmpty()
    {
        // Arrange
        string emptyString = string.Empty;

        // Act
        var exeption1 = Record.Exception(() => new NumberFunction(emptyString));
        var exeption2 = Record.Exception(() => new NumberFunction(null!));

        // Assert
        exeption1.Should().NotBeNull().And.BeOfType<ArgumentException>();
        exeption2.Should().NotBeNull().And.BeOfType<ArgumentException>();
    }

    [Fact(DisplayName = "Cannot be created when string be in invalid format.")]
    [Trait("Category", "Unit")]
    public void CanNotBeCreatedWhenFormatStringIsInvalid()
    {
        // Arrange
        var invalidString = "sda 144 f";

        // Act
        var exeption = Record.Exception(() => new NumberFunction(invalidString));

        // Assert
        exeption.Should().NotBeNull().And.BeOfType<FormatException>();
    }
    #endregion

    #region Свойства

    [Fact(DisplayName = "Can get value.")]
    [Trait("Category", "Unit")]
    public void CanGetValue()
    {
        // Arrange
        var expectedValue = 144;

        // Act
        double result1 = new NumberFunction(144).Value;
        double result2 = new NumberFunction("144").Value;

        // Assert
        result1.Should().Be(expectedValue);
        result2.Should().Be(expectedValue);
    }
    #endregion

    #region Методы

    [Fact(DisplayName = "Can calulate.")]
    [Trait("Category", "Unit")]
    public void CanCalculate()
    {
        // Arrange
        var expectedValue = 145;

        // Act
        var result = new NumberFunction(145).Calculate();

        // Assert
        result.Should().Be(expectedValue);
    }

    [Fact(DisplayName = "Cannot get derivative.")]
    [Trait("Category", "Unit")]
    public void CanNotCalculate()
    {
        // Act
        IFunction result = ((IFunction)new NumberFunction(145)).Derivative();

        // Assert
        result.Should().BeNull();
    }

    [Theory(DisplayName = "Equals NF and other function works.")]
    [Trait("Category", "Unit")]
    [MemberData(nameof(EqualsNFAndOtherFunctionData), MemberType = typeof(NumberFunctionTests))]
    public void EqualsNFAndOtherFunctionWork(NumberFunction function, IFunction other, bool expectedValue)
    {
        // Act
        bool result = function.Equals(other);

        // Assert
        result.Should().Be(expectedValue);
    }

    [Theory(DisplayName = "Equals NF and object works.")]
    [Trait("Category", "Unit")]
    [MemberData(nameof(EqualsNFAndObjectData), MemberType = typeof(NumberFunctionTests))]
    public void EqualsNFAndObjectFunctionWork(NumberFunction function, object other, bool expectedValue)
    {
        // Act
        bool result = function.Equals(other);

        // Assert
        result.Should().Be(expectedValue);
    }

    [Fact(DisplayName = "GetHashCode works.")]
    [Trait("Category", "Unit")]
    public void GetHashCodeWork()
    {
        // Arrange
        var expectedValue = HashCode.Combine(14d, nameof(NumberFunction));

        // Act
        var result = new NumberFunction(14).GetHashCode();

        // Assert
        result.Should().Be(expectedValue);
    }

    [Fact(DisplayName = "ToString works.")]
    [Trait("Category", "Unit")]
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

    #region Математические операторы

    #endregion
}
