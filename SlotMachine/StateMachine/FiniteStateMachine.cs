using System.Collections.Generic;
using SlotMachine.Ports;

namespace SlotMachine.StateMachine
{
    // Handles the definition and changing of state
    public class FiniteStateMachine : IFiniteStateMachine  
    {
        private IWallet _wallet { get; set; }
        private ISlotsGenerator _slotsGenerator { get; set; }

        public FiniteStateMachine(
            IWallet wallet,
            ISlotsGenerator slotsGenerator) 
        {
            States = new Dictionary<string, IState>();

            _wallet = wallet;
            _slotsGenerator = slotsGenerator;

            AddState("start", new StartState(this, _wallet));
            AddState("Stake", new StakeState(this, _wallet));
            AddState("play", new PlayState(this, _wallet, _slotsGenerator));
            AddState("lost", new LoseState(this));
        }

        protected Dictionary<string, IState> States { get; set; }
        protected IState CurrentState { get; set; }

        public void AddState(string key, IState state)
        {
            States.Add(key, state);
        }

        public void ChangeState(string stateKey)
        {
            if (States.ContainsKey(stateKey))
            {
                CurrentState = States[stateKey];
                CurrentState.ExecuteState();
            }
        }

        public void RunStateMachine()
        {
            while(true)
            {

            }
        }

        public Dictionary<string, IState> GetStates()
        {
            return States;
        }
    }
}
