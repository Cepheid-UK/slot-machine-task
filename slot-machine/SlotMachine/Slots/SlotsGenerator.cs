using System;
using System.Linq;
using System.Collections.Generic;
using SlotMachine.Ports;

namespace SlotMachine.Slots
{
    public class SlotsGenerator : ISlotsGenerator
    {
        public SlotsGenerator(AppSettings settings, SymbolData symbolData)
        {
            SlotDimensions = new List<int>(); 
            SlotDimensions.Add(settings.SlotRows); 
            SlotDimensions.Add(settings.SlotCols);

            SlotsMatrix = new Symbol[settings.SlotRows, settings.SlotCols];

            SlotSymbols = new SymbolsList(symbolData);
        }

        public Symbol[,] SlotsMatrix { get; set; }
        public List<int> SlotDimensions { get; set; }
        public SymbolsList SlotSymbols { get; set; }

        public Symbol GenerateRandomSymbol()
        {
            decimal randomNumber = new decimal(new Random().NextDouble());
            List<Symbol> SortedList = SlotSymbols.GetList().OrderBy(o => o.ChanceToAppear).ToList();
            List<decimal> cumulators = new List<decimal>();
            decimal cumulator = 0;

            for (var i=0; i< SortedList.Count; i++)
            {
                cumulator += SortedList[i].ChanceToAppear;
                cumulators.Add(cumulator);
                if (randomNumber < cumulators[i])
                {
                    return SortedList[i];
                }
            }

            return SortedList.Last();
        }

        public Symbol[,] GenerateSlots()
        {
            /* In a more long-lived application, I would separate the output into an abstracted "IUserOuput" interface
            I'd use a console implementation of that interface, and call that in the relevant state
            this would permit the game to be output to a log, or a db, or a webpage, etc.
            For simplicity, I've mixed the outputting of text to console into the logic of generating the slots */

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

        public string GetSymbolName(Symbol symbol)
        {
            return SlotSymbols.GetList().Find(s => s.Name == symbol.Name).Name;
        }

        public List<Symbol> GetSymbolsList()
        {
            return SlotSymbols.GetList();
        }
    }
}
