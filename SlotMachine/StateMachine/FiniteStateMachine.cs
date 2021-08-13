using System.Collections.Generic;

namespace SlotMachine.StateMachine
{
    public class FiniteStateMachine
    {
        public FiniteStateMachine(Game game)
        {
            states = new Dictionary<string, IState>();

            AddState("start", new StartState(game));
            AddState("stake", new StakeState(game));
            AddState("play", new PlayState(game));
            AddState("lost", new LoseState(game));
        }

        protected Dictionary<string, IState> states { get; set; }
        protected IState currentState { get; set; }

        public void SetState(string stateKey)
        {
            if (states.ContainsKey(stateKey))
            {
                currentState = states[stateKey];
                currentState.ExecuteState();
            }

        }

        public void AddState(string key, IState state)
        {
            states.Add(key, state);
        }

        public Dictionary<string, IState> GetStates()
        {
            return states;
        }
    }
}
