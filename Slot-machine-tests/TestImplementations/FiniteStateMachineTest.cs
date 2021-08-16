using System.Collections.Generic;
using SlotMachine.Ports;

namespace SlotMachineTests.TestImplementations
{
    public class FiniteStateMachineTest : IFiniteStateMachine  
    {
        public FiniteStateMachineTest() 
        {
            testDictionary = new Dictionary<string, IState>();
        }

        public Dictionary<string, IState> testDictionary;
        protected Dictionary<string, IState> States { get; set; }
        protected IState CurrentState { get; set; }

        public void AddState(string key, IState state) 
        {
            testDictionary.Add(key, state);
        }

        public void ChangeState(string stateKey) 
        {
            if (testDictionary.ContainsKey(stateKey))
            {
                CurrentState = testDictionary[stateKey];
                CurrentState.ExecuteState();
            }
        }

        public Dictionary<string, IState> GetStates() 
        {
            return testDictionary;
        }

        public string GetCurrentStateName()
        {
            foreach (string key in testDictionary.Keys)
            {
                if (testDictionary[key] == CurrentState)
                {
                    return key;
                }
            }
            return "Not found";
        }
    }
}
