using SlotMachine.Ports;

namespace SlotMachineTests.TestImplementations
{
    public class GameTest : IGame
    {
        public GameTest()
        {
            Start = false;
        }
        public bool Start { get; set; }
        public void StartGame()
        {
            Start = true;
        }
    }

    
}
