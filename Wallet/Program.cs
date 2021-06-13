using System;

namespace Wallet
{
    class Program
    {
        static void Main()
        {
            CLI.Welcome();

            string select;
            Wallet wallet = new Wallet();
            double money;
            do
            {
                CLI.Menu();
                select = Console.ReadLine();
                switch (select)
                {
                    case "1": // 1 - Создать кошелёк
                        money = CLI.Input("Введите начальную сумму в кошельке ");
                        wallet.Init(money);
                        break;
                    case "2": // 2 - Сколько денег в кошельке
                        Console.WriteLine($"Денег в кошельке - {wallet.Money()}");
                        break;
                    case "3": // 3 - Внести доход
                        money = CLI.Input("Введите доход - ");
                        wallet.Income(money);
                        break;
                    case "4": // 4 - Учесть расходы
                        money = CLI.Input("Введите расход - ");
                        wallet.Outgo(money);
                        break;
                    case "0": // 0 - Выйти из программы
                        CLI.Bye();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите правильный вариант работй!");
                        Console.ResetColor();
                        break;
                }
            } while (select != "0");
        }
    }
}