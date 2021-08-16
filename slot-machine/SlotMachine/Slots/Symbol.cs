using SlotMachine;

namespace SlotMachine.Slots
{
    public class Symbol
    {
        public Symbol(SymbolParams p)
        {
            Name = p.Name;
            FullName = p.FullName;
            Coefficient = p.Coefficient;
            Wildcard = p.Wildcard;
            ChanceToAppear = p.ChanceToAppear;
        }

        public string Name { get; set; }
        public string FullName { get; set; }
        public decimal Coefficient { get; set; }
        public bool Wildcard { get; set; }
        public decimal ChanceToAppear { get; set; }

        public bool IsWildcard()
        {
            return Wildcard;
        }
    }
}
