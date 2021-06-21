using System;
using System.Data;

namespace Example_02
{
    class Program
    {
        private static int[][] triangle;
        private static int height;
        private const int cellWidth = 4;

        static void Main(string[] args)
        {
            Initialize();
            PrintTriangle();

        }
        
        /// <summary>
        /// Инициализировать треугольник Паскаля.
        /// </summary>
        private static void Initialize()
        {
            Console.SetWindowSize(220, 50);

            Console.Write("Введите высоту треугольника Паскаля: ");
            height = Convert.ToByte(Console.ReadLine());

            while (height is < 1 or > 25)
            {
                Console.Write("Ошибка! Число должно быть от 1 до 25: ");
                height = Convert.ToByte(Console.ReadLine());
            }

            // Инициализируем массив массивов triangle.
            triangle = new int[height][];

            FillTriangle();
        }

        /// <summary>
        /// Заполнить треугольник Паскаля данными.
        /// </summary>
        private static void FillTriangle()
        {
            // Заполняем triangle.
            for (int i = 0; i < height; i++)
            {
                triangle[i] = new int[i + 1];

                for (int j = 0; j < triangle[i].Length; j++)
                {
                    if (j == 0 || j == i)
                        triangle[i][j] = 1;
                    else
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                }
            }
        }

        /// <summary>
        /// Распечатать треугольник Паскаля.
        /// </summary>
        private static void PrintTriangle()
        {
            int col = cellWidth * height;

            // Распечатать треугольник
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.CursorLeft = col;
                    Console.Write($"{triangle[i][j],cellWidth}");

                    col += cellWidth * 2;
                }

                col = cellWidth * height - cellWidth *  (i + 1);

                Console.WriteLine();
            }
        }
    }
}
