using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_Task2
{
    public partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            if (a.GetHeight() != b.GetHeight() || a.GetWidth() != b.GetWidth())
            {
                throw new ArgumentException("Матриці мають різні розміри, неможливо їх додати.");
            }

            double[,] result = new double[a.GetHeight(), a.GetWidth()];
            for (int i = 0; i < a.GetHeight(); i++)
            {
                for (int j = 0; j < a.GetWidth(); j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }

            return new MyMatrix(result);
        }

        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.GetWidth() != b.GetHeight())
            {
                throw new ArgumentException("Кількість стовпчиків першої матриці не дорівнює кількості рядків другої матриці.");
            }

            double[,] result = new double[a.GetHeight(), b.GetWidth()];
            for (int i = 0; i < a.GetHeight(); i++)
            {
                for (int j = 0; j < b.GetWidth(); j++)
                {
                    for (int k = 0; k < a.GetWidth(); k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return new MyMatrix(result);
        }

        private double[,] GetTransponedArray()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] transposed = new double[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposed[j, i] = matrix[i, j];
                }
            }

            return transposed;
        }

        public MyMatrix GetTransponedCopy()
        {
            double[,] transposedArray = GetTransponedArray();
            return new MyMatrix(transposedArray);
        }

        public void TransposeMe()
        {
            double[,] transposedArray = GetTransponedArray();
            matrix = (double[,])transposedArray.Clone();
        }

    }
}
