using UnityEngine;
using Assets.Scripts.States;
using Assets.Scripts.Interfaces;


namespace Assets.Scripts.States
{
    public class MenuState : IStateBase
    {
        private StateManager manager;
        private GameMenu gameMenu;


        public MenuState(StateManager managerRef)
        {
            manager = managerRef;
            gameMenu = GameObject.FindObjectOfType<GameMenu>();
        }

        public void StateStart()
        {

        }

        public void StateUpdate()
        //Use this (if you want) to call certain methods during the Update() cycle. This will be called from the StateManager for the current state only.
        {
            gameMenu.MenuStateUpdate();
        }

    }

}
