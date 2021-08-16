using System.Collections.Generic;

namespace SlotMachine
{
    public class AppSettings
    {
        public int SlotCols { get; set; }
        public int SlotRows { get; set; }
    }

    public class SymbolData
    {
        public List<SymbolParams> SymbolParameters { get; set; }
    }

    public class SymbolParams
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public decimal Coefficient { get; set; }
        public bool Wildcard { get; set; }
        public decimal ChanceToAppear { get; set; }
    }
}
