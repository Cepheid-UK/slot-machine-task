namespace SlotMachine
{
    public class Wallet
    {
        public Wallet()
        {
            stake = 0;
        }
        public int balance { get; set; }
        public int stake { get; set; }
        public bool CanAffordBet(int bet)
        {
            if (bet > balance)
            {
                return false;
            }
            return true;
        }

        public bool IsBankrupt()
        {
            if (balance <= 0)
            {
                return true;
            }
            return false;
        }

        public void DepositMoney(int money)
        {
            balance += money;
        }

        public void StakeMoney(int money)
        {
            stake = money;
            balance -= stake;
        }

        public void ResolveBet(bool won)
        {
            if(won)
            {
                balance += (stake * 2);
                stake = 0;
            }
            else
            {
                stake = 0;
            }
        }
    }
}
