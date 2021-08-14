using System;
using SlotMachine.Calculations;

namespace SlotMachine.StateMachine
{
    public class PlayState : IState 
    {
        // Generates the slot machine and calculates the winnings
        public PlayState(Game activeGame)
        {
            game = activeGame;
        }
        public Game game;
        public void ExecuteState()
        {
            var slots = game.slotsGenerator.GenerateSlots();
            var winningsLessStake = BetCalculator.CalculateWinnings(slots, game);
            game.wallet.BetResult(winningsLessStake);
            game.wallet.DisplayBalance();

            // establish effective way to store the data
            // establish Stake
            // calculate matches

            if (game.wallet.IsBankrupt())
            {
                game.fsm.SetState("lost");
            }
            else
            {
                game.fsm.SetState("Stake");
            }
        }
    }
}
