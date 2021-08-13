using System;

namespace SlotMachine.StateMachine
{
    public class StartState : IState
    {
        // Default starting state - prompts the user to input a Balance and validates
        public StartState(Game activeGame)
        {
            game = activeGame;
        }
        public Game game;

        public void ExecuteState()
        {
            Console.WriteLine("Please deposit money you would like to play with:");
            string response = Console.ReadLine();

            bool isANumber = decimal.TryParse(response, out decimal money);

            if (isANumber && money > 0)
            {
                game.wallet.DepositMoney(money);
                game.fsm.SetState("Stake");
            }
            else
            {
                Console.WriteLine("Not an acceptable input, please enter a number\r\n");
                game.fsm.SetState("start");
            }
        }
    }
}
