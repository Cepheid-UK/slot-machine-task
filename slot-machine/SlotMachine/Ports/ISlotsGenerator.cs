using System.Collections.Generic;
using SlotMachine.Slots;

namespace SlotMachine.Ports
{
    public interface ISlotsGenerator
    {
        public Symbol[,] SlotsMatrix { get; set; }
        public List<int> SlotDimensions { get; set; }
        public SymbolsList SlotSymbols { get; set; }

        Symbol GenerateRandomSymbol();
        Symbol[,] GenerateSlots();
        string GetSymbolName(Symbol symbol);
        List<Symbol> GetSymbolsList();
    }
}
