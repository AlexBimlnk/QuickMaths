using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.MatrixBLL
{
    /// <summary>
    /// Класс реализует представление математической матрицы.
    /// </summary>
    public struct Matrix : IEquatable<Matrix>
    {
        public Matrix(long rows, long columns)
        {
            if (rows < 0 || columns < 0)
                throw new ArgumentException();

            Table = new decimal[rows, columns];
        }
        public Matrix(decimal[,] table) => Table = table?.Clone() as decimal[,] ?? throw new ArgumentNullException(nameof(table));


        public decimal[,] Table { get; init; }
        public long RowCount => Table.GetLength(0);
        public long ColumnCount => Table.GetLength(1);


        public Matrix GetRow(long indexRow)
        {
            if(indexRow < 0 || indexRow >= RowCount)
                throw new IndexOutOfRangeException($"Индекс {nameof(indexRow)} находится вне границ.");

            Matrix matrix = new Matrix(1, ColumnCount);

            for (int i = 0; i < ColumnCount; i++)
            {
                matrix[0, i] = Table[indexRow, i];
            }

            return matrix;
        }
        public Matrix GetColumn(long indexColumn)
        {
            if(indexColumn < 0 || indexColumn >= ColumnCount)
                throw new IndexOutOfRangeException($"Индекс {nameof(indexColumn)} находится вне границ.");
            
            Matrix matrix = new Matrix(RowCount, 1);

            for (int i = 0; i < RowCount; i++)
            {
                matrix[i, 0] = Table[i, indexColumn];
            }

            return matrix;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(RowCount, ColumnCount);
        }
        public override bool Equals(object? obj)
        {
            if (obj is Matrix matrix)
                return Equals(matrix);

            return false;
        }
        public bool Equals(Matrix other)
        {
            if (other.ColumnCount == ColumnCount &&
                other.RowCount == RowCount)
            {
                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        bool isEqualsElement = this[i, j] == other[i, j];

                        if (!isEqualsElement)
                            return false;
                    }
                }

                return true;
            }

            return false;
        }


        #region Математические операторы
        public static Matrix operator + (Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnCount != matrix2.ColumnCount ||
                matrix1.RowCount != matrix2.RowCount)
            {
                throw new ArithmeticException("Число строк и столбцов первой матрицы " +
                                              "не соответствуют числу строк и столбцов " +
                                              "второй матрицы");
            }


            decimal[,] table = new decimal[matrix1.RowCount, matrix1.ColumnCount];

            for (int i = 0; i < matrix1.RowCount; i++)
                for (int j = 0; j < matrix1.ColumnCount; j++)
                    table[i, j] = matrix1.Table[i, j] + matrix2.Table[i, j];

            return new Matrix(table);         
        }

        public static Matrix operator - (Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnCount != matrix2.ColumnCount ||
                matrix1.RowCount != matrix2.RowCount)
            {
                throw new ArithmeticException("Число строк и столбцов первой матрицы " +
                                              "не соответствуют числу строк и столбцов " +
                                              "второй матрицы");
            }


            decimal[,] table = new decimal[matrix1.RowCount, matrix1.ColumnCount];

            for (int i = 0; i < matrix1.RowCount; i++)
                for (int j = 0; j < matrix1.ColumnCount; j++)
                    table[i, j] = matrix1.Table[i, j] - matrix2.Table[i, j];

            return new Matrix(table);
        }

        public static Matrix operator * (Matrix matrix, decimal k)
        {
            decimal[,] table = new decimal[matrix.RowCount, matrix.ColumnCount];

            for (int i = 0; i < matrix.RowCount; i++)
                for (int j = 0; j < matrix.ColumnCount; j++)
                    table[i, j] = matrix.Table[i, j] * k;

            return new Matrix(table);
        }

        public static Matrix operator * (Matrix matrix1, Matrix matrix2)
        {
            long column1 = matrix1.ColumnCount;
            long row2 = matrix2.RowCount;

            if (column1 != row2)
                throw new ArithmeticException("Количество столбцов первой матрицы " +
                                              "не равно количеству строк второй матрицы.");

            long row1 = matrix1.RowCount;
            long column2 = matrix2.ColumnCount;

            decimal[,] table = new decimal[row1, column2];

            for (int i = 0; i < row1; i++)
                for (int j = 0; j < column2; j++)
                    for (int k = 0; k < column1; k++)
                        table[i, j] += matrix1.Table[i, k] * matrix2.Table[k, j];

            return new Matrix(table);
        }
        #endregion


        public decimal this[long rowIndex, long columnIndex]
        {
            get { return Table[rowIndex, columnIndex]; }
            set { Table[rowIndex, columnIndex] = value; }
        }
    }
}
