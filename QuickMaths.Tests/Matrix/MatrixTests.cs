using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuickMaths.MatrixBll.Tests
{
    public class MatrixTests
    {
        private static Matrix _data = new Matrix(new double[,] { { 1, 2, 3 },
                                                                 { 1, 2, 3 },
                                                                 { 1, 2, 3 } });


        private static Matrix _data1 = new Matrix(new double[,] { { 1, 2, 3 },
                                                                   { 1, 2, 3 },
                                                                   { 1, 2, 3 } });
        private static Matrix _data2 = new Matrix(new double[,] { { 0, 0, 0 },
                                                                   { 0, 0, 0 },
                                                                   { 0, 0, 0 } });
        private static Matrix _data3 = new Matrix(new double[,] { { 5, 5, 5 },
                                                                   { 5, 5, 5 },
                                                                   { 5, 5, 5 } });
        private static Matrix _data4 = new Matrix(3, 3);
        private static Matrix _data5 = new Matrix(2, 3);
        private static Matrix _data6 = new Matrix(new double[,] { { 1, 9 },
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


        #region Арифметические операции

        [Fact]
        public void SummMatrix_TwoMatrix_ReturnMatrixOfSumm()
        {
            const int TEST_COUNT = 4;


            Matrix result1 = new Matrix(new double[,] { { 2, 4, 6 }, { 2, 4, 6 }, { 2, 4, 6 } });
            Matrix result2 = new Matrix(_data.Table);
            Matrix result3 = new Matrix(new double[,] { { 6, 7, 8 }, { 6, 7, 8 }, { 6, 7, 8 } });
            Matrix result4 = new Matrix(_data.Table);


            Matrix output1 = _data + _data1;
            Matrix output2 = _data + _data2;
            Matrix output3 = _data + _data3;
            Matrix output4 = _data + _data4;
            Assert.Throws<ArithmeticException>(() => _data + _data5);
            Assert.Throws<ArithmeticException>(() => _data + _data6);


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
            Matrix result3 = new Matrix(new double[,] { { -4, -3, -2 }, { -4, -3, -2 }, { -4, -3, -2 } });
            Matrix result4 = new Matrix(_data.Table);


            Matrix output1 = _data - _data1;
            Matrix output2 = _data - _data2;
            Matrix output3 = _data - _data3;
            Matrix output4 = _data - _data4;
            Assert.Throws<ArithmeticException>(() => _data - _data5);
            Assert.Throws<ArithmeticException>(() => _data - _data6);


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
        public void MultiplyMatrix_MatrixAndNumber_ReturnMatrixOfMultiply(double k)
        {
            Matrix result = _data * k;

            for (int i = 0; i < _data.RowCount; i++)
            {
                for (int j = 0; j < _data.ColumnCount; j++)
                {
                    Assert.Equal(result[i, j], _data[i, j] * k);
                }
            }

        }

        [Fact]
        public void MultiplyMatrix_TwoMatrix_ReturnMatrixOfMultiply()
        {
            const int TEST_COUNT = 5;


            Matrix result1 = new Matrix(new double[,] { { 6, 12, 18 }, { 6, 12, 18 }, { 6, 12, 18 } });
            Matrix result2 = new Matrix(3, 3);
            Matrix result3 = new Matrix(new double[,] { { 30, 30, 30 }, { 30, 30, 30 }, { 30, 30, 30 } });
            Matrix result4 = new Matrix(3, 3);
            Matrix result6 = new Matrix(new double[,] { { 24, 47 },
                                                        { 24, 47 },
                                                        { 24, 47 } });


            Matrix output1 = _data * _data1;
            Matrix output2 = _data * _data2;
            Matrix output3 = _data * _data3;
            Matrix output4 = _data * _data4;
            Matrix output6 = _data * _data6;
            Assert.Throws<ArithmeticException>(() => _data * _data5);


            Matrix[,] listTest = new Matrix[,]{ { result1, result2, result3, result4, result6},
                                                { output1, output2, output3, output4, output6}};


            for (int i = 0; i < TEST_COUNT; i++)
            {
                MatrixEquals(listTest[0, i], listTest[1, i]);
            }
        }
        #endregion


        [Theory]
        [InlineData(-1)]
        [InlineData(0, new double[] { 1, 1, 1})]
        [InlineData(1, new double[] { 2, 2, 2 })]
        [InlineData(2, new double[] { 3, 3, 3 })]
        [InlineData(3)]
        [InlineData(4)]
        public void GetColumn_IndexColumn_ReturnColumnAsMatrix(long index, double[] output = null)
        {
            Matrix result = null;
            Action action = () => result = _data.GetColumn(index);

            try
            {
                action();

                for(int i = 0; i < result.RowCount; i++)
                {
                    Assert.Equal(output[i], result[i, 0]);
                }

            }
            catch
            {
                Assert.Throws<IndexOutOfRangeException>(action);
            }

            
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0, new double[] { 1, 9 })]
        [InlineData(1, new double[] { 4, 7 })]
        [InlineData(2, new double[] { 5, 8 })]
        [InlineData(3)]
        [InlineData(4)]
        public void GetRow_IndexRow_ReturnRowAsMatrix(long index, double[] output = null)
        {
            Matrix result = null;
            Action action = () => result = _data6.GetRow(index);

            try
            {
                action();

                for (int i = 0; i < result.ColumnCount; i++)
                {
                    Assert.Equal(output[i], result[0, i]);
                }

            }
            catch
            {
                Assert.Throws<IndexOutOfRangeException>(action);
            }
        }
    }
}
