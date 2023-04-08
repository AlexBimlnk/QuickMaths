using System;

using Xunit;
using FluentAssertions;

using QuickMaths.General.Abstractions;

namespace QuickMaths.Matrix.Parser.Tests;

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
        IArithmeticable expectedMatrix = new Matrix(3,3);
        var parser = new MatrixParser();

        // Act
        var result = parser.Parse(inputString);

        // Assert
        result.Should().BeEquivalentTo(expectedMatrix);
    }

    [Fact(DisplayName = "Can't parse when input string is invalid.")]
    [Trait("Category", "Methods")]
    public void CanNotParseWhenInputStringIsInvalid()
    {
        // Arrange
        string invalidFormatString = "(((@";
        var parser = new MatrixParser();

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
        var inputString = "a[(1,2,3)(1,2,3)(1,2,3)]";
        var expectedResult = true;
        var expectedMatrix = new Matrix(3,3);
        var parser = new MatrixParser();

        // Act
        var result = parser.TryParse(inputString, out Matrix matrix);

        // Assert
        result.Should().Be(expectedResult);
        matrix.Should().BeEquivalentTo(expectedMatrix);
    }
    #endregion
}
