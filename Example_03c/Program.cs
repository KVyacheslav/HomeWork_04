using System;

namespace Example_03c
{
    class Program
    {
        private static int countRows;               // Количество строк.
        private static int countColumns;            // Количество колонок.

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Часть 3. Умножение матриц.
            Console.WriteLine($"\nУмножение матриц:");

            Console.WriteLine("Создание первой матрицы:");
            int[,] matrix1 = CreateMatrix();

            FillArray(matrix1);
            PrintArray(matrix1);

            Console.WriteLine("\nСоздание второй матрицы:");
            int[,] matrix2 = CreateMatrix();

            FillArray(matrix2);
            PrintArray(matrix2);

            Console.WriteLine();

            if (IsMultiplying(matrix1, matrix2))
                PrintArray(MatrixMultiply(matrix1, matrix2));

            Console.ReadLine();
        }

        /// <summary>
        /// Создание матрицы.
        /// </summary>
        /// <returns></returns>
        private static int[,] CreateMatrix()
        {
            Console.Write("\nКоличество строк (минимум 1): ");
            countRows = GetUserInput();

            Console.Write("\nКоличество столбцов (минимум 1): ");
            countColumns = GetUserInput();

            return new int[countRows, countColumns];
        }

        /// <summary>
        /// Получить значение от пользователя.
        /// </summary>
        /// <returns></returns>
        private static int GetUserInput()
        {
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                if (userInput < 1)
                {
                    Console.Write("Значение должно быть больше 0: ");
                    return GetUserInput();
                }

                return userInput;
            }

            Console.Write("Значение должно быть числовое: ");
            return GetUserInput();
        }

        /// <summary>
        /// Перемножаются ли матрицы?
        /// </summary>
        /// <param name="matrix1">Первая матрица.</param>
        /// <param name="matrix2">Вторая матрица.</param>
        /// <returns></returns>
        private static bool IsMultiplying(int[,] matrix1, int[,] matrix2)
        {

            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                Console.WriteLine("Ошибка. Кол-во столбцов первой матрицы " +
                                  "должно совподать с кол-вом строк второй матрицы.");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Умножение матриц.
        /// </summary>
        /// <param name="matrix1">Первая матрица.</param>
        /// <param name="matrix2">Вторая матрица.</param>
        private static int[,] MatrixMultiply(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    int num = 0;

                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        num += matrix1[i, k] * matrix2[k, j];
                    }

                    matrix[i, j] = num;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Распечатать массив на консоль.
        /// </summary>
        /// <param name="matrix1"></param>
        private static void PrintArray(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Заполнить матрицу даными.
        /// </summary>
        /// <param name="matrix"></param>
        private static void FillArray(int[,] matrix)
        {
            Random rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(10);
                }
            }
        }
    }
}
