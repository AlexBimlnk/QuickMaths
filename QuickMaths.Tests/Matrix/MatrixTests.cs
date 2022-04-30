using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuickMaths.MatrixBLL.Tests
{
    public class MatrixTests
    {
        private static Matrix _data = new Matrix(new decimal[,] { { 1, 2, 3 },
                                                                 { 1, 2, 3 },
                                                                 { 1, 2, 3 } });

        private static Matrix _data1 = new Matrix(new decimal[,] { { 1, 2, 3 },
                                                                  { 1, 2, 3 },
                                                                  { 1, 2, 3 } });

        private static Matrix _data2 = new Matrix(new decimal[,] { { 0, 0, 0 },
                                                                  { 0, 0, 0 },
                                                                  { 0, 0, 0 } });

        private static Matrix _data3 = new Matrix(new decimal[,] { { 5, 5, 5 },
                                                                  { 5, 5, 5 },
                                                                  { 5, 5, 5 } });
        private static Matrix _data4 = new Matrix(3, 3);
        private static Matrix _data5 = new Matrix(2, 3);
        private static Matrix _data6 = new Matrix(new decimal[,] { { 1, 9 },
                                                                  { 4, 7 },
                                                                  { 5, 8 } });



        private static void MatrixEquals(Matrix first, Matrix second)
        {
            if (first.RowCount != second.RowCount || first.ColumnCount != second.ColumnCount)
            {
                Assert.False(true);
                return;
            }
            for (int i = 0; i < first.RowCount; i++)
            {
                for (int j = 0; j < first.ColumnCount; j++)
                {
                    Assert.Equal(first[i, j], second[i, j]);
                }
            }
        }


        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(-1, 1)]
        public void CreateMatrix_LongArguments_ThrowIfInvalid(long rows, long columns)
        {
            Action action = () => new Matrix(rows, columns);

            try
            {
                action();
            }
            catch
            {
                Assert.Throws<ArgumentException>(action);
            }
        }
        [Fact]
        public void CreateMatrix_DoubleArray_ThrowIfNull()
        {
            decimal[,] nullArray = null;
            var matrix1 = new Matrix(_data.Table);

            Assert.Throws<ArgumentNullException>(() => new Matrix(nullArray));
            Assert.True(true);
        }

        #region Арифметические операции

        [Fact]
        public void SummMatrix_TwoMatrix_ReturnMatrixOfSumm()
        {
            const int TEST_COUNT = 4;


            Matrix result1 = new Matrix(new decimal[,] { { 2, 4, 6 }, { 2, 4, 6 }, { 2, 4, 6 } });
            Matrix result2 = new Matrix(_data.Table);
            Matrix result3 = new Matrix(new decimal[,] { { 6, 7, 8 }, { 6, 7, 8 }, { 6, 7, 8 } });
            Matrix result4 = new Matrix(_data.Table);
            Matrix nullMatrix = null;


            Matrix output1 = _data + _data1;
            Matrix output2 = _data + _data2;
            Matrix output3 = _data + _data3;
            Matrix output4 = _data + _data4;
            Assert.Throws<ArithmeticException>(() => _data + _data5);
            Assert.Throws<ArithmeticException>(() => _data + _data6);
            Assert.Throws<ArgumentNullException>(() => _data + nullMatrix);


            Matrix[,] listTest = new Matrix[,]{ { result1, result2, result3, result4},
                                                { output1, output2, output3, output4}};


            for (int i = 0; i < TEST_COUNT; i++)
            {
                MatrixEquals(listTest[0, i], listTest[1, i]);
            }
        }

        [Fact]
        public void SubtractionMatrix_TwoMatrix_ReturnMatrixOfSubtraction()
        {
            const int TEST_COUNT = 4;


            Matrix result1 = new Matrix(3, 3);
            Matrix result2 = new Matrix(_data.Table);
            Matrix result3 = new Matrix(new decimal[,] { { -4, -3, -2 }, { -4, -3, -2 }, { -4, -3, -2 } });
            Matrix result4 = new Matrix(_data.Table);
            Matrix nullMatrix = null;


            Matrix output1 = _data - _data1;
            Matrix output2 = _data - _data2;
            Matrix output3 = _data - _data3;
            Matrix output4 = _data - _data4;
            Assert.Throws<ArithmeticException>(() => _data - _data5);
            Assert.Throws<ArithmeticException>(() => _data - _data6);
            Assert.Throws<ArgumentNullException>(() => _data - nullMatrix);


            Matrix[,] listTest = new Matrix[,]{ { result1, result2, result3, result4},
                                                { output1, output2, output3, output4}};


            for (int i = 0; i < TEST_COUNT; i++)
            {
                MatrixEquals(listTest[0, i], listTest[1, i]);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(-5)]
        [InlineData(5)]
        [InlineData(-1.2)]
        [InlineData(1.2)]
        public void MultiplyMatrix_MatrixAndNumber_ReturnMatrixOfMultiply(decimal k)
        {

            Matrix matrix = null;
            Matrix result = _data * k;

            for (int i = 0; i < _data.RowCount; i++)
            {
                for (int j = 0; j < _data.ColumnCount; j++)
                {
                    Assert.Equal(result[i, j], _data[i, j] * k);
                }
            }
            Assert.Throws<ArgumentNullException>(() => matrix * k);
        }

        [Fact]
        public void MultiplyMatrix_TwoMatrix_ReturnMatrixOfMultiply()
        {
            const int TEST_COUNT = 5;

            Matrix nullMatrix = null;
            Matrix result1 = new Matrix(new decimal[,] { { 6, 12, 18 }, { 6, 12, 18 }, { 6, 12, 18 } });
            Matrix result2 = new Matrix(3, 3);
            Matrix result3 = new Matrix(new decimal[,] { { 30, 30, 30 }, { 30, 30, 30 }, { 30, 30, 30 } });
            Matrix result4 = new Matrix(3, 3);
            Matrix result6 = new Matrix(new decimal[,] { { 24, 47 },
                                                        { 24, 47 },
                                                        { 24, 47 } });


            Matrix output1 = _data * _data1;
            Matrix output2 = _data * _data2;
            Matrix output3 = _data * _data3;
            Matrix output4 = _data * _data4;
            Matrix output6 = _data * _data6;
            Assert.Throws<ArithmeticException>(() => _data * _data5);
            Assert.Throws<ArgumentNullException>(() => _data - nullMatrix);


            Matrix[,] listTest = new Matrix[,]{ { result1, result2, result3, result4, result6},
                                                { output1, output2, output3, output4, output6}};


            for (int i = 0; i < TEST_COUNT; i++)
            {
                MatrixEquals(listTest[0, i], listTest[1, i]);
            }
        }
        #endregion
    }
}
