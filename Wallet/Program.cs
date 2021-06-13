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

            if (File.Exist())
            {
                CLI.StartMenu();
                select = Console.ReadLine();
                if (select is "Y" or "y" or "Д" or "д")
                {
                    money = CLI.Input("Введите начальную сумму в кошельке ");
                    wallet.Init(money);
                }
                else
                {
                    money = File.Import();
                    wallet.Init(money);
                }
            }
            else
            {
                money = CLI.Input("Введите начальную сумму в кошельке ");
                wallet.Init(money);
            }

            do
            {
                CLI.Menu();
                select = Console.ReadLine();
                switch (select)
                {
                    case "1": // 1 - Сколько денег в кошельке
                        Console.WriteLine($"Денег в кошельке - {wallet.Money()}");
                        break;
                    case "2": // 2 - Внести доход
                        money = CLI.Input("Введите доход - ");
                        wallet.Income(money);
                        break;
                    case "3": // 3 - Учесть расходы
                        money = CLI.Input("Введите расход - ");
                        wallet.Outgo(money);
                        break;
                    case "0": // 0 - Выйти из программы
                        CLI.Bye();
                        File.Export(wallet.Money());
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