using SlotMachine.Calculations;
using SlotMachine.Ports;

namespace SlotMachine.StateMachine
{
    public class PlayState : IState 
    {
        // Generates the slot machine and calculates the winnings
        private readonly IFiniteStateMachine _finiteStateMachine;
        private readonly IWallet _wallet;
        private readonly ISlotsGenerator _slotsGenerator;

        public PlayState(
            IFiniteStateMachine finiteStateMachine,
            IWallet wallet,
            ISlotsGenerator slotsGenerator)
        {
            _finiteStateMachine = finiteStateMachine;
            _wallet = wallet;
            _slotsGenerator = slotsGenerator;

        }
        public void ExecuteState()
        {
            var winningsLessStake = BetCalculator.CalculateWinnings(_slotsGenerator.GenerateSlots(), _wallet.GetStake());
            _wallet.BetResult(winningsLessStake);
            _wallet.DisplayBalance();

            if (_wallet.IsBankrupt())
            {
                _finiteStateMachine.ChangeState("lost");
            }
            else
            {
                _finiteStateMachine.ChangeState("Stake");
            }
        }
    }
}
