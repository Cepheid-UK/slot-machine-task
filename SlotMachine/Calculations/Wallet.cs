using System;

namespace SlotMachine.Calculations
{
    public class Wallet
    {
        public Wallet()
        {
            Stake = 0;
        }

        private decimal Balance { get; set; }
        private decimal Stake { get; set; }
        
        public bool CanAffordBet(decimal bet)
        {
            if (bet > Balance)
            {
                return false;
            }
            return true;
        }

        public bool IsBankrupt()
        {
            if (Balance <= 0)
            {
                return true;
            }
            return false;
        }

        public void DepositMoney(decimal money)
        {
            Balance += decimal.Round(money,2);
        }

        public void StakeMoney(decimal stake)
        {
            Stake = decimal.Round(stake,2);
            Balance = (Balance - Stake);
        }

        public decimal GetStake()
        {
            return Stake;
        }

        public void DisplayBalance()
        {
            Console.WriteLine("\r\nCurrent balance is: {0}", Balance.ToString());
        }
    }
}
