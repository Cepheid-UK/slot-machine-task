using System;

namespace SlotMachine.StateMachine
{
    public class LoseState : IState
    {
        public LoseState(Game activeGame)
        {
            game = activeGame;
        }
        public Game game;
        public void ExecuteState()
        {
            Console.WriteLine("Lost state");
        }
    }
}
