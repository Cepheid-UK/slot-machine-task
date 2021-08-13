using SlotMachine.StateMachine;
using SlotMachine.Slots;
using SlotMachine.Calculations;

namespace SlotMachine
{
    public class Game
    {
        public Game()
        {
            slotsGenerator = new SlotsGenerator(3, 4);
            wallet = new Wallet();
            fsm = new FiniteStateMachine(this);
            fsm.SetState("start");
        }

        public FiniteStateMachine fsm { get; set; }
        public Wallet wallet { get; set; }
        public SlotsGenerator slotsGenerator { get; set; }
    }
}
