using System;
using SlotMachine.StateMachine;
using System.Collections.Generic;

namespace SlotMachine
{
    public class Game
    {
        public Game()
        {   
            wallet = new Wallet();
            fsm = new FiniteStateMachine(this);
            fsm.SetState("start");
        }

        public FiniteStateMachine fsm { get; set; }
        public Wallet wallet { get; set; }
    }
}
