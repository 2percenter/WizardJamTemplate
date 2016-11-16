using UnityEngine;
using Assets.Scripts.States;
using Assets.Scripts.Interfaces;


namespace Assets.Scripts.States
{
    public class GameState : IStateBase
    {
        private StateManager manager;
        private GameMenu gameMenu;
        

        public GameState(StateManager managerRef)
        {
            manager = managerRef;
            
        }

        public void StateStart()
        {
            gameMenu = GameObject.FindObjectOfType<GameMenu>();
        }

        public void StateUpdate()
        //Use this (if you want) to call certain methods during the Update() cycle. This will be called from the StateManager for the current state only.
        {
            //For this example, I am calling the GameMenu's GameStateUpdate() method in order to not be checking this on every update cycle even when we're not in game state.
            gameMenu.GameStateUpdate();
        }

    }

}
