using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SlotMachine.Slots;

namespace SlotMachine.Ports
{
    public interface ISlotsGenerator
    {
        public ESymbol[,] SlotsMatrix { get; set; }
        public List<int> SlotDimensions { get; set; }
        public int MatchesRequired { get; set; }
        public SymbolsDictionary SlotSymbols { get; set; }

        ESymbol GenerateRandomSymbol();
        ESymbol[,] GenerateSlots();
        string GetSymbolName(ESymbol symbol);
        Dictionary<ESymbol, Symbol> GetSymbolsDictionary();
    }
}
