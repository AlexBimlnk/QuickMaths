using Xunit;

namespace QuickMaths.MatrixBLL.Tests;

internal class MatrixTestsData
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


    public static TheoryData<Matrix, Matrix, bool> EqualsTwoMatrixData
    {
        get
        {
            var data = new TheoryData<Matrix, Matrix, bool>();

            data.Add(_matrix1, _matrix1, true);
            data.Add(_matrix1, _matrix2, false);
            data.Add(_matrix1, _matrix5, false);
            data.Add(_matrix1, _matrix6, false);
            data.Add(_matrix1, _matrix7, false);
            data.Add(_matrix1, _matrix7, false);


            return data;
        }
    }
    public static TheoryData<Matrix, object, bool> EqualsMatrixAndObjectData
    {
        get
        {
            var data = new TheoryData<Matrix, object, bool>();

            data.Add(_matrix1, _matrix1, true);
            data.Add(_matrix1, _matrix2, false);
            data.Add(_matrix1, _matrix5, false);
            data.Add(_matrix1, _matrix6, false);
            data.Add(_matrix1, _matrix7, false);
            data.Add(_matrix1, _matrix7, false);
            data.Add(_matrix1, null!, false);
            data.Add(_matrix1, "123", false);

            return data;
        }
    }

    public static TheoryData<Matrix, long, Matrix> GetRowFromMatrixData
    {
        get
        {
            var data = new TheoryData<Matrix, long, Matrix>();

            data.Add(_matrix4, 0, new Matrix(new decimal[,] { { -5, 5, 5 } }));
            data.Add(_matrix4, 1, new Matrix(new decimal[,] { { 5, -5, 5 } }));
            data.Add(_matrix4, 2, new Matrix(new decimal[,] { { 5, 5, -5 } }));

            //Throws error data
            data.Add(_matrix4, -1, new Matrix(0, 0));
            data.Add(_matrix4, 3, new Matrix(0, 0));

            return data;
        }
    }
    public static TheoryData<Matrix, long, Matrix> GetColumnFromMatrixData
    {
        get
        {
            var data = new TheoryData<Matrix, long, Matrix>();

            data.Add(_matrix4, 0, new Matrix(new decimal[,] { { -5 }, { 5 }, { 5 } }));
            data.Add(_matrix4, 1, new Matrix(new decimal[,] { { 5 }, { -5 }, { 5 } }));
            data.Add(_matrix4, 2, new Matrix(new decimal[,] { { 5 }, { 5 }, { -5 } }));

            //Throws error data
            data.Add(_matrix4, -1, new Matrix(0, 0));
            data.Add(_matrix4, 3, new Matrix(0, 0));

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
    public static TheoryData<Matrix, Matrix, Matrix> SubstractionTwoMatrixData
    {
        get
        {
            var data = new TheoryData<Matrix, Matrix, Matrix>();

            data.Add(_matrix1,
                     _matrix1,
                     new Matrix(3, 3));
            data.Add(_matrix1,
                     _matrix2,
                     new Matrix(new decimal[,] {
                           { 12,     1, 2},
                           {  0, -0.5m, 8},
                           {  1, -0.1m, 0} }));
            data.Add(_matrix1,
                     _matrix3,
                     _matrix1);
            data.Add(_matrix1,
                     _matrix4,
                     new Matrix(new decimal[,] {
                           {  6, -3, -2},
                           { -4,  7, -2},
                           { -4, -3,  8} }));

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
    public static TheoryData<Matrix, decimal, Matrix> MultiplyMatrixAndNumberData
    {
        get
        {
            var data = new TheoryData<Matrix, decimal, Matrix>();

            data.Add(_matrix1, 0, new Matrix(3, 3));

            data.Add(_matrix1, 1, _matrix1);

            data.Add(_matrix1, -1,
                new Matrix(new decimal[,] {
                           { -1, -2, -3},
                           { -1, -2, -3},
                           { -1, -2, -3} }));

            data.Add(_matrix1, 0.5m,
                     new Matrix(new decimal[,] {
                           { 0.5m, 1, 1.5m},
                           { 0.5m, 1, 1.5m},
                           { 0.5m, 1, 1.5m} }));

            return data;
        }
    }
    public static TheoryData<Matrix, Matrix, Matrix> MultiplyTwoMatrixData
    {
        get
        {
            var data = new TheoryData<Matrix, Matrix, Matrix>();

            data.Add(_matrix1,
                     _matrix1,
                     new Matrix(new decimal[,] {
                               { 6, 12, 18 },
                               { 6, 12, 18 },
                               { 6, 12, 18 }}));
            data.Add(_matrix1,
                     _matrix2,
                     new Matrix(new decimal[,] {
                           { -9, 12.3m, 0},
                           { -9, 12.3m, 0},
                           { -9, 12.3m, 0}}));
            data.Add(_matrix1,
                     _matrix3,
                     new Matrix(3, 3));
            data.Add(_matrix1,
                     _matrix4,
                     new Matrix(new decimal[,] {
                           {  20, 10, 0},
                           {  20, 10, 0},
                           {  20, 10, 0} }));
            data.Add(_matrix1,
                     _matrix5,
                     new Matrix(3, 3));

            data.Add(_matrix1,
                     _matrix7,
                     new Matrix(new decimal[,] {
                           { 24, 47},
                           { 24, 47},
                           { 24, 47}}));

            //Throws error data
            data.Add(_matrix1,
                     _matrix6,
                     _matrix7);

            return data;
        }
    }
}
