using SlotMachine.StateMachine;

namespace SlotMachine.Ports
{
    public interface IState
    {
        public void ExecuteState();
    }
}