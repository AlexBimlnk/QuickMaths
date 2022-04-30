using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace QuickMaths.MatrixBLL.Tests
{
    public class MatrixTestData
    {

        #region Const matrix data

        private static Matrix _matrix1 = new Matrix(new decimal[,] { 
                                                   { 1, 2, 3 },
                                                   { 1, 2, 3 },
                                                   { 1, 2, 3 } });

        private static Matrix _matrix2 = new Matrix(new decimal[,] { 
                                                   { -11,     1,  1 },
                                                   {   1,  2.5m, -5 },
                                                   {   0,  2.1m,  3 } });

        private static Matrix _matrix3 = new Matrix(new decimal[,] { 
                                                   { 0, 0, 0 },
                                                   { 0, 0, 0 },
                                                   { 0, 0, 0 } });

        private static Matrix _matrix4 = new Matrix(new decimal[,] { 
                                                   { -5,  5,  5 },
                                                   {  5, -5,  5 },
                                                   {  5,  5, -5 } });

        private static Matrix _matrix5 = new Matrix(3, 3);
        private static Matrix _matrix6 = new Matrix(2, 3);

        private static Matrix _matrix7 = new Matrix(new decimal[,] { 
                                                   { 1, 9 },
                                                   { 4, 7 },
                                                   { 5, 8 } });

        #endregion

        public static TheoryData<Matrix> Matrixs
        {
            get
            {
                var data = new TheoryData<Matrix>();

                data.Add(_matrix1);
                data.Add(_matrix2);
                data.Add(_matrix3);
                data.Add(_matrix4);
                data.Add(_matrix5);
                data.Add(_matrix6);
                data.Add(_matrix7);

                return data;
            }
        }

        public static TheoryData<Matrix, Matrix, Matrix> SumTwoMatrixData
        {
            get
            {
                var data = new TheoryData<Matrix, Matrix, Matrix>();

                data.Add(_matrix1,
                         _matrix1,
                         new Matrix(new decimal[,] {
                               { 2, 4, 6},
                               { 2, 4, 6},
                               { 2, 4, 6} }));
                data.Add(_matrix1,
                         _matrix2,
                         new Matrix(new decimal[,] {
                               { -10,     3,   4},
                               {   2,  4.5m,  -2},
                               {   1,  4.1m,   6} }));
                data.Add(_matrix1,
                         _matrix3,
                         _matrix1);
                data.Add(_matrix1,
                         _matrix4,
                         new Matrix(new decimal[,] {
                               { -4,  7,  8},
                               {  6, -3,  8},
                               {  6,  7, -2} }));

                data.Add(_matrix1,
                         _matrix5,
                         _matrix1);

                //Throws error data
                data.Add(_matrix1,
                         _matrix6,
                         _matrix7);
                data.Add(_matrix1,
                         _matrix7,
                         _matrix6);


                return data;
            }
        }
    }
}
