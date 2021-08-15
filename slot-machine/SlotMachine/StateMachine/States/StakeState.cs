using System;
using SlotMachine.Ports;

namespace SlotMachine.StateMachine
{
    public class StakeState : IState
    {
        // Handles the Stake input and validation
        public StakeState(
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
            Console.WriteLine("\r\nEnter Stake Amount:");
            var response = Console.ReadLine();

            bool isANumber = decimal.TryParse(response, out decimal stake);

            if (isANumber)
            {
                if (stake > 0 && _wallet.CanAffordBet(stake))
                {
                    Console.WriteLine("Stake: {0}",stake);
                    // player has entered a valid Stake
                    _wallet.StakeMoney(stake);
                    _finiteStateMachine.ChangeState("play");
                }
                else
                {
                    // player tried to Stake too much
                    Console.WriteLine("\r\nInsufficient Balance");
                    _finiteStateMachine.ChangeState("Stake");                
                }
            }
            else
            {
                // player entered a character that cannot be parsed as a decimal
                Console.WriteLine("\r\nNot an acceptable input, please enter a number");
                _finiteStateMachine.ChangeState("Stake");
            }
        }
    }
}
