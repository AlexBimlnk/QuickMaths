using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;
using Xunit;

namespace QuickMaths.MatrixBLL.Tests
{
    public class MatrixTest
    {
        #region Конструкторы

        [Fact(DisplayName = "Can be created.")]
        [Trait("Category", "Unit")]
        public void CanBeCreated()
        {
            //arrange
            var size = 3;
            var table = new decimal[3, 3];

            //act
            var exeption1 = Record.Exception(() => new Matrix(size, size));
            var exeption2 = Record.Exception(() => new Matrix(table));

            //assert
            exeption1.Should().BeNull();
            exeption2.Should().BeNull();
        }

        [Fact(DisplayName = "Cannot be created when size is incorrect.")]
        [Trait("Category", "Unit")]
        public void CanNotBeCreatedWhenSizeIsIncorrect()
        {
            //arrange
            var correctSize = 3;
            var incorrectSize = -3;

            //act
            var exeption1 = Record.Exception(() => new Matrix(correctSize, incorrectSize));
            var exeption2 = Record.Exception(() => new Matrix(incorrectSize, correctSize));
            var exeption3 = Record.Exception(() => new Matrix(incorrectSize, incorrectSize));

            //assert
            exeption1.Should().NotBeNull().And.BeOfType<ArgumentException>();
            exeption2.Should().NotBeNull().And.BeOfType<ArgumentException>();
            exeption3.Should().NotBeNull().And.BeOfType<ArgumentException>();
        }

        [Fact(DisplayName = "Cannot be created when table is missing.")]
        [Trait("Category", "Unit")]
        public void CanNotBeCreatedWhenTableIsMissing()
        {
            //act
            var exeption1 = Record.Exception(() => new Matrix(null!));

            //assert
            exeption1.Should().NotBeNull().And.BeOfType<ArgumentNullException>();
        }
        #endregion

        #region Свойства

        [Fact(DisplayName = "Can get row count.")]
        [Trait("Category", "Unit")]
        public void CanGetRowsCount()
        {
            //arrange
            var rows = 3;
            var columns = 1;
            var matrix = new Matrix(rows, columns);

            //act
            var result = matrix.RowsCount;

            //assert
            result.Should().Be(rows);
        }

        [Fact(DisplayName = "Can get column count.")]
        [Trait("Category", "Unit")]
        public void CanGetColumnsCount()
        {
            //arrange
            var rows = 3;
            var columns = 1;
            var matrix = new Matrix(rows, columns);

            //act
            var result = matrix.ColumnsCount;

            //assert
            result.Should().Be(columns);
        }
        #endregion

        #region Методы

        [Theory(DisplayName = "Can get row as matrix if index is valid.")]
        [Trait("Category", "Unit")]
        [MemberData(nameof(MatrixTestData.GetRowFromMatrixData), MemberType = typeof(MatrixTestData))]
        public void CanGetRowAsMatrix(Matrix matrix, long index, Matrix expectedMatrix)
        {
            //arrange
            var func = (Matrix m1, long index) => m1.GetRow(index);

            //act
            try
            {
                var result = func(matrix, index);

                //assert
                result.Should().BeEquivalentTo(expectedMatrix);
            }
            catch
            {
                //assert
                Assert.Throws<IndexOutOfRangeException>(() => func(matrix, index));
            }
        }

        [Theory(DisplayName = "Can get column as matrix if index is valid.")]
        [Trait("Category", "Unit")]
        [MemberData(nameof(MatrixTestData.GetColumnFromMatrixData), MemberType = typeof(MatrixTestData))]
        public void CanGetColumnAsMatrix(Matrix matrix, long index, Matrix expectedMatrix)
        {
            //arrange
            var func = (Matrix m1, long index) => m1.GetColumn(index);

            //act
            try
            {
                var result = func(matrix, index);

                //assert
                result.Should().BeEquivalentTo(expectedMatrix);
            }
            catch
            {
                //assert
                Assert.Throws<IndexOutOfRangeException>(() => func(matrix, index));
            }
        }

        [Theory(DisplayName = "Equals two matrix works.")]
        [Trait("Category", "Unit")]
        [MemberData(nameof(MatrixTestData.EqualsTwoMatrixData), MemberType = typeof(MatrixTestData))]
        public void EqualsTwoMatrixWork(Matrix firstMatrix, Matrix other, bool expectedResult)
        {
            //act
            var result = firstMatrix.Equals(other);

            //assert
            result.Should().Be(expectedResult);
        }

        [Theory(DisplayName = "Equals matrix and object works.")]
        [Trait("Category", "Unit")]
        [MemberData(nameof(MatrixTestData.EqualsMatrixAndObjectData), MemberType = typeof(MatrixTestData))]
        public void EqualsMatrixAndObjectWork(Matrix firstMatrix, object other, bool expectedResult)
        {
            //act
            var result = firstMatrix.Equals(other);

            //assert
            result.Should().Be(expectedResult);
        }
        #endregion

        #region Математические операторы

        [Theory(DisplayName = "Plus operator works.")]
        [Trait("Category", "Unit")]
        [MemberData(nameof(MatrixTestData.SumTwoMatrixData), MemberType = typeof(MatrixTestData))]
        public void PlusOperatorWork(Matrix firstMatrix, Matrix otherMatrix, Matrix expectedMatrix)
        {
            //arrange
            var func = (Matrix m1, Matrix m2) => m1 + m2;
            Matrix result = new Matrix(1, 1);

            //act
            try
            {
                result = func(firstMatrix, otherMatrix);

                //assert
                result.Should().BeEquivalentTo(expectedMatrix);
            }
            catch
            {
                //assert
                Assert.Throws<ArithmeticException>(() => func(firstMatrix, otherMatrix));
            }
        }

        [Theory(DisplayName = "Substraction operator works.")]
        [Trait("Category", "Unit")]
        [MemberData(nameof(MatrixTestData.SubstractionTwoMatrixData), MemberType = typeof(MatrixTestData))]
        public void SubstractionOperatorWork(Matrix firstMatrix, Matrix otherMatrix, Matrix expectedMatrix)
        {
            //arrange
            var func = (Matrix m1, Matrix m2) => m1 - m2;
            Matrix result = new Matrix(1, 1);

            //act
            try
            {
                result = func(firstMatrix, otherMatrix);

                //assert
                result.Should().BeEquivalentTo(expectedMatrix);
            }
            catch
            {
                //assert
                Assert.Throws<ArithmeticException>(() => func(firstMatrix, otherMatrix));
            }
        }

        [Theory(DisplayName = "Multiply operator with matrix and number works.")]
        [Trait("Category", "Unit")]
        [MemberData(nameof(MatrixTestData.MultiplyMatrixAndNumberData), MemberType = typeof(MatrixTestData))]
        public void MultiplyOperatorWithMatrixAndNumberWork(Matrix firstMatrix, decimal koef, Matrix expectedMatrix)
        {
            //act
            var result = firstMatrix * koef;
            var resultAlternative = koef * firstMatrix;

            //assert
            result.Should().BeEquivalentTo(expectedMatrix);
            resultAlternative.Should().BeEquivalentTo(expectedMatrix);
        }

        [Theory(DisplayName = "Multiply operator works.")]
        [Trait("Category", "Unit")]
        [MemberData(nameof(MatrixTestData.MultiplyTwoMatrixData), MemberType = typeof(MatrixTestData))]
        public void MultiplyOperatorWithTwoMatrixWork(Matrix firstMatrix, Matrix otherMatrix, Matrix expectedMatrix)
        {
            //arrange
            var func = (Matrix m1, Matrix m2) => m1 * m2;
            Matrix result = new Matrix(1, 1);

            //act
            try
            {
                result = func(firstMatrix, otherMatrix);

                //assert
                result.Should().BeEquivalentTo(expectedMatrix);
            }
            catch
            {
                //assert
                Assert.Throws<ArithmeticException>(() => func(firstMatrix, otherMatrix));
            }
        }
        #endregion
    }
}
