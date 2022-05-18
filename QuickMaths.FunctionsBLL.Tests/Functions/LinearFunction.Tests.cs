using System;

using FluentAssertions;
using Xunit;

using QuickMaths.FunctionsBLL.Functions;
using QuickMaths.General.Abstractions;

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

        // Act
        var exception1 = Record.Exception(() => new LinearFunction(argument));
        var exception2 = Record.Exception(() => new LinearFunction(argument, koef));

        // Assert
        exception1.Should().BeNull();
        exception2.Should().BeNull();
    }

    [Fact(DisplayName = "Cannot be created when arguments is null.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenArgumentsIsNull()
    {
        // Act
        var exception1 = Record.Exception(() => new LinearFunction(null!));
        var exception2 = Record.Exception(() => new LinearFunction(new VariableFunction("x"), null!));
        var exception3 = Record.Exception(() => new LinearFunction(null!, null!));

        // Assert
        new Exception[] { exception1, exception2, exception3 }.Should().AllBeOfType<ArgumentNullException>();
    }
    #endregion

    #region Свойства

    [Theory(DisplayName = "Can get koef as function.")]
    [Trait("Category", "Properties")]
    [MemberData(nameof(LinearFunctionTestsData.GetKoefData), MemberType = typeof(LinearFunctionTestsData))]
    public void CanGetKoef(LinearFunction linear, IFunction expectedFunction)
    {
        // Act
        IFunction result = linear.Koef;

        // Assert
        result.Should().BeEquivalentTo(expectedFunction);
    }

    [Theory(DisplayName = "Can get argument as function.")]
    [Trait("Category", "Properties")]
    [MemberData(nameof(LinearFunctionTestsData.GetArgumentData), MemberType = typeof(LinearFunctionTestsData))]

    public void CanGetArgument(LinearFunction linear, IFunction expectedFunction)
    {
        // Act
        IFunction result = linear.Argument;

        // Assert
        result.Should().BeEquivalentTo(expectedFunction);
    }
    #endregion

    #region Методы

    [Fact(DisplayName = "Can calulate.")]
    [Trait("Category", "Methods")]
    public void CanCalculate()
    {
        // Arrange
        

        // Act
        

        // Assert
        
    }

    [Fact(DisplayName = "Cannot calulate when value in argument or koef is missing.")]
    [Trait("Category", "Methods")]
    public void CanNotCalculate()
    {
        // Act

        // Assert
        
    }

    [Fact(DisplayName = "Can get derivative.")]
    [Trait("Category", "Methods")]
    public void CanGetDerivative()
    {
        // Act
        

        // Assert
        
    }

    [Theory(DisplayName = "Equals LF and object works.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(LinearFunctionTestsData.EqualsLFAndObjectData), MemberType = typeof(LinearFunctionTestsData))]
    public void EqualsLFAndObjectFunctionWork(LinearFunction function, object other, bool expectedValue)
    {
        // Act
        bool result = function.Equals(other);

        // Assert
        result.Should().Be(expectedValue);
    }

    [Theory(DisplayName = "Equals LF and other function works.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(LinearFunctionTestsData.EqualsLFAndOtherFunctionData), MemberType = typeof(LinearFunctionTestsData))]
    public void EqualsLFAndOtherFunctionWork(LinearFunction function, IFunction other, bool expectedValue)
    {
        // Act
        bool result = function.Equals(other);

        // Assert
        result.Should().Be(expectedValue);
    }

    [Theory(DisplayName = "GetHashCode works.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(LinearFunctionTestsData.GetHashCodeData), MemberType = typeof(LinearFunctionTestsData))]
    public void GetHashCodeWork(LinearFunction linear, int expectedResult)
    {
        // Act
        var result = linear.GetHashCode();

        // Assert
        result.Should().Be(expectedResult);
    }

    [Theory(DisplayName = "ToString works.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(LinearFunctionTestsData.ToStringData), MemberType = typeof(LinearFunctionTestsData))]
    public void ToStringWork(LinearFunction linear, string expectedString)
    {
        // Act
        var result = linear.ToString();

        // Assert
        result.Should().Be(expectedString);
    }
    #endregion
}
