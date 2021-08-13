using System;

namespace SlotMachine.StateMachine
{
    public class StartState : IState
    {
        public StartState(Game activeGame)
        {
            game = activeGame;
        }
        public Game game;

        public void ExecuteState()
        {
            Console.WriteLine("Please deposit money you would like to play with:");
            string response = Console.ReadLine();

            bool isInt = int.TryParse(response, out int money);

            if (isInt)
            {
                game.wallet.DepositMoney(money);
                game.fsm.SetState("stake");
            }
            else
            {
                Console.WriteLine("Not an acceptable input, please enter a number\r\n");
                game.fsm.SetState("start");
            }
        }
    }
}
