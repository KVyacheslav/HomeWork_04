using System;

namespace Example_03b
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
            // Часть 2. Сложение и вычитание матриц.
            Console.WriteLine("Создание первой матрицы:");
            int[,] matrix1 = CreateMatrix();

            FillArray(matrix1);
            PrintArray(matrix1);

            Console.WriteLine("\nСоздание второй матрицы:");
            int[,] matrix2 = CreateMatrix();

            FillArray(matrix2);
            PrintArray(matrix2);

            Console.WriteLine("\nСложение матриц:");
            if (AreMatricesSame(matrix1, matrix2))
                PrintArray(MatrixAddition(matrix1, matrix2));

            Console.WriteLine("\nВычитание матриц:");
            if (AreMatricesSame(matrix1, matrix2))
                PrintArray(MatrixSubtraction(matrix1, matrix2));

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
        /// Идентичны ли матрицы?
        /// </summary>
        /// <param name="matrix1">Первая матрица.</param>
        /// <param name="matrix2">Ваторая матрица.</param>
        /// <returns></returns>
        private static bool AreMatricesSame(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) ||
                matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                Console.WriteLine("Размерность матрицы не идентична!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Вычитание матриц.
        /// </summary>
        /// <param name="matrix1">Первая матрица.</param>
        /// <param name="matrix2">Вторая матрица.</param>
        /// <returns></returns>
        private static int[,] MatrixSubtraction(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) &&
                matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                Console.WriteLine("Размеры матриц должны совпадать!");
                return null;
            }

            int[,] matrix = new int[countRows, countColumns];

            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countColumns; j++)
                {
                    matrix[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return matrix;
        }

        /// <summary>
        /// Сложение матриц.
        /// </summary>
        /// <param name="matrix1">Первая матрица.</param>
        /// <param name="matrix2">Вторая матрица.</param>
        /// <returns>Сумма матриц.</returns>
        private static int[,] MatrixAddition(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) &&
                matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                Console.WriteLine("Размеры матриц должны совпадать!");
                return null;
            }

            int[,] matrix = new int[countRows, countColumns];

            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countColumns; j++)
                {
                    matrix[i, j] = matrix1[i, j] + matrix2[i, j];
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
            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countColumns; j++)
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

            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countColumns; j++)
                {
                    matrix[i, j] = rnd.Next(10);
                }
            }
        }
    }
}
