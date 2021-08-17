using NUnit.Framework;
using System.Collections.Generic;
using SlotMachine;
using SlotMachine.Slots;
using SlotMachine.Calculations;

namespace SlotMachineTests
{
    [TestFixture]
    public class BetCalculatorTests
    {
        Symbol[,] slots { get; set; }
        Symbol A { get; set; }
        Symbol B { get; set; }
        Symbol C { get; set; }

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

            A = new(symbolParams);
            B = new(symbolParams2);
            C = new(symbolParams3);

            slots = new Symbol[,] {
                { A, A, A}, // match (2.4)
                { B, B, B }, // match (all wildcards) (0.3)
                { C, C, C }, // match with different coefficients to A (0.6)
                { A, B, A },  // match with wildcard (1.7)
                { A, A, C }, // no-match
                { A, B, C }, // no-match with wildcard
            };
        }

        [Test]
        public void MatchingRowCoefficientCalculatedCorrectly()
        {
            List<Symbol> list = new();
            list.Add(A);
            list.Add(A);
            list.Add(A);

            var result = BetCalculator.GetCoefficientForRow(list);

            if (result != 2.4m)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void MatchingRowWithWildcardsCoefficientCalculatedCorrectly()
        {
            List<Symbol> list = new();
            list.Add(A);
            list.Add(B);
            list.Add(A);

            var result = BetCalculator.GetCoefficientForRow(list);

            if (result != 1.7m)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void LosingRowCoefficientCalculatedCorrectly()
        {
            List<Symbol> list = new();
            list.Add(A);
            list.Add(A);
            list.Add(C);

            var result = BetCalculator.GetCoefficientForRow(list);

            if (result != 0m)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void LosingRowWithWildcardsCoefficientCalculatedCorrectly()
        {
            List<Symbol> list = new();
            list.Add(A);
            list.Add(B);
            list.Add(C);

            var result = BetCalculator.GetCoefficientForRow(list);

            if (result != 0m)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CalculateEntireSlotWinnings()
        {
            var result = BetCalculator.CalculateWinnings(slots, 1);
            
            if (result != 5m)
            {
                Assert.Fail();
            }
        }

    }
}