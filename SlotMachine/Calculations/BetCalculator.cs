using System.Collections.Generic;
using SlotMachine.Slots;
using System;
using System.Linq;

namespace SlotMachine.Calculations
{
    class BetCalculator
    {
        public static decimal CalculateWinnings(ESymbol[,] slots, Game game)
        {
            var cols = slots.GetLength(0);
            var rows = slots.GetLength(1);

            decimal totalWinningsCoefficient = 0;

            for (var i=0; i<cols; i++)
            {
                var symbolRow = new List<ESymbol>();

                for (var j=0; j<rows; j++)
                {
                    symbolRow.Add(slots[i, j]);
                }

                totalWinningsCoefficient += GetCoefficientForRow(symbolRow, game);
            }

            return totalWinningsCoefficient * game.wallet.GetStake();
        }

        public static decimal GetCoefficientForRow(List<ESymbol> symbolRow, Game game)
        {
            var dictionary = game.slotsGenerator.GetSymbolsDictionary();

            // remove all wildcards from the list (wildcards have no coefficient)
            // check if all symbols are the same
            // if true - multiply coefficients by number of symbols
            // if false - return 0

            var listWithoutWildcards = new List<ESymbol>();

            foreach (var symbol in symbolRow)
            {
                // remove all wildcards
                if (!dictionary[symbol].IsWildcard())
                {
                    listWithoutWildcards.Add(symbol);
                }
            }

            if (listWithoutWildcards.Count == 0) { return 0m; } // all wildcards

            int consecutiveSymbols = 0;
            ESymbol winningSymbol = listWithoutWildcards[0];

            for (var i=0; i<= listWithoutWildcards.Count-1; i++)
            {
                if (listWithoutWildcards[i] != winningSymbol)
                {
                    // symbol doesnt match the first
                    return 0m;
                }
                consecutiveSymbols++;
            }

            return listWithoutWildcards.Count * dictionary[winningSymbol].Coefficient;
        }
    }
}
