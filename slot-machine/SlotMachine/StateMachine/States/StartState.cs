using System;
using SlotMachine.Ports;

namespace SlotMachine.StateMachine
{
    public class StartState : IState
    {
        // Default starting state - prompts the user to input a Balance and validates
        public StartState(
            IFiniteStateMachine finiteStateMachine,
            IWallet wallet)
        {
            _finiteStateMachine = finiteStateMachine;
            _wallet = wallet;

        }
        private readonly IFiniteStateMachine _finiteStateMachine;
        private readonly IWallet _wallet;

        public void ExecuteState()
        {
            Console.WriteLine("Please deposit money you would like to play with:");
            string response = Console.ReadLine();

            bool isANumber = decimal.TryParse(response, out decimal money);

            if (isANumber && money > 0)
            {
                _wallet.DepositMoney(money);
                _finiteStateMachine.ChangeState("Stake");
            }
            else
            {
                Console.WriteLine("Not an acceptable input, please enter a number\r\n");
                _finiteStateMachine.ChangeState("start");
            }
        }
    }
}
