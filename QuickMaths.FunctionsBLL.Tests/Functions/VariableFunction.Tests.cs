using System;

using FluentAssertions;

using QuickMaths.FunctionsBLL.Functions;
using QuickMaths.General.Abstractions;

using Xunit;

namespace QuickMaths.FunctionsBLL.Tests.Functions;

public class VariableFunctionTests
{
    public static TheoryData<VariableFunction, IFunction, bool> EqualsVFAndOtherFunctionData
    {
        get
        {
            var data = new TheoryData<VariableFunction, IFunction, bool>();

            data.Add(new VariableFunction("x"), new VariableFunction("x"), true);
            data.Add(new VariableFunction("x", 14.2), new VariableFunction("x", 14.2), true);
            data.Add(new VariableFunction("x", 14d), new VariableFunction("x", 14.2), false);
            data.Add(new VariableFunction("x", 14d), new VariableFunction("x1", 14d), false);
            data.Add(new VariableFunction("x", 14d), new NumberFunction(14d), false);
            data.Add(new VariableFunction("x", 14d), new LinearFunction(new VariableFunction("x1"), new NumberFunction(14d)), false);
            data.Add(new VariableFunction("x1"), new LinearFunction(new VariableFunction("x1")), false);
            data.Add(new VariableFunction("x1", 14d), new LinearFunction(new VariableFunction("x1")), false);

            return data;
        }
    }

    #region Конструкторы

    [Fact(DisplayName = "Can be created.")]
    [Trait("Category", "Constructors")]
    public void CanBeCreated()
    {
        // Arrange
        var name = "x1";
        var value = 24.17;
        VariableFunction func = null!;

        // Act
        var exception = Record.Exception(() => func = new VariableFunction(name, value));

        // Assert
        exception.Should().BeNull();
        func.Name.Should().Be(name);
        func.Value.Should().Be(value);
    }

    [Fact(DisplayName = "Can be created without value.")]
    [Trait("Category", "Constructors")]
    public void CanBeCreatedWithoutValue()
    {
        // Arrange
        var name = "x1";
        VariableFunction func = null!;

        // Act
        var exception = Record.Exception(() => func = new VariableFunction(name));

        // Assert
        exception.Should().BeNull();
        func.Name.Should().Be(name);
        func.Value.Should().Be(null);
    }

    [Theory(DisplayName = "Cannot be created when name is null or empty.")]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(" \r  \n")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenStringIsNullOrEmpty(string name)
    {
        // Act
        var exception = Record.Exception(() => new VariableFunction(name));

        // Assert
        exception.Should().BeOfType<ArgumentException>();
    }
    #endregion

    #region Методы

    [Fact(DisplayName = "Can calulate.")]
    [Trait("Category", "Methods")]
    public void CanCalculate()
    {
        // Arrange
        var expectedValue = 145d;

        // Act
        var result = new VariableFunction("name", 145d).Calculate();

        // Assert
        result.Should().Be(expectedValue);
    }

    [Fact(DisplayName = "Cannot calulate when value is missing.")]
    [Trait("Category", "Methods")]
    public void CanNotCalculate()
    {
        // Act
        var exception = Record.Exception(() => new VariableFunction("name").Calculate());

        // Assert
        exception.Should().BeOfType<InvalidOperationException>();
    }

    [Fact(DisplayName = "Can get derivative.")]
    [Trait("Category", "Methods")]
    public void CanGetDerivative()
    {
        // Act
        var result = new VariableFunction("name").Derivative();

        // Assert
        result.Should().Be(new NumberFunction(1));
    }

    [Theory(DisplayName = "Equals VF and other function works.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(VariableFunctionTestsData.EqualsVFAndOtherFunctionData), MemberType = typeof(VariableFunctionTestsData))]
    public void EqualsVFAndObjectFunctionWork(VariableFunction function, IFunction other, bool expectedValue)
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
        var expectedValue = HashCode.Combine(14d, "name", nameof(VariableFunction));

        // Act
        var result = new VariableFunction("name", 14).GetHashCode();

        // Assert
        result.Should().Be(expectedValue);
    }

    [Fact(DisplayName = "ToString works.")]
    [Trait("Category", "Methods")]
    public void ToStringWork()
    {
        // Arrange
        var expectedResult = "x1";

        // Act
        var result = new VariableFunction("x1").ToString();

        // Assert
        result.Should().Be(expectedResult);
    }
    #endregion
}
