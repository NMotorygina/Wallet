using System;
using System.Collections.Generic;

namespace WalletLibrary
{
    public class Wallet
    {
        private double _money;
        private List<Income> _incomes;

        public Wallet()
        {
            _money = 0;
            _incomes = new List<Income>();
        }

        public void Init(double sum)
        {
            _money = sum;
        }

        public void Income(DateTime date, IncomeEnum income, double sum)
        {
            if (sum <= 0)
            {
                _money += 0;
            }
            else
            {
                _money += sum;
                var _income = new Income(date, income, sum);
                _incomes.Add(_income);
                // _incomes.Add(new Income(date, income, sum));
            }
        }

        public void Outgo(double sum)
        {
            if (sum <= 0)
            {
                _money -= 0;
            }
            else
            {
                _money -= sum;
            }
        }

        public double Money()
        {
            return _money;
        }
    }
}