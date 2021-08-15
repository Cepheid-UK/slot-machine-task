namespace SlotMachine.Ports
{
    public interface IWallet
    {
        public bool CanAffordBet(decimal bet);

        public bool IsBankrupt();

        public void DepositMoney(decimal money);

        public void StakeMoney(decimal stake);

        public decimal GetStake();

        public void BetResult(decimal result);

        public void DisplayBalance();
    }
}
