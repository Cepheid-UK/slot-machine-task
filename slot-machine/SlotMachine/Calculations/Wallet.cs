using System;
using SlotMachine.Ports;

namespace SlotMachine.Calculations
{
    public class Wallet : IWallet
    {
        public Wallet()
        {
            Stake = 0;
        }
        protected decimal Balance { get; set; }
        protected decimal Stake { get; set; }
        
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
            if (money > 0 || (Balance + money) > 0)
            {
                Balance += decimal.Round(money, 2);
            }
        }

        public void StakeMoney(decimal stake)
        {
            if (stake > 0 && stake <= Balance)
            {
                Stake = decimal.Round(stake, 2);
                Balance -= Stake;
            }
            
        }

        public decimal GetStake()
        {
            return Stake;
        }

        public void BetResult(decimal result)
        {
            var BetResult = decimal.Round(result, 2);

            if (result < 0 && result < Stake) return;
            
            if (BetResult > 0)
            {
                Console.WriteLine("\r\nYou have won: {0}", BetResult);
            }
            Balance += decimal.Round(result,2);
            Stake = 0;
        }

        public decimal DisplayBalance()
        {
            Console.WriteLine("Current balance is: {0}", Balance.ToString());
            return Balance;
        }
    }
}
