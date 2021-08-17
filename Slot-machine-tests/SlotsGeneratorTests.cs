using NUnit.Framework;
using SlotMachine;
using SlotMachine.Slots;

namespace SlotMachineTests
{
    [TestFixture]
    public class SlotsGeneratorTests
    {
        AppSettings appSettings { get; set; }
        SymbolData symbolData { get; set; }
        SlotsGenerator slotsGenerator { get; set; }

        
        [SetUp]
        public void Setup()
        {
            // could add this to config file for more flexible tests in larger applications
            appSettings = new();
            appSettings.SlotCols = 3;
            appSettings.SlotRows = 4;

            symbolData = new();
            symbolData.SymbolParameters = new();

            SymbolParams symbolParams = new();
            symbolParams.Name = "T";
            symbolParams.FullName = "Test";
            symbolParams.Coefficient = 0.5m;
            symbolParams.ChanceToAppear = 0.25m;
            symbolParams.Wildcard = false;
            symbolData.SymbolParameters.Add(symbolParams);

            SymbolParams symbolParams2 = new();
            symbolParams2.Name = "W";
            symbolParams2.FullName = "TestWildCard";
            symbolParams2.Coefficient = 0.1m;
            symbolParams2.ChanceToAppear = 0.75m;
            symbolParams2.Wildcard = true;
            symbolData.SymbolParameters.Add(symbolParams2);

            slotsGenerator = new SlotsGenerator(appSettings, symbolData);
        }

        [Test]
        public void CorrectRowsAndColsInSlots()
        {
            if (slotsGenerator.SlotDimensions[0] != 4)
            {
                Assert.Fail();
            }

            if (slotsGenerator.SlotDimensions[1] != 3)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void SymbolsCorrectlyCreated()
        {
            var symbolList = slotsGenerator.GetSymbolsList();

            if (symbolList[0].Name != "T" ||
                symbolList[1].FullName != "TestWildCard" ||
                symbolList[0].Coefficient != 0.5m ||
                symbolList[1].ChanceToAppear != 0.75m ||
                symbolList[0].IsWildcard()
                )
            {
                Assert.Fail();
            }
        }

        [Test]
        public void RandomSymbolGeneratedFromChanceToAppear()
        {
            int T = 0;
            int W = 0;

            for (var i=0; i<10000; i++)
            {
                if(slotsGenerator.GenerateRandomSymbol().Name == "T")
                {
                    T++;
                }
                else
                {
                    W++;
                }
            }

            if (T < 2000 || T > 3000) // infintesmally unlikely to fail
            {
                Assert.Fail();
            }
        }

        [Test]
        public void GeneratingCorrectSlotsSize()
        {
            var slots = slotsGenerator.GenerateSlots();

            if (slots.Length != (3 * 4))
            {
                Assert.Fail();
            }

            if (slots.GetLength(0) != 4 && slots.GetLength(1) != 3)
            {
                Assert.Fail();
            }
        }
    }
}