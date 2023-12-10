using System;
using System.Threading;
using System.Threading.Tasks;

namespace DZ12
{
    internal class Program
    {
        /// <summary>
        /// Метод для 3 потока к упр 1
        /// </summary>
        static void ThirdTh()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Поток 3: {i}");
            }
        }
        /// <summary>
        /// метод для 2 потока к упр 1
        /// </summary>
        static void SecondTh()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Поток 2: {i}");
            }
        }
        /// <summary>
        /// метод для вычисления факториала к упр 2
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static int FactorialCalculation(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * FactorialCalculation(number - 1);
        }
        /// <summary>
        /// асинхронный метод для вычисления факториала к упр 2
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static async Task<int> CalculateFactorialAsync(int number)
        {
            await Task.Delay(8000);
            int factorial = await Task.Run(() => FactorialCalculation(number));
            return factorial;
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Упр 1, 3 потока выводят на экран числа 1-10");
            //поток 1
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Поток 1: {i}");
            }

            Thread th2 = new Thread(SecondTh);
            th2.Start();

            Thread th3 = new Thread(ThirdTh);
            th3.Start();

            Console.Clear();//попытка почистить экран от предыдущего задания
            Console.WriteLine("Упр 2, факторал и квадрат числа в разных потоках");
            Console.WriteLine("Введите целое число");
            try
            {
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("Квадрат числа: " + num * num);
                Console.WriteLine("Факториал числа: " + await CalculateFactorialAsync(num));

            }
            catch (Exception)
            {
                Console.WriteLine("Вы ввели что-то не то(");
            }
        }
    }
}
