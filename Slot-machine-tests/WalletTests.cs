using NUnit.Framework;
using SlotMachine.Calculations;

namespace SlotMachineTests
{
    [TestFixture]
    public class WalletTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WalletDepositsMoney()
        {
            var wallet = new Wallet();

            wallet.DepositMoney(100);
            var balance = wallet.DisplayBalance();

            if (balance != 100)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void WalletStakesMoney()
        {
            var wallet = new Wallet();

            wallet.DepositMoney(100);
            wallet.StakeMoney(25);

            if (wallet.DisplayBalance() != 75 && wallet.GetStake() != 25)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CannotStakeNegativeAmount()
        {
            var wallet = new Wallet();

            wallet.DepositMoney(100);
            wallet.StakeMoney(-50);

            if (wallet.DisplayBalance() != 100)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void WalletBalanceCannotBeBelowZero()
        {
            var wallet = new Wallet();

            wallet.DepositMoney(100);
            wallet.DepositMoney(-150);
            wallet.StakeMoney(150);

            if (wallet.DisplayBalance() != 100)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void WalletRoundsBalance()
        {
            var wallet = new Wallet();

            wallet.DepositMoney(100.54321m);
            
            if (wallet.DisplayBalance() != 100.54m)
            {
                Assert.Fail();
            }

            wallet.StakeMoney(10.12345m);

            if (wallet.DisplayBalance() != 90.42m)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void WalletIsBankrupt()
        {
            var wallet = new Wallet();

            wallet.DepositMoney(10m);
            wallet.StakeMoney(10m);

            if(!wallet.IsBankrupt())
            {
                Assert.Fail();
            }
            
        }

        [Test]
        public void BetWonAndDeposited()
        {
            var wallet = new Wallet();

            wallet.DepositMoney(100);
            wallet.StakeMoney(10);
            wallet.BetResult(30);

            if (wallet.DisplayBalance() != 120)
            {
                Assert.Fail();
            }
        }
        
        [Test]
        public void BetLost()
        {
            var wallet = new Wallet();

            wallet.DepositMoney(100);
            wallet.StakeMoney(20);
            wallet.BetResult(-20);

            if (wallet.DisplayBalance() != 80)
            {
                Assert.Fail();
            }

            wallet.StakeMoney(20);
            wallet.BetResult(-30); // shouldn't lose more than stake

            if (wallet.DisplayBalance() != 60)
            {
                Assert.Fail();
            }



        }
    }
}