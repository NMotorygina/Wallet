using System;
using System.Collections.Generic;

namespace WalletLibrary
{
    public class Wallet
    {
        private double _money;
        private List<Income> _incomes;
        private List<Outgo> _outgoes;

        public Wallet()
        {
            _money = 0;
            _incomes = new List<Income>();
            _outgoes = new List<Outgo>();
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
            }
        }
        
        public void Outgo(DateTime date, OutgoEnum outgo, double sum)
        {
            if (sum <= 0)
            {
                _money -= 0;
            }
            else
            {
                _money -= sum;
                var _outgo = new Outgo(date, outgo, sum);
                _outgoes.Add(_outgo);
            }
        }

        public double Money()
        {
            return _money;
        }
        
        public List<Income> GetIncomes()
        {
            return _incomes;
        }
        
        public List<Outgo> GetOutgoes()
        {
            return _outgoes;
        }

        public void SetIncome(DateTime date, IncomeEnum income, double sum)
        {
            var _income = new Income(date, income, sum);
            _incomes.Add(_income);
        }

        public void SetOutgo(DateTime date, OutgoEnum outgo, double sum)
        {
            var _outgo = new Outgo(date, outgo, sum);
            _outgoes.Add(_outgo);
        }
    }
}