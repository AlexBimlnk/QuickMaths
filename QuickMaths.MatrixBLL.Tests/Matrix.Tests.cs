using System;

using FluentAssertions;
using Xunit;

namespace QuickMaths.MatrixBLL.Tests;

public class MatrixTests
{
    #region Конструкторы

    [Fact(DisplayName = "Can be created.")]
    [Trait("Category", "Constructors")]
    public void CanBeCreated()
    {
        // Arrange
        var size = 3;
        var table = new decimal[3, 3];

        // Act
        var exception1 = Record.Exception(() => new Matrix(size, size));
        var exception2 = Record.Exception(() => new Matrix(table));

        // Assert
        exception1.Should().BeNull();
        exception2.Should().BeNull();
    }

    [Fact(DisplayName = "Cannot be created when size is incorrect.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenSizeIsIncorrect()
    {
        // Arrange
        var correctSize = 3;
        var incorrectSize = -3;

        // Act
        var exception1 = Record.Exception(() => new Matrix(correctSize, incorrectSize));
        var exception2 = Record.Exception(() => new Matrix(incorrectSize, correctSize));
        var exception3 = Record.Exception(() => new Matrix(incorrectSize, incorrectSize));

        // Assert
        exception1.Should().NotBeNull().And.BeOfType<ArgumentException>();
        exception2.Should().NotBeNull().And.BeOfType<ArgumentException>();
        exception3.Should().NotBeNull().And.BeOfType<ArgumentException>();
    }

    [Fact(DisplayName = "Cannot be created when table is missing.")]
    [Trait("Category", "Constructors")]
    public void CanNotBeCreatedWhenTableIsMissing()
    {
        // Act
        var exception1 = Record.Exception(() => new Matrix(null!));

        // Assert
        exception1.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
    }
    #endregion

    #region Свойства

    [Fact(DisplayName = "Can get rows count.")]
    [Trait("Category", "Properties")]
    public void CanGetRowsCount()
    {
        // Arrange
        var rows = 3;
        var columns = 1;
        var matrix = new Matrix(rows, columns);

        // Act
        var result = matrix.RowsCount;

        // Assert
        result.Should().Be(rows);
    }

    [Fact(DisplayName = "Can get columns count.")]
    [Trait("Category", "Properties")]
    public void CanGetColumnsCount()
    {
        // Arrange
        var rows = 3;
        var columns = 1;
        var matrix = new Matrix(rows, columns);

        // Act
        var result = matrix.ColumnsCount;

        // Assert
        result.Should().Be(columns);
    }
    #endregion

    #region Методы

    [Theory(DisplayName = "Can get row as matrix if index is valid.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(MatrixTestsData.GetRowFromMatrixData), MemberType = typeof(MatrixTestsData))]
    public void CanGetRowAsMatrix(Matrix matrix, long index, Matrix expectedMatrix)
    {
        // Arrange
        var func = (Matrix m1, long index) => m1.GetRow(index);

        // Act
        try
        {
            Matrix result = func(matrix, index);

            // Assert
            result.Should().BeEquivalentTo(expectedMatrix);
        }
        catch
        {
            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => func(matrix, index));
        }
    }

    [Theory(DisplayName = "Can get column as matrix if index is valid.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(MatrixTestsData.GetColumnFromMatrixData), MemberType = typeof(MatrixTestsData))]
    public void CanGetColumnAsMatrix(Matrix matrix, long index, Matrix expectedMatrix)
    {
        // Arrange
        var func = (Matrix m1, long index) => m1.GetColumn(index);

        // Act
        try
        {
            Matrix result = func(matrix, index);

            // Assert
            result.Should().BeEquivalentTo(expectedMatrix);
        }
        catch
        {
            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => func(matrix, index));
        }
    }

    [Theory(DisplayName = "Equals matrix and object works.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(MatrixTestsData.EqualsMatrixAndObjectData), MemberType = typeof(MatrixTestsData))]
    public void EqualsMatrixAndObjectWork(Matrix firstMatrix, object other, bool expectedResult)
    {
        // Act
        bool result = firstMatrix.Equals(other);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Theory(DisplayName = "Equals two matrixs works.")]
    [Trait("Category", "Methods")]
    [MemberData(nameof(MatrixTestsData.EqualsTwoMatrixData), MemberType = typeof(MatrixTestsData))]
    public void EqualsTwoMatrixWork(Matrix firstMatrix, Matrix other, bool expectedResult)
    {
        // Act
        bool result = firstMatrix.Equals(other);

        // Assert
        result.Should().Be(expectedResult);
    }
    #endregion

    #region Математические операторы

    [Theory(DisplayName = "Plus operator works.")]
    [Trait("Category", "Operators")]
    [MemberData(nameof(MatrixTestsData.SumTwoMatrixData), MemberType = typeof(MatrixTestsData))]
    public void PlusOperatorWork(Matrix firstMatrix, Matrix otherMatrix, Matrix expectedMatrix)
    {
        // Arrange
        var func = (Matrix m1, Matrix m2) => m1 + m2;
        var result = new Matrix(1, 1);

        // Act
        try
        {
            result = func(firstMatrix, otherMatrix);

            // Assert
            result.Should().BeEquivalentTo(expectedMatrix);
        }
        catch
        {
            // Assert
            Assert.Throws<ArithmeticException>(() => func(firstMatrix, otherMatrix));
        }
    }

    [Theory(DisplayName = "Substraction operator works.")]
    [Trait("Category", "Operators")]
    [MemberData(nameof(MatrixTestsData.SubstractionTwoMatrixData), MemberType = typeof(MatrixTestsData))]
    public void SubstractionOperatorWork(Matrix firstMatrix, Matrix otherMatrix, Matrix expectedMatrix)
    {
        // Arrange
        var func = (Matrix m1, Matrix m2) => m1 - m2;
        var result = new Matrix(1, 1);

        // Act
        try
        {
            result = func(firstMatrix, otherMatrix);

            // Assert
            result.Should().BeEquivalentTo(expectedMatrix);
        }
        catch
        {
            // Assert
            Assert.Throws<ArithmeticException>(() => func(firstMatrix, otherMatrix));
        }
    }

    [Theory(DisplayName = "Multiply operator with matrix and number works.")]
    [Trait("Category", "Operators")]
    [MemberData(nameof(MatrixTestsData.MultiplyMatrixAndNumberData), MemberType = typeof(MatrixTestsData))]
    public void MultiplyOperatorWithMatrixAndNumberWork(Matrix firstMatrix, decimal koef, Matrix expectedMatrix)
    {
        // Act
        var result = firstMatrix * koef;
        var resultAlternative = koef * firstMatrix;

        // Assert
        result.Should().BeEquivalentTo(expectedMatrix);
        resultAlternative.Should().BeEquivalentTo(expectedMatrix);
    }

    [Theory(DisplayName = "Multiply operator works.")]
    [Trait("Category", "Operators")]
    [MemberData(nameof(MatrixTestsData.MultiplyTwoMatrixData), MemberType = typeof(MatrixTestsData))]
    public void MultiplyOperatorWithTwoMatrixWork(Matrix firstMatrix, Matrix otherMatrix, Matrix expectedMatrix)
    {
        // Arrange
        var func = (Matrix m1, Matrix m2) => m1 * m2;
        var result = new Matrix(1, 1);

        // Act
        try
        {
            result = func(firstMatrix, otherMatrix);

            // Assert
            result.Should().BeEquivalentTo(expectedMatrix);
        }
        catch
        {
            // Assert
            Assert.Throws<ArithmeticException>(() => func(firstMatrix, otherMatrix));
        }
    }
    #endregion
}
