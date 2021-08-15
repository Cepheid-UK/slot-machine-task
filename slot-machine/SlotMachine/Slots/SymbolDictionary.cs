using System.Collections.Generic;

namespace SlotMachine.Slots
{
    public class SymbolsDictionary
    {
        public SymbolsDictionary()
        {
            Dictionary = new Dictionary<ESymbol, Symbol>();
            Dictionary.Add(ESymbol.Apple, new Apple());
            Dictionary.Add(ESymbol.Banana, new Banana());
            Dictionary.Add(ESymbol.Pineapple, new Pineapple());
            Dictionary.Add(ESymbol.Wildcard, new Wildcard());
        }

        public Dictionary<ESymbol, Symbol> Dictionary { get; set; }
    }
}
