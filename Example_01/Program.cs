using System;
using System.Linq;

namespace Example_01
{
    class Program
    {
        private static int[] months;            // Месяцы.
        private static int[] incomes;           // Доход компании по месяцам.
        private static int[] costs;             // Расход компании по месяцам.
        private static int[] profits;           // Прибыль компании по месяцам.
        private static int[] monthsBadProfit;   // Месяца с плохой прибылью.
        private static int countMonthPosProfit; // Кол-во месяцев с положительной прибылью.

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Список аргументов.</param>
        static void Main(string[] args)
        {
            // Инициализация переменных
            Initialize();
            // Вывести информацию за год на консоль.
            PrintInfo();
        }

        /// <summary>
        /// Инициализация и заполнение переменных.
        /// </summary>
        private static void Initialize()
        {
            // Инициализация
            months = new int[12];
            incomes = new int[12];
            costs = new int[12];
            profits = new int[12];

            // Заполнение переменных данными.
            FillData();
        }

        /// <summary>
        /// Заполнение данных.
        /// </summary>
        private static void FillData()
        {
            Random rnd = new Random();

            for (int i = 0; i < 12; i++)
            {
                months[i] = i + 1;
                //incomes[i] = rnd.Next(9, 18) * 10_000;
                //costs[i] = rnd.Next(4, 14) * 10_000;
                incomes[i] = rnd.Next(1, 3);
                costs[i] = rnd.Next(1, 3);
                profits[i] = incomes[i] - costs[i];
            }

            // Количество месяцев с положительной прибылью.
            countMonthPosProfit = profits.Count(profit => profit > 0);

            // Задать порог для поиска плохой прибыли.
            var badProfits = profits
                .OrderBy(x => x)
                .Distinct()
                .ToArray();
            var badProfit = badProfits.Length < 3 ? badProfits[^1] : badProfits[2];

            // Записать месяца с плохой прибылью.
            SetBadMonthsByProfit(badProfit);
        }

        /// <summary>
        /// Записать месяца с плохой прибылью.
        /// </summary>
        /// <param name="badProfit">Максимальный порог для плохой прибыли.</param>
        /// <returns>Месяца с плохой прибылью.</returns>
        private static void SetBadMonthsByProfit(int badProfit)
        {
            int count = profits.Count(profit => profit <= badProfit);
            monthsBadProfit = new int[count];
            int index = 0;

            for (int i = 0; i < profits.Length; i++)
            {
                if (profits[i] <= badProfit)
                {
                    monthsBadProfit[index] = months[i];
                    index++;
                }
            }
        }

        /// <summary>
        /// Вывод информации компании за год.
        /// </summary>
        private static void PrintInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Месяц\t\tДоход, руб.\t\tРасход, руб.\t\tПрибыль, руб.");
            //Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 12; i++)
            {
                Console.ForegroundColor = i % 2 == 0 ? ConsoleColor.Yellow : ConsoleColor.White;
                Console.WriteLine($"{months[i],5}\t\t{incomes[i],10:N0}\t\t" +
                                  $"{costs[i],11:N0}\t\t{profits[i],12:N0}");
            }
            Console.ResetColor();

            Console.WriteLine($"\nКоличество месяцев с положительной прибылью: {countMonthPosProfit}.");
            Console.WriteLine($"Месяца с плохой прибылью: {string.Join(", ", monthsBadProfit)}");
        }
    }
}
