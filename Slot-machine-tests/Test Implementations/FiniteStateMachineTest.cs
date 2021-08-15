using System.Collections.Generic;
using SlotMachine.Ports;

namespace SlotMachineTests.TestImplementations
{
    public class FiniteStateMachineTest : IFiniteStateMachine  
    {
        public Dictionary<string, IState> testDictionary;
        public FiniteStateMachineTest() 
        {
            AddState("test", new StateTest());
        }

        protected Dictionary<string, IState> States { get; set; }
        protected IState CurrentState { get; set; }

        public void AddState(string key, IState state) 
        {
            testDictionary.Add(key, state);
        }

        public void ChangeState(string stateKey) 
        { 

        }

        public Dictionary<string, IState> GetStates() 
        {
            return testDictionary;
        }
    }
}
