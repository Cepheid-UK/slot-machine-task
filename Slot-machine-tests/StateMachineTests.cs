using NUnit.Framework;
using System;
using SlotMachine.Calculations;
using SlotMachine.Ports;
using SlotMachineTests.TestImplementations;

namespace SlotMachineTests
{
    [TestFixture]
    public class StateMachineTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GameStartingTest()
        {
            var game = new GameTest();
            game.StartGame();

            if (!game.Start)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void FiniteStateMachineAddsStates()
        {
            var fsm = new FiniteStateMachineTest();

            fsm.AddState("test", new StateTest());
            var states = fsm.GetStates();

            if (!states.ContainsKey("test"))
            {
                Assert.Fail();
            }
        }

        [Test]
        public void FiniteStateMachineChangesStates()
        {
            var fsm = new FiniteStateMachineTest();

            fsm.AddState("first", new StateTest());
            fsm.AddState("second", new StateTest());

            fsm.ChangeState("first");
            if (fsm.GetCurrentStateName() != "first")
            {
                Assert.Fail();
            }

            fsm.ChangeState("second");
            if (fsm.GetCurrentStateName() != "second")
            {
                Assert.Fail();
            }
        }
    }
}