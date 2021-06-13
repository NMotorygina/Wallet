using System;

namespace WalletLibrary
{
    public class Income
    {
        public DateTime Date { get; set; }
        public IncomeEnum IncomeEnum { get; set; }
        public double Sum { get; set; }

        public Income()
        {
            Date = new DateTime();
        }

        public Income(DateTime date, IncomeEnum incomeEnum, double sum)
        {
            Date = date;
            IncomeEnum = incomeEnum;
            Sum = sum;
        }
    }
}