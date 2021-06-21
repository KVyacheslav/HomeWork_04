using System;

namespace Example_03a
{
    public class Program
    {
        private static int countRows;               // Количество строк.
        private static int countColumns;            // Количество колонок.

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Часть 1. Умножение матрицы на число.
            Console.WriteLine("Создание первой матрицы:");
            int[,] matrix1 = CreateMatrix();

            FillArray(matrix1);
            PrintArray(matrix1);

            Console.Write("\nУмножить матрицу на число:");
            MultiplyMatrixByNumber(matrix1);

            Console.WriteLine("\nМатрица после умножения:");
            PrintArray(matrix1);

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
        /// <param name="isForMatrix">Для расчета размерности матрицы?</param>
        /// <returns>Число.</returns>
        private static int GetUserInput(bool isForMatrix = true)
        {
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                if (userInput < 1 && isForMatrix)
                {
                    Console.Write("Значение должно быть больше 0: ");
                    return GetUserInput();
                }

                return userInput;
            }

            Console.Write("Значение должно быть числовое: ");
            return GetUserInput(isForMatrix);
        }

        /// <summary>
        /// Умножить матрицу на число.
        /// </summary>
        /// <param name="matrix">Исходная матрица.</param>
        /// <param name="num">Число для умножения.</param>
        private static void MultiplyMatrixByNumber(int[,] matrix)
        {
            Console.Write("Введите число: ");
            int num = GetUserInput(false);

            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countColumns; j++)
                {
                    matrix[i, j] *= num;
                }
            }
        }

        /// <summary>
        /// Распечатать массив на консоль.
        /// </summary>
        /// <param name="matrix"></param>
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
