using SlotMachine.Ports;

namespace SlotMachine
{
    public class Game : IGame
    {
        private readonly IFiniteStateMachine _finiteStateMachine;
        public Game(IFiniteStateMachine finiteStateMachine)
        {
            _finiteStateMachine = finiteStateMachine;
        }

        public void StartGame()
        {
            _finiteStateMachine.ChangeState("start");
        }
    }
}
