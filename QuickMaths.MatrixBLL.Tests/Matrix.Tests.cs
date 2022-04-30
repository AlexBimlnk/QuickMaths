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
    }
}
