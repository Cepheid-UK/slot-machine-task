using System;
using SlotMachine.Ports;

namespace SlotMachine.StateMachine
{
    public class LoseState : IState
    {
        private readonly IFiniteStateMachine _finiteStateMachine;
        // Game is lost, informs the player
        public LoseState(
            IFiniteStateMachine finiteStateMachine)
        {
            _finiteStateMachine = finiteStateMachine;
        }
        public Game game;
        public void ExecuteState()
        {
            Console.WriteLine("No Balance remaining\r\n");
            // Uncomment the next line if you want the game to restart when it ends
            //_finiteStateMachine.ChangeState("start");
        }
    }
}
