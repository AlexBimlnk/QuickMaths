using System;

using Xunit;
using FluentAssertions;

using QuickMaths.General.Abstractions;
using QuickMaths.FunctionsBLL.Functions;

namespace QuickMaths.FunctionsBLL.Parser.Tests;

public class FunctionParserTests
{
    #region Методы

    [Fact(DisplayName = "Can parse correct string.")]
    [Trait("Category", "Methods")]
    public void CanParse()
    {
        //Todo: Это должна быть теория, а не факт TheoryData<>
        //тесты на парсинг, примеры в NF, VF.
        // Arrange
        string inputString = "4";
        IFunction expectedFunc = new NumberFunction(4); 
        var parser = new FunctionParser();
        
        // Act
        var result = parser.Parse(inputString);

        // Assert
        result.Should().BeEquivalentTo(expectedFunc);
    }

    [Fact(DisplayName = "Can't parse when input string is invalid.")]
    [Trait("Category", "Methods")]
    public void CanNotParseWhenInputStringIsInvalid()
    {
        // Arrange
        string invalidFormatString = "(((@";
        var parser = new FunctionParser();

        // Act
        var formatException = Record.Exception(() => parser.Parse(invalidFormatString));
        var argumentNullException1 = Record.Exception(() => parser.Parse(null!));
        var argumentNullException2 = Record.Exception(() => parser.Parse(""));

        // Assert
        formatException.Should().BeOfType<FormatException>();
        argumentNullException1.Should().BeOfType<ArgumentNullException>();
        argumentNullException2.Should().BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "TryParse be works.")]
    [Trait("Category", "Methods")]
    public void TryParseWorks()
    {
        //Todo: тоже создать терорию
        // Arrange
        var inputString = "5";
        var expectedResult = true;
        var expectedFunc = new NumberFunction(5);
        var parser = new FunctionParser();

        // Act
        var result = parser.TryParse(inputString, out IFunction function);

        // Assert
        result.Should().Be(expectedResult);
        function.Should().BeEquivalentTo(expectedFunc);
    }
    #endregion
}
