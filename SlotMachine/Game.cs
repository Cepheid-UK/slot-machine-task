using SlotMachine.StateMachine;
using SlotMachine.Slots;
using SlotMachine.Calculations;
using SlotMachine.Ports;

namespace SlotMachine
{
    public class Game : IGame
    {
        private readonly ISlotsGenerator _slotsGenerator;
        private readonly IWallet _wallet;
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
