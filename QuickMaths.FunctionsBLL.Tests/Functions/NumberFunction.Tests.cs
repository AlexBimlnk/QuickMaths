using System;

using FluentAssertions;
using Xunit;

using QuickMaths.FunctionsBLL.Functions;

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
            data.Add(new NumberFunction(14), new VariableFunction("name"), false);
            data.Add(new NumberFunction(14), new LinearFunction(new VariableFunction("name")), false);

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
            data.Add(new NumberFunction(14), new VariableFunction("name"), false);
            data.Add(new NumberFunction(14), new LinearFunction(new VariableFunction("name")), false);
            data.Add(new NumberFunction(14), null!, false);
            data.Add(new NumberFunction(14), "123", false);

            return data;
        }
    }


    #region Конструкторы

    [Fact(DisplayName = "Can be created.")]
    [Trait("Category", "Constructors")]
    public void CanBeCreated()
    {
        // Arrange
        var inputNumber = 128d;
        var inputString = "1756";

        // Act
        var exception1 = Record.Exception(() => new NumberFunction(inputNumber));
        var exception2 = Record.Exception(() => new NumberFunction(inputString));

        // Assert
        exception1.Should().BeNull();
        exception2.Should().BeNull();
    }

    [Fact(DisplayName = "Cannot be created when string is null or empty.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenStringIsNullOrEmpty()
    {
        // Act
        var exception1 = Record.Exception(() => new NumberFunction(string.Empty));
        var exception2 = Record.Exception(() => new NumberFunction(null!));

        // Assert
        exception1.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
        exception2.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
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

    #region Свойства

    [Fact(DisplayName = "Can get value.")]
    [Trait("Category", "Properties")]
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
    [Trait("Category", "Methods")]
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
    [Trait("Category", "Methods")]
    public void CanNotGetDerivative()
    {
        // Act
        IFunction result = ((IFunction)new NumberFunction(145)).Derivative();

        // Assert
        result.Should().BeNull();
    }

    [Theory(DisplayName = "Equals NF and object works.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(EqualsNFAndObjectData), MemberType = typeof(NumberFunctionTests))]
    public void EqualsNFAndObjectFunctionWork(NumberFunction function, object other, bool expectedValue)
    {
        // Act
        bool result = function.Equals(other);

        // Assert
        result.Should().Be(expectedValue);
    }

    [Theory(DisplayName = "Equals NF and other function works.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(EqualsNFAndOtherFunctionData), MemberType = typeof(NumberFunctionTests))]
    public void EqualsNFAndOtherFunctionWork(NumberFunction function, IFunction other, bool expectedValue)
    {
        // Act
        bool result = function.Equals(other);

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
        var result = new NumberFunction(14).GetHashCode();

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
