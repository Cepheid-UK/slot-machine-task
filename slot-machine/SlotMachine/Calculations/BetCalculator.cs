using System.Collections.Generic;
using SlotMachine.Slots;

namespace SlotMachine.Calculations
{
    class BetCalculator
    {
        public static decimal CalculateWinnings(Symbol[,] slots, decimal stake)
        {
            var cols = slots.GetLength(0);
            var rows = slots.GetLength(1);

            decimal totalWinningsCoefficient = 0;

            for (var i=0; i<cols; i++)
            {
                var symbolRow = new List<Symbol>();

                for (var j=0; j<rows; j++)
                {
                    symbolRow.Add(slots[i, j]);
                }

                totalWinningsCoefficient += GetCoefficientForRow(symbolRow);
            }

            return totalWinningsCoefficient * stake;
        }

        public static decimal GetCoefficientForRow(List<Symbol> symbolRow)
        {
            var listWithoutWildcards = new List<Symbol>();
            foreach (var symbol in symbolRow)
            {
                // this implementation assumes wildcards always have a coefficient of 0
                if (!symbol.IsWildcard())
                {
                    listWithoutWildcards.Add(symbol);
                }
            }

            if (listWithoutWildcards.Count == 0) { return 0m; } // all wildcards

            int consecutiveSymbols = 0;
            Symbol winningSymbol = listWithoutWildcards[0];

            for (var i=0; i<= listWithoutWildcards.Count-1; i++)
            {
                if (listWithoutWildcards[i] != winningSymbol)
                {
                    return 0m; // symbol doesnt match the first, so we can discard
                }
                consecutiveSymbols++;
            }

            return listWithoutWildcards.Count * winningSymbol.Coefficient;
        }
    }
}
