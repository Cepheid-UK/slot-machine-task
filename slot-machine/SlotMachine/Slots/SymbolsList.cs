using System.Collections.Generic;

namespace SlotMachine.Slots
{
    public class SymbolsList
    {
        public SymbolsList(SymbolData symbolData)
        {
            List = new List<Symbol>();
            foreach (var symbolParams in symbolData.SymbolParameters)
            {
                List.Add(new Symbol(symbolParams));
            }
        }

        public List<Symbol> List { get; set; }

        public List<Symbol> GetList()
        {
            return List;
        }
    }
}
