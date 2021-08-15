using NUnit.Framework;
using SlotMachine;
using SlotMachine.Ports;
using SlotMachineTests.TestImplementations;

namespace SlotMachineTests
{
    public class SlotMachineTests
    {
        private IGame _game;
        private IFiniteStateMachine _finiteStateMachine;

        [SetUp]
        public void Setup()
        {
            _finiteStateMachine = new FiniteStateMachineTest();
            _game = new Game(_finiteStateMachine);
        }

        [Test]
        public void GameStarts()
        {

            Assert.Pass();
        }
    }
}