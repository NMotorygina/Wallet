using System;
using System.IO;

namespace Wallet
{
    public static class File
    {
        public static void Export(double money)
        {
            using var file = new StreamWriter("wallet.txt", false);
            file.WriteLine(money);
        }

        public static double Import()
        {
            using var file = new StreamReader("wallet.txt");
            var temp = Convert.ToDouble(file.ReadLine());
            return temp;
        }

        public static bool Exist()
        {
            return System.IO.File.Exists("wallet.txt");
        }
    }
}