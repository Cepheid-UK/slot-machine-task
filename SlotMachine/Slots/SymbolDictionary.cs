using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
