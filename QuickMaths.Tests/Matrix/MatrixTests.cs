using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickMaths.BL.Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths.BL.Matrix.Tests
{
    [TestClass()]
    public class MatrixTests
    {
        [TestMethod()]
        public void Algebra()
        {
            //arrange
            long k = 5;
            double[,] tb = { { 1, 2, 3},
                             { 4, 5, 6},
                             { 7, 8, 9}};

            Matrix matrix1 = new Matrix(tb);
            Matrix matrix2 = new Matrix(tb);


            //action
            Matrix matrix3 = matrix1 + matrix2;
            Matrix matrix4 = matrix1 - matrix2;
            Matrix matrix5 = matrix1 * k;


            //assert
            for(int i = 0; i < matrix1.RowCount; i++)
            {
                for(int j = 0; j < matrix1.ColumnCount; j++)
                {
                    Assert.AreEqual(matrix3[i, j], tb[i, j] + tb[i, j]);

                    Assert.AreEqual(matrix4[i, j], tb[i, j] - tb[i, j]);

                    Assert.AreEqual(matrix5[i, j], tb[i, j] * k);
                }
            }
        }

        [TestMethod()]
        public void GetColumnTest()
        {
            Assert.Fail();
        }


        //private 
    }
}