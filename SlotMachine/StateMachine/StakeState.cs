using System;

namespace SlotMachine.StateMachine
{
    public class StakeState : IState
    {
        // Handles the Stake input and validation
        public StakeState(Game activeGame)
        {
            game = activeGame;
        }
        public Game game;
        public void ExecuteState()
        {
            Console.WriteLine("\r\nEnter Stake Amount:");
            var response = Console.ReadLine();

            bool isANumber = decimal.TryParse(response, out decimal stake);

            if (isANumber)
            {
                if (stake > 0 && game.wallet.CanAffordBet(stake))
                {
                    Console.WriteLine("Stake: {0}",stake);
                    // player has entered a valid Stake
                    game.wallet.StakeMoney(stake);
                    game.fsm.SetState("play");
                }
                else
                {
                    // player tried to Stake too much
                    Console.WriteLine("\r\nInsufficient Balance");
                    game.fsm.SetState("Stake");                
                }
            }
            else
            {
                // player entered a character that cannot be parsed as a decimal
                Console.WriteLine("\r\nNot an acceptable input, please enter a number");
                game.fsm.SetState("Stake");
            }
        }
    }
}
