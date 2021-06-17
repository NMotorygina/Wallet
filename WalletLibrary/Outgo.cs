using System;

namespace WalletLibrary
{
    public class Outgo
    {
        public DateTime Date { get; set; }
        public OutgoEnum OutgoEnum { get; set; }
        public double Sum { get; set; }

        public Outgo() {}

        public Outgo(DateTime date, OutgoEnum outgoEnum, double sum)
        {
            Date = date;
            OutgoEnum = outgoEnum;
            Sum = sum;
        }
    }
}