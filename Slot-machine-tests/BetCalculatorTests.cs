using NUnit.Framework;
using SlotMachine;
using SlotMachine.Slots;
using SlotMachine.Calculations;

namespace SlotMachineTests
{
    [TestFixture]
    public class BetCalculatorTests
    {
        Symbol[,] slots { get; set; }

        [SetUp]
        public void Setup()
        {
            SymbolParams symbolParams = new();
            symbolParams.Name = "A";
            symbolParams.FullName = "ATest";
            symbolParams.Coefficient = 0.8m;
            symbolParams.ChanceToAppear = 0.25m;
            symbolParams.Wildcard = false;

            SymbolParams symbolParams2 = new();
            symbolParams2.Name = "B";
            symbolParams2.FullName = "BTest";
            symbolParams2.Coefficient = 0.1m;
            symbolParams2.ChanceToAppear = 0.1m;
            symbolParams2.Wildcard = true;
            
            SymbolParams symbolParams3 = new();
            symbolParams3.Name = "C";
            symbolParams3.FullName = "CTest";
            symbolParams3.Coefficient = 0.2m;
            symbolParams3.ChanceToAppear = 0.65m;
            symbolParams3.Wildcard = false;

            Symbol A = new(symbolParams);
            Symbol B = new(symbolParams2);
            Symbol C = new(symbolParams3);

            slots = new Symbol[,] {
                { A, A, A}, // match
                { B, B, B }, // match (all wildcards)
                { C, C, C }, // match with different coefficients
                { A, B, A },  // match with wildcard
                { A, A, C }, // no-match
                { A, B, C }, // no-match with wildcard
            };
        }

        [Test]
        public void CalculatesRowCoefficientCorrectly()
        {
            // todo - make BetCalculator a service?
        }
        
    }
}