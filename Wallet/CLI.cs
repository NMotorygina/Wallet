using System;

namespace Wallet
{
    public static class CLI
    {
        public static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("++++++++++++++++++++");
            Console.WriteLine("+++ Wallet v 0.0 +++");
            Console.WriteLine("++++++++++++++++++++");
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Варианты работы:");
            Console.WriteLine("1 - Создать кошелёк");
            Console.WriteLine("2 - Сколько денег в кошельке");
            Console.WriteLine("3 - Внести доход");
            Console.WriteLine("4 - Учесть расходы");
            Console.WriteLine("0 - Выйти из программы");
            Console.ResetColor();
        }

        public static void Bye()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("До свидания...");
            Console.ResetColor();
        }

        public static double Input(string message)
        {
            Console.Write(message);
            var temp = Convert.ToDouble(Console.ReadLine());
            return temp;
        }
    }
}