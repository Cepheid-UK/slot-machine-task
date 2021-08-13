using System;

namespace SlotMachine.StateMachine
{
    public class PlayState : IState
    {
        public PlayState(Game activeGame)
        {
            game = activeGame;
        }
        public Game game;
        public void ExecuteState()
        {
            Console.WriteLine("Playing state");
        }
    }
}
