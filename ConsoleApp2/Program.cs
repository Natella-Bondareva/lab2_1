using lab2_Task2;
using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] initialArray = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            MyMatrix matrix1 = new MyMatrix(initialArray);
            Console.WriteLine("Matrix 1:");
            Console.WriteLine(matrix1);

            // Тестуємо копіювальний конструктор
            MyMatrix matrix2 = new MyMatrix(matrix1);
            Console.WriteLine("\nMatrix 2 (copy of Matrix 1):");
            Console.WriteLine(matrix2);

            // Тестуємо індексатор
            Console.WriteLine("\nElement at (1, 1) in Matrix 1: " + matrix1[1, 1]);

            // Тестуємо властивості Height і Width
            Console.WriteLine("\nHeight of Matrix 1: " + matrix1.Height);
            Console.WriteLine("Width of Matrix 1: " + matrix1.Width);

            // Тестуємо оператор +
            MyMatrix matrix3 = new MyMatrix(new double[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 } });
            MyMatrix sumMatrix = matrix1 + matrix3;
            Console.WriteLine("\nMatrix 3:");
            Console.WriteLine(matrix3);
            Console.WriteLine("\nMatrix 1 + Matrix 3:");
            Console.WriteLine(sumMatrix);

            // Тестуємо оператор *
            MyMatrix matrix4 = new MyMatrix(new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            MyMatrix productMatrix = matrix1 * matrix4;
            Console.WriteLine("\nMatrix 4 (identity matrix):");
            Console.WriteLine(matrix4);
            Console.WriteLine("\nMatrix 1 * Matrix 4:");
            Console.WriteLine(productMatrix);

            // Тестуємо методи транспонування
            Console.WriteLine("\nTransposed Matrix 1:");
            Console.WriteLine(matrix1.GetTransponedCopy());

            // Тестуємо метод TransposeMe()
            matrix1.TransposeMe();
            Console.WriteLine("\nMatrix 1 after TransposeMe():");
            Console.WriteLine(matrix1);

            // Тестуємо виведення матриці через ToString()
            Console.WriteLine("\nMatrix 1 as a string:");
            Console.WriteLine(matrix1.ToString());
        }
    }
}