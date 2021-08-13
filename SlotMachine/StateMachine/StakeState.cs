using System;

namespace SlotMachine.StateMachine
{
    public class StakeState : IState
    {
        public StakeState(Game activeGame)
        {
            game = activeGame;
        }
        public Game game;
        public void ExecuteState()
        {
            Console.WriteLine("\r\nEnter Stake Amount:");
            var response = Console.ReadLine();

            bool isInt = int.TryParse(response, out int money);

            if (isInt)
            {
                if (game.wallet.CanAffordBet(money))
                {
                    game.wallet.StakeMoney(money);
                    game.fsm.SetState("play");
                }
                else
                {
                    Console.WriteLine("\r\nInsufficient balance");
                    game.fsm.SetState("stake");
                }
            }
            else
            {
                Console.WriteLine("\r\nNot an acceptable input, please enter a number");
                game.fsm.SetState("stake");
            }
        }
    }
}
