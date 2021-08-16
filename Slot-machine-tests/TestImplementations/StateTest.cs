using SlotMachine.Ports;

namespace SlotMachineTests.TestImplementations
{
    public class StateTest : IState
    {
        public StateTest()
        {
            executed = false;
        }

        public bool executed;

        public void ExecuteState()
        {
            executed = true;
        }
    }
}
