﻿using System;

namespace CLI
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

        public static void StartMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Хотите создать новый кошелёк?");
            Console.WriteLine("Y/Д - Да, хочу");
            Console.WriteLine("N/Н - Нет, не хочу");
            Console.ResetColor();
        }

        public static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Варианты работы:");
            Console.WriteLine("1 - Сколько денег в кошельке");
            Console.WriteLine("2 - Внести доход");
            Console.WriteLine("3 - Учесть расходы");
            Console.WriteLine("4 - Отчет о доходах/расходах");
            Console.WriteLine("0 - Выйти из программы");
            Console.ResetColor();
        }

        public static void Bye()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("До свидания...");
            Console.ResetColor();
        }

        public static double InputMoney(string message)
        {
            Console.Write(message);
            var temp = Convert.ToDouble(Console.ReadLine());
            return temp;
        }

        public static DateTime InputDate(string message)
        {
            Console.Write(message);
            var temp = Convert.ToDateTime(Console.ReadLine());
            return temp;
        }

        public static void InputIncome(out WalletLibrary.IncomeEnum income)
        {
            Console.WriteLine("Выберите тип дохода:");
            Console.WriteLine("1 - Зарплата");
            Console.WriteLine("2 - Дивиденды");
            var select = Console.ReadLine();
            income = select switch
            {
                "1" => WalletLibrary.IncomeEnum.Salary,
                "2" => WalletLibrary.IncomeEnum.Dividends,
                _ => WalletLibrary.IncomeEnum.UnknownIncome
            };
        }
        
        public static void InputOutgo(out WalletLibrary.OutgoEnum outgo)
        {
            Console.WriteLine("Выберите тип расхода:");
            Console.WriteLine("1 - Питание");
            Console.WriteLine("2 - Транспорт");
            var select = Console.ReadLine();
            outgo = select switch
            {
                "1" => WalletLibrary.OutgoEnum.Food,
                "2" => WalletLibrary.OutgoEnum.Transport,
                _ => WalletLibrary.OutgoEnum.UnknownOutgo
            };
        }

        public static void PrintIncomesOutgoes(WalletLibrary.Wallet wallet)
        {
            double sumOfIncomes = 0;
            double sumOfOutgoes = 0;
            Console.WriteLine("Доходы:");
            foreach (var i in wallet.GetIncomes())
            {
                Console.WriteLine($"{i.Date} - {i.Sum} - {i.IncomeEnum}");
                sumOfIncomes += i.Sum;
            }
            Console.WriteLine($"Итого доходы = {sumOfIncomes}");
            Console.WriteLine("Расходы:");
            foreach (var i in wallet.GetOutgoes())
            {
                Console.WriteLine($"{i.Date} - {i.Sum} - {i.OutgoEnum}");
                sumOfOutgoes += i.Sum;
            }
            Console.WriteLine($"Итого расходы = {sumOfOutgoes}");
        }
    }
}