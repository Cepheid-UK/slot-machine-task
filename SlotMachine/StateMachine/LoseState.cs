using System;

namespace SlotMachine.StateMachine
{
    public class LoseState : IState
    {
        // Game is lost, informs the user then restarts the game
        public LoseState(Game activeGame)
        {
            game = activeGame;
        }
        public Game game;
        public void ExecuteState()
        {
            Console.WriteLine("No Balance remaining");
            game.fsm.SetState("start");
        }
    }
}
