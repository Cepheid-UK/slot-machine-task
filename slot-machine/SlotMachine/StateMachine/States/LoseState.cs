using System;
using SlotMachine.Ports;

namespace SlotMachine.StateMachine
{
    public class LoseState : IState
    {
        private readonly IFiniteStateMachine _finiteStateMachine;
        // Game is lost, informs the user then restarts the game
        public LoseState(
            IFiniteStateMachine finiteStateMachine)
        {
            _finiteStateMachine = finiteStateMachine;
        }
        public Game game;
        public void ExecuteState()
        {
            Console.WriteLine("No Balance remaining\r\n");
            _finiteStateMachine.ChangeState("start");
        }
    }
}
