using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace lab2_Task2
{
    public partial class MyMatrix
    {
        private double[,] matrix;
        public MyMatrix(MyMatrix other)
        {
            matrix = (double[,])other.matrix.Clone();
        }

        public MyMatrix(double[,] array)
        {
            matrix = (double[,])array.Clone();
        }

        public MyMatrix(double[][] jaggedArray)
        {
            int rows = jaggedArray.Length;
            int cols = jaggedArray[0].Length;
            matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                if (jaggedArray[i].Length != cols)
                {
                    throw new ArgumentException("Зубчастий масив має бути прямокутним!");
                }
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = jaggedArray[i][j];
                }
            }
        }

        public MyMatrix(string[] stringArray)
        {
            int rows = stringArray.Length;
            int cols = stringArray[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] values = stringArray[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length != cols)
                {
                    throw new ArgumentException("Некоректний ввід даних, не можливо створити прямокутну матрицю з цього рядка");
                }
                for (int j = 0; j < cols; j++)
                {
                    try
                    {
                        matrix[i, j] = Convert.ToDouble(values[j]);
                    }
                    catch (FormatException)
                    {
                        throw new ArgumentException("Некоректний ввід даних, в рядку всі елементи мають бути числами!");
                    }
                }
            }
        }

        public MyMatrix(string str) : this(str.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {

        }

        public int Height { get { return matrix.GetLength(0); } }
        public int Width { get { return matrix.GetLength(1); } }

        public int GetHeight()
        {
            return matrix.GetLength(0);
        }

        public int GetWidth()
        {
            return matrix.GetLength(1);
        }

        public double this[int row, int col]
        {
            get 
            {
                try
                {
                    return matrix[row, col];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException("Індекси виходять за межі розміру матриці.");
                }
            }
            set 
            {
                try
                {
                    matrix[row, col] = (double)value;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException("Індекси виходять за межі розміру матриці.");
                }
                catch (InvalidCastException)
                {
                    throw new ArgumentException("Це має бути число!");
                }
            }
        }

        public double GetElement(int row, int col)
        {

            return this[row, col];

        }

        public void SetElement(int row, int col, double value)
        {
            this[row, col] = value;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    result.Append(matrix[i, j].ToString() + "\t");
                }
                result.Append("\n");
            }
            return result.ToString();
        }
    }
}
