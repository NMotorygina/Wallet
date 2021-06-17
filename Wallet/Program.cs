using System;

namespace Wallet
{
    class Program
    {
        static void Main()
        {
            CLI.CLI.Welcome();

            string select;
            var wallet = new WalletLibrary.Wallet();
            double money;
            var date = new DateTime();

            if (CLI.File.Exist())
            {
                CLI.CLI.StartMenu();
                select = Console.ReadLine();
                if (select is "Y" or "y" or "Д" or "д")
                {
                    money = CLI.CLI.InputMoney("Введите начальную сумму в кошельке ");
                    wallet.Init(money);
                }
                else
                {
                    CLI.File.Import(wallet);
                }
            }
            else
            {
                money = CLI.CLI.InputMoney("Введите начальную сумму в кошельке ");
                wallet.Init(money);
            }
            
            do
            {
                CLI.CLI.Menu();
                select = Console.ReadLine();
                switch (select)
                {
                    case "1": // 1 - Сколько денег в кошельке
                        Console.WriteLine($"Денег в кошельке - {wallet.Money()}");
                        break;
                    case "2": // 2 - Внести доход
                        date = CLI.CLI.InputDate("Введите дату дохода - ");
                        money = CLI.CLI.InputMoney("Введите доход - ");
                        CLI.CLI.InputIncome(out var income);
                        wallet.Income(date, income, money);
                        break;
                    case "3": // 3 - Учесть расходы
                        date = CLI.CLI.InputDate("Введите дату расхода - ");
                        money = CLI.CLI.InputMoney("Введите расход - ");
                        CLI.CLI.InputOutgo(out var outgo);
                        wallet.Outgo(date, outgo, money);
                        break;
                    case "4": // 4 - Отчет о доходах/расходах
                        CLI.CLI.PrintIncomesOutgoes(wallet);
                        break;
                    case "0": // 0 - Выйти из программы
                        CLI.CLI.Bye();
                        CLI.File.Export(wallet);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите правильный вариант работы!");
                        Console.ResetColor();
                        break;
                }
            } while (select != "0");
        }
    }
}