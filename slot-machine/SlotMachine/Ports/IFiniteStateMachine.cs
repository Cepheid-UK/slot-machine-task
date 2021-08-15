using System.Collections.Generic;

namespace SlotMachine.Ports
{
    public interface IFiniteStateMachine
    {
        void AddState(string key, IState state);
        void ChangeState(string stateKey);
        Dictionary<string, IState> GetStates();
    }
}
