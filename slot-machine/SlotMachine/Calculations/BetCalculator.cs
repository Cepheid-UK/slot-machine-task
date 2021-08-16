using System.Collections.Generic;
using System;
using SlotMachine.Slots;

namespace SlotMachine.Calculations
{
    class BetCalculator
    {
        public static decimal CalculateWinnings(Symbol[,] slots, decimal stake)
        {
            var rows = slots.GetLength(0);
            var cols = slots.GetLength(1);

            decimal totalWinningsCoefficient = 0;

            for (var i=0; i<rows; i++)
            {
                var symbolRow = new List<Symbol>();

                for (var j=0; j<cols; j++)
                {
                    symbolRow.Add(slots[i, j]);
                }

                totalWinningsCoefficient += GetCoefficientForRow(symbolRow);
            }

            return totalWinningsCoefficient * stake;
        }

        public static decimal GetCoefficientForRow(List<Symbol> symbolRow)
        {
            decimal rowCoefficient = 0;
            Symbol winningSymbol = null;

            foreach (var symbol in symbolRow)
            {
                if (symbol.IsWildcard())
                {
                    continue;
                }
                winningSymbol = symbol;
                break;
            }
            
            foreach (var symbol in symbolRow)
            {
                if (symbol.IsWildcard() || symbol == winningSymbol)
                {
                    rowCoefficient += symbol.Coefficient;
                }
                else
                {
                    return 0m;
                }
            }
            return rowCoefficient;
        }
    }
}
