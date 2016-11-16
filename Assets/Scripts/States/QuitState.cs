using UnityEngine;
using Assets.Scripts.States;
using Assets.Scripts.Interfaces;


namespace Assets.Scripts.States
{
    public class QuitState : IStateBase
    {
        private StateManager manager;
        
        public QuitState(StateManager managerRef)
        {
            manager = managerRef;
        }

        public void StateStart()
        {

        }

        public void StateUpdate()
        //Use this (if you want) to call certain methods during the Update() cycle. This will be called from the StateManager for the current state only.
        {

        }

    }

}
