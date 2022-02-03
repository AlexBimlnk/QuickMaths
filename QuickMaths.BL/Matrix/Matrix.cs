﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMaths.BL.Functions;

namespace QuickMaths.BL.Matrix
{
    /// <summary>
    /// Класс реализует представление математической матрицы.
    /// </summary>
    public class Matrix
    {
        public double[,] Table { get; private set; }

        public long RowCount => Table.GetLength(0);

        public long ColumnCount => Table.GetLength(1);


        public Matrix(long rows, long columns)
        {
            Table = new double[rows, columns];
        }

        public Matrix(double[,] table)
        {
            Table = (double[,])table.Clone();
        }

        //public Matrix(LinearFunction[,] linearFunctions)
        //{
        //    long row = linearFunctions.GetLongLength(0);
        //    long column = linearFunctions.GetLongLength(1);
        //    Table = new double[row, column];

        //    Console.WriteLine(linearFunctions.Length);

        //    for(int i = 0; i < row; i++)
        //    {
        //        for (int j = 0; j < column; j++)
        //            Table[i, j] = linearFunctions[i, j].Digit;
        //    }
        //}


        public double this[long rowIndex, long columnIndex]
        {
            get { return Table[rowIndex, columnIndex]; }
            set { Table[rowIndex, columnIndex] = value; }
        }


        public Matrix GetRow(long indexRow)
        {
            Matrix matrix = new Matrix(1, ColumnCount);

            for(int i = 0; i < ColumnCount; i++)
            {
                matrix[0, i] = Table[indexRow, i];
            }

            return matrix;
        }

        public Matrix GetColumn(long indexColumn)
        {
            Matrix matrix = new Matrix(RowCount, 1);

            for (int i = 0; i < RowCount; i++)
            {
                matrix[i, 0] = Table[i, indexColumn];
            }

            return matrix;
        }


        #region Статические функции
        public static Matrix operator + (Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnCount == matrix2.ColumnCount &&
                matrix1.RowCount == matrix2.RowCount)
            {
                double[,] table = new double[matrix1.RowCount, matrix1.ColumnCount];

                for (int i = 0; i < matrix1.RowCount; i++)
                    for (int j = 0; j < matrix1.ColumnCount; j++)
                        table[i, j] = matrix1.Table[i, j] + matrix2.Table[i, j];

                return new Matrix(table);
            }
            else
                throw new Exception("Число строк и столбцов первой матрицы " +
                                    "не соответствуют числу строк и столбцов второй матрицы");
        }

        public static Matrix operator - (Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnCount == matrix2.ColumnCount &&
                matrix1.RowCount == matrix2.RowCount)
            {
                double[,] table = new double[matrix1.RowCount, matrix1.ColumnCount];

                for (int i = 0; i < matrix1.RowCount; i++)
                    for (int j = 0; j < matrix1.ColumnCount; j++)
                        table[i, j] = matrix1.Table[i, j] - matrix2.Table[i, j];

                return new Matrix(table);
            }
            else
                throw new Exception("Число строк и столбцов первой матрицы " +
                                    "не соответствуют числу строк и столбцов второй матрицы");
        }

        public static Matrix operator * (Matrix matrix, double k)
        {
            double[,] table = new double[matrix.RowCount, matrix.ColumnCount];

            for (int i = 0; i < matrix.RowCount; i++)
                for (int j = 0; j < matrix.ColumnCount; j++)
                    table[i, j] = matrix.Table[i, j] * k;

            return new Matrix(table);
        }

        public static Matrix operator * (Matrix matrix1, Matrix matrix2)
        {
            long column1 = matrix1.ColumnCount;
            long row2 = matrix2.RowCount;

            if (column1 == row2)
            {
                long row1 = matrix1.RowCount;
                long column2 = matrix2.ColumnCount;

                double[,] table = new double[row1, column2];

                for (int i = 0; i < row1; i++)
                    for (int j = 0; j < column2; j++)
                        for (int k = 0; k < column1; k++)
                            table[i, j] += matrix1.Table[i, k] * matrix2.Table[k, j];

                return new Matrix(table);
            }
            else
                throw new Exception("Количество столбцов первой матрицы " +
                                    "не равно количеству строк второй матрицы.");
        }
        #endregion

    }
}