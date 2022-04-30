﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;
using Xunit;
using Xunit.Sdk;
namespace QuickMaths.MatrixBLL.Tests
{
    public class MatrixTest
    {
        public static TheoryData<Matrix> MatrixData
        {
            get
            {
                var data = new TheoryData<Matrix>();
                data.Add(new Matrix(new decimal[,] { { 1, 2, 3 },
                                                     { 1, 2, 3 },
                                                     { 1, 2, 3 } }));

                data.Add(new Matrix(new decimal[,] { { -11,     1,  1 },
                                                     {   1,  2.5m, -5 },
                                                     {   0,  2.1m,  3 } }));

                data.Add(new Matrix(new decimal[,] { { 0, 0, 0 },
                                                     { 0, 0, 0 },
                                                     { 0, 0, 0 } }));

                data.Add(new Matrix(new decimal[,] { { -5,  5,  5 },
                                                     {  5, -5,  5 },
                                                     {  5,  5, -5 } }));

                data.Add(new Matrix(3, 3));
                data.Add(new Matrix(2, 3));
                data.Add(new Matrix(new decimal[,] { { 1, 9 },
                                                     { 4, 7 },
                                                     { 5, 8 } }));

                return data;
            }
        }

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

        [Theory(DisplayName = "Plus operator work.")]
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
    }
}
