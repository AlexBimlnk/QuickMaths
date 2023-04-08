﻿using QuickMaths.General.Abstractions;

namespace QuickMaths.Matrices;

/// <summary>
/// Класс реализует представление математической матрицы.
/// </summary>
public sealed class Matrix : IEquatable<Matrix>, IArithmeticable
{
    private readonly List<List<double>> _table;

    public Matrix(IReadOnlyCollection<IReadOnlyCollection<double>> table)
    {
        ArgumentNullException.ThrowIfNull(table, nameof(table));

        //_table = new List<List<double>>(table);
    }

    public Matrix(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0)
            throw new ArgumentOutOfRangeException($"{nameof(rows)} or {nameof(columns)}");

        var column = new double[columns];
        _table = new List<List<double>>(rows);
        _table.AddRange(Enumerable.Range(0, rows)
            .Select(x =>
            {
                var columnList = new List<double>(columns);
                columnList.AddRange(column);

                return columnList;
            }));
    }
    public Matrix(decimal[,] table)
    {
        Table = table?.Clone() as decimal[,] ?? throw new ArgumentNullException(nameof(table));
    }

    public decimal[,] Table { get; init; }
    public int RowsCount => Table.GetLength(0);
    public int ColumnsCount => Table.GetLength(1);

    

    public Matrix GetRow(int indexRow)
    {
        if (indexRow < 0 || indexRow >= RowsCount)
            throw new IndexOutOfRangeException($"Индекс {nameof(indexRow)} находится вне границ.");

        var matrix = new Matrix(1, ColumnsCount);

        for (var i = 0; i < ColumnsCount; i++)
        {
            matrix[0, i] = Table[indexRow, i];
        }

        return matrix;
    }
    public Matrix GetColumn(int indexColumn)
    {
        if (indexColumn < 0 || indexColumn >= ColumnsCount)
            throw new IndexOutOfRangeException($"Индекс {nameof(indexColumn)} находится вне границ.");

        var matrix = new Matrix(RowsCount, 1);

        for (var i = 0; i < RowsCount; i++)
        {
            matrix[i, 0] = Table[i, indexColumn];
        }

        return matrix;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Matrix matrix)
            return Equals(matrix);

        return false;
    }
    public bool Equals(Matrix other)
    {
        if (other.ColumnsCount == ColumnsCount &&
            other.RowsCount == RowsCount)
        {
            for (var i = 0; i < RowsCount; i++)
            {
                for (var j = 0; j < ColumnsCount; j++)
                {
                    var isEqualsElement = this[i, j] == other[i, j];

                    if (!isEqualsElement)
                        return false;
                }
            }

            return true;
        }

        return false;
    }
    public override int GetHashCode() => HashCode.Combine(RowsCount, ColumnsCount);


    public decimal this[long rowIndex, long columnIndex]
    {

        get => Table[rowIndex, columnIndex];
        set => Table[rowIndex, columnIndex] = value;
    }


    #region Математические операторы
    public static Matrix operator +(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.ColumnsCount != matrix2.ColumnsCount ||
            matrix1.RowsCount != matrix2.RowsCount)
        {
            throw new ArithmeticException("Число строк и столбцов первой матрицы " +
                                          "не соответствуют числу строк и столбцов " +
                                          "второй матрицы");
        }


        var table = new decimal[matrix1.RowsCount, matrix1.ColumnsCount];

        for (var i = 0; i < matrix1.RowsCount; i++)
            for (var j = 0; j < matrix1.ColumnsCount; j++)
                table[i, j] = matrix1.Table[i, j] + matrix2.Table[i, j];

        return new Matrix(table);
    }

    public static Matrix operator -(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.ColumnsCount != matrix2.ColumnsCount ||
            matrix1.RowsCount != matrix2.RowsCount)
        {
            throw new ArithmeticException("Число строк и столбцов первой матрицы " +
                                          "не соответствуют числу строк и столбцов " +
                                          "второй матрицы");
        }


        var table = new decimal[matrix1.RowsCount, matrix1.ColumnsCount];

        for (var i = 0; i < matrix1.RowsCount; i++)
            for (var j = 0; j < matrix1.ColumnsCount; j++)
                table[i, j] = matrix1.Table[i, j] - matrix2.Table[i, j];

        return new Matrix(table);
    }

    public static Matrix operator *(Matrix matrix, decimal k)
    {
        var table = new decimal[matrix.RowsCount, matrix.ColumnsCount];

        for (var i = 0; i < matrix.RowsCount; i++)
            for (var j = 0; j < matrix.ColumnsCount; j++)
                table[i, j] = matrix.Table[i, j] * k;

        return new Matrix(table);
    }
    public static Matrix operator *(decimal k, Matrix matrix) => matrix * k;

    public static Matrix operator *(Matrix matrix1, Matrix matrix2)
    {
        var column1 = matrix1.ColumnsCount;
        var row2 = matrix2.RowsCount;

        if (column1 != row2)
            throw new ArithmeticException("Количество столбцов первой матрицы " +
                                          "не равно количеству строк второй матрицы.");

        var row1 = matrix1.RowsCount;
        var column2 = matrix2.ColumnsCount;

        var table = new decimal[row1, column2];

        for (var i = 0; i < row1; i++)
            for (var j = 0; j < column2; j++)
                for (var k = 0; k < column1; k++)
                    table[i, j] += matrix1.Table[i, k] * matrix2.Table[k, j];

        return new Matrix(table);
    }
    #endregion
}