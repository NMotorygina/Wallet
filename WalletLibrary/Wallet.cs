namespace Wallet
{
    public class Wallet
    {
        private double _money;

        public Wallet()
        {
            _money = 0;
        }

        public void Init(double sum)
        {
            _money = sum;
        }

        public void Income(double sum)
        {
            if (sum <= 0)
            {
                _money += 0;
            }
            else
            {
                _money += sum;
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