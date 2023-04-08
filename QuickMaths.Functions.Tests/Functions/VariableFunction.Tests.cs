using System;

using FluentAssertions;
using Xunit;

using QuickMaths.Functions.Functions;
using QuickMaths.General.Abstractions;

namespace QuickMaths.Functions.Tests.Functions;

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

    public static TheoryData<VariableFunction, object, bool> EqualsVFAndObjectData
    {
        get
        {
            var data = new TheoryData<VariableFunction, object, bool>();

            data.Add(new VariableFunction("x"), new VariableFunction("x"), true);
            data.Add(new VariableFunction("x", 14.2), new VariableFunction("x", 14.2), true);
            data.Add(new VariableFunction("x", 14d), new VariableFunction("x", 14.2), false);
            data.Add(new VariableFunction("x", 14d), new VariableFunction("x1", 14d), false);
            data.Add(new VariableFunction("x", 14d), new NumberFunction(14d), false);
            data.Add(new VariableFunction("x", 14d), new LinearFunction(new VariableFunction("x1"), new NumberFunction(14d)), false);
            data.Add(new VariableFunction("x1"), new LinearFunction(new VariableFunction("x1")), false);
            data.Add(new VariableFunction("x1", 14d), new LinearFunction(new VariableFunction("x1")), false);
            data.Add(new VariableFunction("x"), null!, false);
            data.Add(new VariableFunction("x"), "123", false);

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

        // Act
        var exception1 = Record.Exception(() => new VariableFunction(name));
        var exception2 = Record.Exception(() => new VariableFunction(name, value));

        // Assert
        exception1.Should().BeNull();
        exception2.Should().BeNull();
    }

    [Fact(DisplayName = "Cannot be created when name is null or empty.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenStringIsNullOrEmpty()
    {
        // Arrange
        var value = 14.17;

        // Act
        var exception1 = Record.Exception(() => new VariableFunction(string.Empty));
        var exception2 = Record.Exception(() => new VariableFunction(null!));
        var exception3 = Record.Exception(() => new VariableFunction(string.Empty, value));
        var exception4 = Record.Exception(() => new VariableFunction(null!, value));

        // Assert
        new Exception[] { exception1, exception2, exception3, exception4 }.Should().AllBeOfType<ArgumentNullException>();
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
        double? result = new VariableFunction("name", 144).Value;

        // Assert
        result.Should().Be(expectedValue);
    }

    [Fact(DisplayName = "Value propertie return null when value is missing.")]
    [Trait("Category", "Properties")]
    public void ValueReturnNullWhenValueIsMissing()
    {
        // Act
        double? result = new VariableFunction("name").Value;

        // Assert
        result.Should().BeNull();
    }

    [Fact(DisplayName = "Can get name.")]
    [Trait("Category", "Properties")]
    public void CanGetName()
    {
        // Arrange
        var expectedValue = "x3";

        // Act
        string result = new VariableFunction("x3").Name;

        // Assert
        result.Should().Be(expectedValue);
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
        IFunction result = new VariableFunction("name").Derivative();

        // Assert
        result.Should().Be(new NumberFunction(1));
    }

    [Theory(DisplayName = "Equals VF and object works.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(EqualsVFAndObjectData), MemberType = typeof(VariableFunctionTests))]
    public void EqualsVFAndObjectFunctionWork(VariableFunction function, object other, bool expectedValue)
    {
        // Act
        bool result = function.Equals(other);

        // Assert
        result.Should().Be(expectedValue);
    }

    [Theory(DisplayName = "Equals VF and other function works.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(EqualsVFAndOtherFunctionData), MemberType = typeof(VariableFunctionTests))]
    public void EqualsVFAndOtherFunctionWork(VariableFunction function, IFunction other, bool expectedValue)
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
