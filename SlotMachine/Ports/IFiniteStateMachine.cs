using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlotMachine.Ports
{
    public interface IFiniteStateMachine
    {
        void AddState(string key, IState state);
        void ChangeState(string stateKey);
        Dictionary<string, IState> GetStates();
    }
}
