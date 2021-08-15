using System;
using System.Collections.Generic;
using SlotMachine.Ports;

namespace SlotMachine.Slots
{
    public class SlotsGenerator : ISlotsGenerator
    {
        public SlotsGenerator()
        {
            int cols = 3;
            int rows = 4;
            SlotDimensions = new List<int>(); SlotDimensions.Add(rows); SlotDimensions.Add(cols);
            SlotsMatrix = new ESymbol[rows, cols];
            MatchesRequired = cols; // supports any number of columns

            SlotSymbols = new SymbolsDictionary();
        }

        public ESymbol[,] SlotsMatrix { get; set; }
        public List<int> SlotDimensions { get; set; }
        public int MatchesRequired { get; set; }
        public SymbolsDictionary SlotSymbols { get; set; }

        public ESymbol GenerateRandomSymbol()
        {
            double randomNumber = new Random().NextDouble();

            // change this to refer to a config file
            return randomNumber switch
            {
                <= 0.05 => ESymbol.Wildcard,
                < 0.2 => ESymbol.Pineapple,
                < 0.55 => ESymbol.Banana,
                _ => ESymbol.Apple,
            };
        }

        public ESymbol[,] GenerateSlots()
        {
            // Generates the symbols on the slots and prints the lines
            // Supports any sized 2D slot machine
            Console.WriteLine("\r\n");

            for(var i=0; i<SlotDimensions[0]; i++)
            {
                var rowString = "";
                for (var j=0; j<SlotDimensions[1]; j++)
                {
                    SlotsMatrix[i, j] = GenerateRandomSymbol();
                    rowString += GetSymbolName(SlotsMatrix[i, j]);
                }
                Console.WriteLine(rowString);
            }
            return SlotsMatrix;
        }

        public string GetSymbolName(ESymbol symbol)
        {
            return SlotSymbols.Dictionary[symbol].Name;
        }

        public Dictionary<ESymbol, Symbol> GetSymbolsDictionary()
        {
            return SlotSymbols.Dictionary;
        }
    }
}
