using System;
using System.Collections.Generic;
using System.IO;
using WalletLibrary;

namespace CLI
{
    public static class File
    {
        public static void Export(Wallet wallet)
        {
            using var file = new StreamWriter("wallet.txt", false);
            file.WriteLine(wallet.Money());
            string temp;
            foreach (var i in wallet.GetIncomes())
            {
                temp = i.Date + ";" + i.IncomeEnum + ";" + i.Sum + ";";
                file.WriteLine(temp);
                temp = null;
            }
            foreach (var i in wallet.GetOutgoes())
            {
                temp = i.Date + ";" + i.OutgoEnum + ";" + i.Sum + ";";
                file.WriteLine(temp);
                temp = null;
            }
        }

        public static void Import(Wallet wallet)
        {
            string temp;
            var strings = new List<string>();
            using var file = new StreamReader("wallet.txt");
            while ((temp = file.ReadLine()) != null)
            {
                strings.Add(temp);
            }
            wallet.Init(Convert.ToDouble(strings[0]));
            for (int i = 1; i < strings.Count; i++)
            {
                temp = strings[i];
                var values = temp.Split(new char[] { ';' });
                if (values[1] is "UnknownIncome" or "Salary" or "Dividends")
                {
                    IncomeEnum income = values[1] switch
                    {
                        "Salary" => IncomeEnum.Salary,
                        "Dividends" => IncomeEnum.Dividends,
                        _ => IncomeEnum.UnknownIncome
                    };
                    wallet.SetIncome(Convert.ToDateTime(values[0]), income, Convert.ToDouble(values[2]));
                }
                else
                {
                    OutgoEnum outgo = values[1] switch
                    {
                        "Food" => OutgoEnum.Food,
                        "Transport" => OutgoEnum.Transport,
                        _ => OutgoEnum.UnknownOutgo
                    };
                    wallet.SetOutgo(Convert.ToDateTime(values[0]), outgo, Convert.ToDouble(values[2]));
                }
            }
        }

        public static bool Exist()
        {
            return System.IO.File.Exists("wallet.txt");
        }
    }
}